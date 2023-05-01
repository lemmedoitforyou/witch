namespace cardgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть кількість гравців: ");
            int numPlayers = int.Parse(Console.ReadLine());
            Game game = new Game(numPlayers);
            game.Start();
        }
    }
}