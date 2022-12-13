using Color;

namespace lanit_HW3
{
    internal class Menu
    {
        public void StartMenu()
        {
            ColorCw color = new ColorCw();
            color.Yellow("Что вы хотите сделать?\nВведите:\n \t1  что бы прочитать текст из фаила на компе;" +
            "\n \t2  что бы сохранить данные по ссылке в текстовый документ;" +
            "\n \t3  что бы вывести ряд Фибоначчи до введенного числа;" +
            "\n \t4  что бы начать работу с базой данных"+
            "\n \t5  что бы выйти\n");
            string menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    Read read = new Read();
                    read.Menu();
                    break;
                case "2":
                    Save save = new Save();
                    save.Menu();
                    break;
                case "3":
                    Fibonacci fibonacci = new Fibonacci();
                    fibonacci.Menu();
                    break;
                case "4":
                    WorkWithDB db= new WorkWithDB();
                    db.Menu();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    color.Red("Ошибка ввода\n");
                    break;
            }
        }
    }
}
