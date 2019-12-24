using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    public class Card
    {
        public FaceValue FaceValue { get; }
        public Suit Suit { get; }

        public Card(Suit suit, FaceValue faceValue)
        {
            Suit = suit;
            FaceValue = faceValue;
        }
    }
}
