using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackGame.Models
{
    public class Hand
    {
        #region Fields
        private readonly IList<BlackJackCard> _cards;
        #endregion

        #region Properties
        public IEnumerable<BlackJackCard> Cards { get { return _cards; } }
        public int NrOfCards {
            get { return _cards.Count; } }
        public int Value { get { return CalculateValue(); } }
        #endregion

        #region Constructors
        public Hand()
        {
            _cards = new List<BlackJackCard>();
        }
        #endregion

        #region Methods

        private int CalculateValue()
        {
            int value = 0;
            int tempValue;
            int nrOfAces = 0;
            foreach (var c in Cards)
            {
                if (c.FaceValue != FaceValue.Ace)
                    value += c.Value;
                else if(c.FaceUp)
                    nrOfAces++;
            }

            tempValue = value;

            for (int i = 0; i < nrOfAces; i++)
            {
                if (value > 10)
                    value++;
                else
                    value += 11;
            }

            if (value > 21)
                value = tempValue + nrOfAces;

            return value;

        }
        public void AddCard(BlackJackCard blackJackCard)
        {
            _cards.Add(blackJackCard);
        }

        public void TurnAllCardsFaceUp()
        {
            foreach (var c in Cards)
                c.FaceUp = true;
        }
        #endregion
    }
}