using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardgame
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }
    public class Card
    {
        public Suit Suit { get; set; }
        public int Value { get; set; }
        public Card(Suit suit, int value)
        {
            Suit = suit;
            Value = value;
        }
        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
