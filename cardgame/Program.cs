namespace cardgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть кількість гравців: ");
            int numPlayers = int.Parse(Console.ReadLine());
            if (numPlayers > 1 && numPlayers < 7)
            {
                Game game = new Game(numPlayers);
                game.Start();
            }
            else
            {
                Console.WriteLine("Кількість гравців не може бути менша 2 і більша за 6");
            }
        }
    }
}