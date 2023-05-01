using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardgame
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public void DrawCard(Player other)
        {
            Hand.Add(other.Hand[0]); // зробити рандом
            other.Hand.RemoveAt(0);
        }

        public void Discard(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Hand.Remove(card);
            }
        }
    }
}
