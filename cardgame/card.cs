using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardgame
{
    // зробити можливість зміни кількості карт від 32 до 52 в залежності від кількості гравців
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Rank
    {
        //Two = 2,
        //Three,
        //Four,
        //Five,
        Six,
        //Seven,
        //Eight,
        //Nine,
        //Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Suit} - {Rank}" ;
        }
    }

}
