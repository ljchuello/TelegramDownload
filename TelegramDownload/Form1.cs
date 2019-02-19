using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = Telegram.Bot.Types.File;

namespace TelegramDownload
{
    public partial class Form1 : Form
    {
        private TelegramBotClient _telegramBotClient;

        private int procesados = 0;

        public Form1()
        {
            InitializeComponent();
            Text = "Sermatick_Bot";
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private async void _telegramBotClient_OnUpdateAsync(object sender, Telegram.Bot.Args.UpdateEventArgs e)
        {
            User _usuarioTel = new User();
            Telegram.Bot.Types.Message _message = new Telegram.Bot.Types.Message();

            try
            {
                // Obtenemos
                _usuarioTel = e.Update.CallbackQuery != null ? e.Update.CallbackQuery.From : e.Update.Message.From;
                _message = e.Update.CallbackQuery != null ? e.Update.CallbackQuery.Message : e.Update.Message;
                string valor = e.Update.CallbackQuery != null ? e.Update.CallbackQuery.Data : e.Update.Message.Text;

                if (!Directory.Exists($"C:\\bot\\{_usuarioTel.Id}"))
                {
                    Directory.CreateDirectory($"C:\\bot\\{_usuarioTel.Id}");
                }

                string ext = string.Empty;
                string downloadUrl = string.Empty;

                lblDescargados.Text = $"Procesados: {++procesados:n2}";

                switch (_message.Type)
                {
                    case MessageType.Document:
                        var document = _message.Document;
                        File fileDocument = await _telegramBotClient.GetFileAsync(document.FileId);
                        ext = Path.GetExtension(fileDocument.FilePath);
                        downloadUrl = $"https://api.telegram.org/file/bot{txtToken.Text}/{fileDocument.FilePath}";
                        using (WebClient webClient = new WebClient())
                        {
                            webClient.DownloadFile(new Uri(downloadUrl), $"C:\\bot\\{_usuarioTel.Id}\\{Guid.NewGuid()}{ext}");
                        }
                        break;

                    case MessageType.Photo:
                        PhotoSize photoSize = _message.Photo.OrderByDescending(x => x.FileSize).FirstOrDefault() ?? new PhotoSize();
                        File filePhoto = await _telegramBotClient.GetFileAsync(photoSize.FileId);
                        ext = Path.GetExtension(filePhoto.FilePath);
                        downloadUrl = $"https://api.telegram.org/file/bot{txtToken.Text}/{filePhoto.FilePath}";
                        using (WebClient webClient = new WebClient())
                        {
                            webClient.DownloadFile(new Uri(downloadUrl), $"C:\\bot\\{_usuarioTel.Id}\\{Guid.NewGuid()}{ext}");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error; {ex.Message}");
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos que no este vacio la direccion
                if (string.IsNullOrWhiteSpace(txtDestino.Text))
                {
                    MessageBox.Show("Debe ingresar la ruta del destino");
                    return;
                }

                // Validamos que exista la ruta del destino
                if (!Directory.Exists(txtDestino.Text))
                {
                    MessageBox.Show("No existe la ruta del destino");
                    return;
                }

                // Validamos el token de telegram
                if (string.IsNullOrWhiteSpace(txtToken.Text))
                {
                    MessageBox.Show("Debe ingresar un token de telegram");
                    return;
                }

                // Comenzamos el bot
                _telegramBotClient = new TelegramBotClient(txtToken.Text);
                _telegramBotClient.StartReceiving();
                _telegramBotClient.OnUpdate += _telegramBotClient_OnUpdateAsync; ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error; {ex.Message}");
            }
        }
    }
}
