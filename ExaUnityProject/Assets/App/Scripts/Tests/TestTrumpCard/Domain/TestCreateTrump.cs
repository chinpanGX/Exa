using System;
using System.Collections.Generic;
using App.Domain.TrumpCard.Data;
using App.Domain.TrumpCard.Model;
using NUnit.Framework;


namespace Test.TestTrumpCard.Domain
{
    public class TestCreateTrump
    {
        [Test]
        public void CreateForPokerRule()
        {
            var deck = new List<TrumpCard>();
            // トランプのカードを生成、整合性をチェック、デッキに追加
            for(int number = TrumpConstData.MinCardNumber; number <= TrumpConstData.MaxCardNumber; number++)
            {
                for(int suit = 0; suit < TrumpConstData.MaxCardSuit; suit++)
                {
                    var trumpCard = TrumpCard.CreateForPokerRule((CardSuit)suit, number);
                    
                    Assert.AreEqual(number, trumpCard.Number);
                    Assert.AreEqual((CardSuit)suit, trumpCard.Suit);
                    // 数字の強さの確認
                    if (number == 1)
                    {
                        Assert.AreEqual(TrumpConstData.MaxCardNumber, trumpCard.NumberStrength);
                    }
                    else
                    {
                        Assert.AreEqual(number - TrumpConstData.MinCardNumber, trumpCard.NumberStrength);   
                    }
                    Assert.AreEqual(TrumpConstData.MaxCardSuit - suit, trumpCard.SuitStrength);
                    
                    deck.Add(trumpCard);
                }
            }
            
            // 生成されたデッキの整合性チェック
            Assert.AreEqual(52, deck.Count);
            var spadeCards = deck.FindAll(card => card.Suit == CardSuit.Spade);
            foreach (var spadeCard in spadeCards)
            {
                Assert.AreEqual(4, spadeCard.SuitStrength);
            }
            
            var heartCards = deck.FindAll(card => card.Suit == CardSuit.Heart);
            foreach (var heartCard in heartCards)
            {
                Assert.AreEqual(3, heartCard.SuitStrength);
            }
            
            var diamondCards = deck.FindAll(card => card.Suit == CardSuit.Diamond);
            foreach (var diamondCard in diamondCards)
            {
                Assert.AreEqual(2, diamondCard.SuitStrength);
            }
            
            var clubCards = deck.FindAll(card => card.Suit == CardSuit.Club);  
            foreach (var clubCard in clubCards)
            {
                Assert.AreEqual(1, clubCard.SuitStrength);
            }
        }
    }
}
