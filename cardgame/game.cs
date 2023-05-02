using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace cardgame
{
    public class Game
    {
        private Deck deck;
        private List<Player> players;
        private int currentPlayerIndex;

        public Game(int numPlayers)
        {
            deck = new Deck(numPlayers);
            deck.Shuffle();

            players = new List<Player>();
            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write($"Введіть ім'я гравця{i + 1}: ");
                string name = Console.ReadLine();
                players.Add(new Player(name));
            }

            currentPlayerIndex = 0;
        }

        public void Start()
        {
            DealCards();

            while (!IsGameOver())
            {
                DisplayGameState();
                Player currentPlayer = players[currentPlayerIndex];
                Console.WriteLine($"Зараз черга гравця: {currentPlayer.Name}");
                PrintAllCards(currentPlayer);

                Console.Write("Введіть «1», щоб спочатку взяти картку, в іншому разі одразу перейти до скидання карт:");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    currentPlayer.DrawCard(players[(currentPlayerIndex + 1) % players.Count]);
                    PrintAllCards(currentPlayer);
                    Console.Write("Введіть '-1', щоб пропустити хід:");
                    input = Console.ReadLine();
                }
                if (input != "-1")
                {
                    bool isCorrect;
                    int index1;
                    int index2;
                    do
                    {
                        Console.Write("Введіть номер карт, які ви хочете скинути(спочатку карту з меншим номером):");
                        index1 = int.Parse(Console.ReadLine());
                        index2 = int.Parse(Console.ReadLine());

                        if (currentPlayer.Hand[index1].Rank != currentPlayer.Hand[index2].Rank)
                        {
                            Console.WriteLine("Карти мають бути однакового рангу, спробуйте знову");
                            isCorrect = false;
                        }
                        else if (currentPlayer.Hand[index1].Suit == Suit.Spades && currentPlayer.Hand[index1].Rank == Rank.Queen || currentPlayer.Hand[index2].Suit == Suit.Spades && currentPlayer.Hand[index2].Rank == Rank.Queen)
                        {
                            Console.WriteLine("Не можна скидати пікову даму, або вона наведе порчу, спробуйте знову");
                            isCorrect = false;
                        }
                        else
                        {
                            isCorrect = true;
                        }
                    } while (isCorrect == false);
                    currentPlayer.Discard(new List<Card> { currentPlayer.Hand[index1] });
                    currentPlayer.Discard(new List<Card> { currentPlayer.Hand[index2 - 1] });
                }

                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            }

            DisplayWinner();
        }

        private void PrintAllCards(Player player)
        {
            Console.WriteLine("Список карт:");
            for (int i = 0; i < player.Hand.Count; i++)
            {
                Console.WriteLine($"{i}: {player.Hand[i]}");
            }
        }

        private void DealCards()
        {
            int numCardsPerPlayer = deck.Cards.Count / players.Count;
            for (int i = 0; i < players.Count; i++)
            {
                List<Card> hand = deck.Deal(numCardsPerPlayer);
                players[i].Hand.AddRange(hand);
            }
        }

        private bool IsGameOver()
        {
            int count1 = 0;

            foreach (Player player in players)
            {
                
                if (player.Hand.Count != 0)
                {
                    ++count1;
                }              
            }
            if (count1 == 1)
            {
                return true;
            }
                  
            return false;
        }

        private void DisplayGameState()
        {
            Console.WriteLine();
            Console.WriteLine("-----------");
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name}: {player.Hand.Count} карт");
            }
            Console.WriteLine("-----------");
            Console.WriteLine();
        }

        private void DisplayWinner()
        {
            Player lox = null;
            int count1 = 0;

            foreach (Player player in players)
            {

                if (player.Hand.Count != 0)
                {
                    ++count1;
                    lox = player;
                }
            }
            if (count1 == 1)
            {
                Console.WriteLine($"Кінець гри! Програє: {lox.Name}!");
            }
        }
    }
}
