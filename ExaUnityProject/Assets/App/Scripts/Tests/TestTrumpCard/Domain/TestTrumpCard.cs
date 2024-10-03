using System.Collections;
using App.Domain.TrumpCard;
using App.Domain.TrumpCard.Data;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Test.TestTrumpCard.Domain
{
    public class TestTrumpCard
    {
        
        [Test]
        public void TestSuccessTrumpCard()
        {
            for(int number = TrumpConstData.MinCardNumber; number <= TrumpConstData.MaxCardNumber; number++)
            {
                for(int suit = 0; suit < TrumpConstData.MaxCardSuit; suit++)
                {
                    var trumpCard = new TrumpCard((CardSuit)suit, number);
                    Assert.AreEqual(number, trumpCard.Number);
                    Assert.AreEqual((CardSuit)suit, trumpCard.Suit);
                    if (number == 1)
                    {
                        Assert.AreEqual(TrumpConstData.MaxCardNumber, trumpCard.NumberStrength);
                    }
                    else
                    {
                        Assert.AreEqual(number - TrumpConstData.MinCardNumber, trumpCard.NumberStrength);   
                    }
                    Assert.AreEqual(TrumpConstData.MaxCardSuit - suit, trumpCard.SuitStrength);
                }
            }
        }
    }
}
