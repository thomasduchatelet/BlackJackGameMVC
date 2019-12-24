using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackGame.Models
{
    public class Deck
    {
        #region Fields
        protected IList<BlackJackCard> _cards;
        private Random _random = new Random();
        #endregion

        #region Constructors
        public Deck()
        {
            _cards = new List<BlackJackCard>();
            foreach (var s in Enum.GetValues(typeof(Suit)))
                foreach (var f in Enum.GetValues(typeof(FaceValue)))
                    _cards.Add(new BlackJackCard((Suit)s, (FaceValue)f));
            Shuffle();
        }
        #endregion

        #region Methods
        public BlackJackCard Draw()
        {
            if (_cards.Count != 0)
            {
                BlackJackCard firstCard = _cards[0];
                _cards.Remove(firstCard);
                return firstCard;
            }
            else
                throw new InvalidOperationException();
        }

        private void Shuffle()
        {
            _cards = _cards.OrderBy(c => _random.Next()).ToList();
        }
        #endregion
    }
}
