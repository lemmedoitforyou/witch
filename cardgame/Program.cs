namespace cardgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введіть кількість гравців: ");
            int numPlayers = int.Parse(Console.ReadLine());
            
            if(numPlayers <2 && numPlayers>6)
            {
                Console.WriteLine("Кількість гравців не може бути менша 2 і більша за 6");
            }
                
            Console.WriteLine("Виберіть режим гри:\n1-грати самому\n2-комп'ютерне моделювання");
            int gamemode = int.Parse(Console.ReadLine());
            switch(gamemode)
            {
                case 1:
                    Game game = new Game(numPlayers);
                    game.Start();
                    break;
                case 2:
                    break;
            }
                     
        }
    }
}