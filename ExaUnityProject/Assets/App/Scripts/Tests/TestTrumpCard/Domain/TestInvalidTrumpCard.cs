using System.Collections;
using App.Domain.TrumpCard;
using App.Domain.TrumpCard.Data;
using App.Domain.TrumpCard.Model;
using NUnit.Framework;

namespace Test.TestTrumpCard.Domain
{
    public class TestInvalidTrumpCard
    {
        [Test]
        public void InvalidSuit()
        {
            var ex = Assert.Throws<System.ArgumentException>(() =>
            {
                var trumpCard = new TrumpCard((CardSuit)5, 1, 1, 1);
            });
            Assert.AreEqual("Suitの値に不正があります。suit: 5", ex.Message);
            
            ex = Assert.Throws<System.ArgumentException>(() =>
            {
                var trumpCard = new TrumpCard((CardSuit)(-1), 1, 1, 1);
            });
            
            Assert.AreEqual("Suitの値に不正があります。suit: -1", ex.Message);
        }

        [Test]
        public void InvalidNumber()
        {
            var ex = Assert.Throws<System.ArgumentException>(() =>
            {
                var trumpCard = new TrumpCard(CardSuit.Spade, 0, 1, 1);
            });
            Assert.AreEqual("カードの数字に不正があります。number: 0", ex.Message);
            
            ex = Assert.Throws<System.ArgumentException>(() =>
            {
                var trumpCard = new TrumpCard(CardSuit.Spade, 14, 1, 1);
            });
            
            Assert.AreEqual("カードの数字に不正があります。number: 14", ex.Message);
        }

        [Test]
        public void InvalidSuitStrength()
        {
            var ex = Assert.Throws<System.ArgumentException>(() =>
            {
                var trumpCard = new TrumpCard(CardSuit.Spade, 1, 0, 1);
            });
            Assert.AreEqual("Suitの強さが1から4の範囲外です。SuitStrength: 0", ex.Message);
            
            ex = Assert.Throws<System.ArgumentException>(() =>
            {
                var trumpCard = new TrumpCard(CardSuit.Spade, 1, 5, 1);
            });
            Assert.AreEqual("Suitの強さが1から4の範囲外です。SuitStrength: 5", ex.Message);
        }
        
        [Test]
        public void InvalidNumberStrength()
        {
            var ex = Assert.Throws<System.ArgumentException>(() =>
            {
                var trumpCard = new TrumpCard(CardSuit.Spade, 1, 1, 0);
            });
            Assert.AreEqual("数字の強さが1から13の範囲外です。1", ex.Message);
            
            ex = Assert.Throws<System.ArgumentException>(() =>
            {
                var trumpCard = new TrumpCard(CardSuit.Spade, 1, 1, 14);
            });
            Assert.AreEqual("数字の強さが1から13の範囲外です。1", ex.Message);
        }
    }
}
