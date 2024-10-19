using System;
using System.Collections.Generic;
using App.Domain.TrumpCard.Data;
using App.Domain.TrumpCard.Model;

namespace App.Domain.Deck
{
    public abstract class Deck
    { 
        protected readonly List<Card> Cards;
        
        protected Deck(List<Card> cards)
        {
            Cards = cards;
            cards.Shuffle();
        }
    }


    public class PlayerDeck : Deck, IDrawable, IExchangeable
    {
        public PlayerDeck(List<Card> cards) : base(cards)
        {
            if(cards.Count != PokerConstData.MaxHandCardCount)
                throw new ArgumentException($"PlayerDeckは{PokerConstData.MaxHandCardCount}枚のカードでなければなりません。");
        }
        
        public Card Draw()
        {
            if (Cards.Count == 0)
                throw new InvalidOperationException("Deck is empty.");
            
            
            var card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
        
        public void Exchange(Card card)
        {
            Cards.Add(card);
        }
    }
}