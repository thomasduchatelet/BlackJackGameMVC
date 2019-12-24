using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    public class BlackJack
    {
        #region Fields
        private Deck _deck;
        public const bool FaceDown = false;
        public const bool FaceUp = true;
        #endregion

        #region Properties
        public GameState GameState { get; set; }
        public Hand DealerHand { get; set; }
        public Hand PlayerHand { get; set; }
        #endregion

        #region Constructors
        public BlackJack() 
        {
            _deck = new Deck();
            initGame();
        }
        
        public BlackJack(Deck deck)
        {
            this._deck = deck;
            initGame();
        }
        #endregion

        #region Methods

        private void initGame()
        {
            DealerHand = new Hand();
            PlayerHand = new Hand();
            Deal();
            if (PlayerHand.Value != 21)
                GameState = GameState.PlayerPlays;
            else
                GameState = GameState.GameOver;
        }
        private void AddCardToHand(Hand hand, bool faceUp)
        {
            BlackJackCard card = _deck.Draw();
            card.FaceUp = faceUp;
            hand.AddCard(card);
        }

        private void AdjustGameState(GameState? gameState = null)
        {
            if (gameState != null)
                GameState = (GameState)gameState;
            if (DealerHand.Value >= PlayerHand.Value || DealerHand.Value > 21 || PlayerHand.Value >= 21)
                GameState = GameState.GameOver;

        }

        private void Deal() 
        {
            AddCardToHand(DealerHand, true);
            AddCardToHand(DealerHand, false);
            AddCardToHand(PlayerHand, true);
            AddCardToHand(PlayerHand, true);
        }

        private void LetDealerFinalize()
        {
            while (GameState != GameState.GameOver)
            {
                AddCardToHand(DealerHand, true);
                AdjustGameState();
            }
        }

        public string GameSummary()
        {
            if (!GameState.Equals(GameState.GameOver))
                return null;
            else if (PlayerHand.Value == 21)
                return "BLACKJACK";
            else if (PlayerHand.Value > 21)
                return "Player burned, dealer wins";
            else if (DealerHand.Value > 21)
                return "Dealer burned, player wins";
            else if (DealerHand.Value == PlayerHand.Value)
                return "Equal, dealer wins";
            else if (DealerHand.Value > PlayerHand.Value)
                return "Dealer wins";
            else if (PlayerHand.Value > DealerHand.Value)
                return "Player wins";
            return null;
        }

        public void GivePlayerAnotherCard()
        {
            if (GameState != GameState.PlayerPlays)
                throw new InvalidOperationException();
            AddCardToHand(PlayerHand, true);
            if (PlayerHand.Value >= 21)
                AdjustGameState();
        }

        public void PassToDealer()
        {
            AdjustGameState(GameState.DealerPlays);
            DealerHand.TurnAllCardsFaceUp();
            AdjustGameState();
            LetDealerFinalize();          
        }
        #endregion

    }
}
