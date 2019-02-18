using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace TelegramDownload
{
    public partial class Form1 : Form
    {
        private TelegramBotClient _telegramBotClient;

        public Form1()
        {
            InitializeComponent();
            Text = "Sermatick_Bot";
        }

        private void _telegramBotClient_OnUpdateAsync(object sender, Telegram.Bot.Args.UpdateEventArgs e)
        {
            User _usuarioTel = new User();
            Telegram.Bot.Types.Message _message = new Telegram.Bot.Types.Message();

            try
            {
                // Obtenemos
                _usuarioTel = e.Update.CallbackQuery != null ? e.Update.CallbackQuery.From : e.Update.Message.From;
                _message = e.Update.CallbackQuery != null ? e.Update.CallbackQuery.Message : e.Update.Message;
                string valor = e.Update.CallbackQuery != null ? e.Update.CallbackQuery.Data : e.Update.Message.Text;

                //if (_message.Type != MessageType.Text)
                //{
                //    _telegramBotClient.SendTextMessageAsync(_moUsuario.IdTelegram, "El texto ingresado no es válido");
                //    return;
                //}
                switch (_message.Type)
                {
                    case MessageType.Photo:
                        PhotoSize photoSize = _message.Photo.OrderByDescending(x => x.FileSize).FirstOrDefault() ?? new PhotoSize();
                        string html = string.Empty;
                        string url = @"https://api.stackexchange.com/2.2/answers?order=desc&sort=activity&site=stackoverflow";

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.AutomaticDecompression = DecompressionMethods.GZip;

                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            html = reader.ReadToEnd();
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
