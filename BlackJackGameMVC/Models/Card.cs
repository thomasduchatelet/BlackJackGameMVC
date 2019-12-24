using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Card
    {
        [JsonProperty]
        public FaceValue FaceValue { get; }
        [JsonProperty]
        public Suit Suit { get; }
        [JsonProperty]
        public int CardNr => (((int)Suit - 1) * 13) + (int)FaceValue - 1;

        public Card(Suit suit, FaceValue faceValue)
        {
            Suit = suit;
            FaceValue = faceValue;
        }
    }
}
