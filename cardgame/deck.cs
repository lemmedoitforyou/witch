using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardgame
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();

        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public List<Card> Cards
        {
            get { return cards; }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public List<Card> Deal(int numCards)
        {
            List<Card> hand = cards.GetRange(0, numCards);
            cards.RemoveRange(0, numCards);
            return hand;
        }
    }

}
