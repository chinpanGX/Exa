using System.Collections.Generic;
using App.Domain.TrumpCard.Data;

namespace App.Domain.Deck
{
    public class DeckFactory
    {
        public static List<TrumpCard.Model.Card> CreatePokerDeck()
        {
            var cards = new List<TrumpCard.Model.Card>();
            for (var i = TrumpConstData.MinCardNumber; i <= TrumpConstData.MaxCardNumber; i++)
            {
                for (var j = 0; j < TrumpConstData.MaxCardSuit; j++)
                {
                    cards.Add(TrumpCard.Model.Card.CreateForPokerRule((CardSuit)j, i));
                }
            }

            return cards;
        }
    }
}