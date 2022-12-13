using Color;
using System.Net;
using System.Text;

namespace lanit_HW2
{
    internal class Save
    {
        readonly ColorCw color = new();
        public void Menu()
        {
            string paragraph = "";
            while (paragraph != "q")
            {
                color.Yellow("Введите путь для сохранения файла (для сохранения в папку загрузки введите c:\\users\\ln459\\Downloads\\)(для выхода в меню введите q)\n");
                paragraph = Console.ReadLine();

                if (paragraph != "q")
                {
                    if (Directory.Exists(paragraph))
                    {
                        color.Yellow("Введите название файла\n");
                        string adress2 = Console.ReadLine();
                        string adress = @"" + paragraph + adress2 + ".txt";
                        Save save_adress = new();
                        _ = save_adress.Ya(adress);
                    }

                    else
                    {
                        color.Red("Введен неверный путь\n");
                    }
                }
            }
        }
        public async Task Ya(string adress)
        {
            color.Yellow("Введите ссылку\n");
            HttpClient client = new();
            string http_adress = Console.ReadLine();

            try
            {
                using WebClient wc = new();
                string HTMLSource = wc.DownloadString(http_adress);
                color.Green("Файл сохранен" + adress + "\n");
            }
            catch (Exception e)
            {
                color.Red("Cсылка не работает\n" + e.Message + "\n");
            }

            HttpResponseMessage httpResponce = await client.GetAsync(http_adress);
            string responseBody = await httpResponce.Content.ReadAsStringAsync();
            using FileStream txt = File.Create(adress);
            byte[] info = new UTF8Encoding(true).GetBytes(responseBody);
            txt.Write(info);
        }
    }
}
