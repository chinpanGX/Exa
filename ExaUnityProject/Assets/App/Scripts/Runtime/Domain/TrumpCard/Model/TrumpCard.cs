using System.Runtime.CompilerServices;
using App.Domain.TrumpCard.Data;
#if UNITY_EDITOR
[assembly: InternalsVisibleTo("Test.TestTrumpCard.Domain")]
#endif

namespace App.Domain.TrumpCard.Model
{
    public class TrumpCard
    {
        public readonly CardSuit Suit;
        public readonly int Number;
        public readonly int NumberStrength;
        public readonly int SuitStrength;
        
        /// <summary>
        /// ポーカーのルールに沿ったカードを生成する
        /// </summary>
        public static TrumpCard CreateForPokerRule(CardSuit suit, int number)
        {
            int suitStrength = suit switch
            {
                CardSuit.Spade => 4,
                CardSuit.Heart => 3,
                CardSuit.Diamond => 2,
                CardSuit.Club => 1,
                _ => throw new System.ArgumentOutOfRangeException(nameof(suit), "Invalid suit")
            };
            
            int numberStrength = number - TrumpConstData.MinCardNumber;
            if (number == 1)
                numberStrength = TrumpConstData.MaxCardNumber;
            
            return new TrumpCard(suit, number, suitStrength, numberStrength);
        }
        
        internal TrumpCard(CardSuit suit, int number, int suitStrength, int numberStrength)
        {
            Suit = suit;
            Number = number;
            SuitStrength = suitStrength;
            NumberStrength = numberStrength;
            
            if(Suit < CardSuit.Spade || Suit > CardSuit.Club)
                throw new System.ArgumentException($"Suitの値に不正があります。suit: {suit}");

            if (Number < TrumpConstData.MinCardNumber || Number > TrumpConstData.MaxCardNumber)
                throw new System.ArgumentException(message: $"カードの数字に不正があります。number: {number}");

            if (SuitStrength <= 0 || SuitStrength > TrumpConstData.MaxCardSuit)
                throw new System.ArgumentException($"Suitの強さが1から4の範囲外です。SuitStrength: {SuitStrength}");

            if (NumberStrength <= 0 || NumberStrength > TrumpConstData.MaxCardNumber)
                throw new System.ArgumentException($"数字の強さが1から13の範囲外です。{SuitStrength}");
        }
    }
}
