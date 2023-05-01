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

        public Deck(int numberOfPlayers)
        {
            if (numberOfPlayers >= 4)
            {
                cards = new List<Card>();
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        cards.Add(new Card(suit, rank));
                    }
                }
            }
            else
            {
                cards = new List<Card>();
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    if (rank <= Rank.Six)
                    {
                        continue;
                    }
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        cards.Add(new Card(suit, rank));
                    }
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
