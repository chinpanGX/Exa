using System;
using System.Collections.Generic;
using App.Domain.TrumpCard.Data;
using App.Domain.TrumpCard.Model;
using TrumpCardModel = App.Domain.TrumpCard.Model.TrumpCard;

namespace App.Domain.Deck
{
    public class Deck
    { 
        private readonly List<TrumpCardModel> cards;
        
        public static Deck CreatePokerDeck()
        {
            var cards = new List<TrumpCardModel>();
            for (var i = TrumpConstData.MinCardNumber; i <= TrumpConstData.MaxCardNumber; i++)
            {
                for (var j = 0; j < TrumpConstData.MaxCardSuit; j++)
                {
                    cards.Add(TrumpCardModel.CreateForPokerRule((CardSuit)j, i));
                }
            }
            
            return new Deck(cards);
        }
        
        private Deck(List<TrumpCardModel> cards)
        {
            this.cards = cards;
            cards.Shuffle();
        }
    }
}