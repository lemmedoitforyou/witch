using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardgame
{
    public static class DeckCreator
    {

        private static Queue<Card> Shuffle(Queue<Card> cards)
        {
            List<Card> transformedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);

                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Queue<Card> shuffledCards = new Queue<Card>();
            foreach (var card in transformedCards)
            {
                shuffledCards.Enqueue(card);
            }

            return shuffledCards;
        }
        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();
            for (int i = 2; i <= 14; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Enqueue(new Card()
                    {
                        Suit = suit,
                        Value = i,
                    });
                }
            }
            return Shuffle(cards);
        }
    }
}
