﻿using System;
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
            deck = new Deck();
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

                Console.Write("Введіть '1', щоб спочатку взяти картку, в іншому разі одразу перейти до скидання карт:");
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
                    Console.Write("Введіть номер карт, які ви хочете скинути:");
                    int index1 = int.Parse(Console.ReadLine());
                    int index2 = int.Parse(Console.ReadLine());
                    currentPlayer.Discard(new List<Card> { currentPlayer.Hand[index1] });
                    currentPlayer.Discard(new List<Card> { currentPlayer.Hand[index2] });
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
            Console.WriteLine();
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
            foreach (Player player in players)
            {
                if (player.Hand.Count == 0)
                {
                    return true;
                }
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
            Player winner = null;
            foreach (Player player in players)
            {
                if (player.Hand.Count == 0)
                {
                    winner = player;
                    break;
                }
            }

            Console.WriteLine($"Кінець гри! Виграє гравець: {winner.Name}!");
        }

    }

}