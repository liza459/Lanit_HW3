using Color;

namespace lanit_HW2
{
    internal class Fibonacci
    {
        private readonly ColorCw color = new();
        public void Menu()
        {
            string paragraph = "";
            while (paragraph != "q")
            {
                color.Yellow("Введите порядковый номер числа ряда Фибоначчи?(для выхода в меню введите q)\n");
                paragraph = Console.ReadLine();

                if (paragraph != "q")
                {
                    try
                    {
                        Fibonacci fibonacci = new();
                        fibonacci.PrintFibonacci(int.Parse(paragraph));
                    }
                    catch (FormatException)
                    {
                        color.Red("Введеные символы, не являются числом\n");
                    }
                }
            }
        }
        public void PrintFibonacci(int number)
        {

            for (long i = 0, j = 1, sum = 1, count = 1;
                count <= number;
                sum = i + j, i = j, j = sum, count++)
            {
                color.Green(sum + ", ");
            }
            Console.WriteLine();
        }
    }
}
