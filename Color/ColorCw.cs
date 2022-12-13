namespace Color
{
    public class ColorCw
    {
        public void Red (string massage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(massage);
            Console.ResetColor();
        }

        public void Yellow(string massage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(massage);
            Console.ResetColor();
        }

        public void Green(string massage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(massage);
            Console.ResetColor();
        }
    }
}