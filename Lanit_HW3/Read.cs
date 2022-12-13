using Color;

namespace lanit_HW2
{
    internal class Read
    {
        readonly ColorCw color = new();
        public void Menu()
        {
            string paragraph = "";
            while (paragraph != "q")
            {
                color.Yellow("Сколько строк прочитать?(для выхода в меню введите q)\n");
                paragraph = Console.ReadLine();

                if (paragraph != "q")
                {
                    Read read = new();
                    read.Text(paragraph);
                    Console.WriteLine("");
                }
            }
        }
        public void Text(string final)
        {
            try
            {
                int counterLine = 0;
                int end = int.Parse(final);
                string line;
                StreamReader sr = new(@"C:\Users\ln459\Downloads\lanit_HW2.txt");
                line = "Текст";
                while (counterLine <= end)
                {
                    color.Green(line + "\n");
                    line = sr.ReadLine();
                    counterLine++;
                }
                sr.Close();
            }
            catch (FormatException e)
            {
                color.Red("Введеные символы, не являются числом\n" + e.Message);
            }
            catch (Exception e)
            {
                color.Red("Введенное число находится вне диапазона допустимых значений\n" + e.Message);
            }
        }
    }
}
