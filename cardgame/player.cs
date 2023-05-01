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

            if (other.Hand.Count > 0)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(0, other.Hand.Count);
                Hand.Add(other.Hand[randomIndex]);
                other.Hand.RemoveAt(randomIndex);
            }
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
