using App.Domain.TrumpCard.Data;

namespace App.Domain.TrumpCard
{
    public class TrumpCard
    {
        public readonly CardSuit Suit;
        public readonly int Number;
        public readonly int NumberStrength;
        public readonly int SuitStrength;
        
        public TrumpCard(CardSuit suit, int number)
        {
            Suit = suit;
            Number = number;
            
            if(Suit < CardSuit.Spade || Suit > CardSuit.Club)
                throw new System.ArgumentOutOfRangeException(nameof(suit), "Invalid suit");
            
            SuitStrength = Suit switch
            {
                CardSuit.Spade => 4,
                CardSuit.Heart => 3,
                CardSuit.Diamond => 2,
                CardSuit.Club => 1,
                _ => throw new System.ArgumentOutOfRangeException(nameof(suit), "Invalid suit")
            };
            
            if(SuitStrength <= 0 || SuitStrength > TrumpConstData.MaxCardSuit)
                throw new System.ArgumentOutOfRangeException(nameof(suit), "Invalid suit strength");
            
            if(Number < TrumpConstData.MinCardNumber || Number > TrumpConstData.MaxCardNumber)
                throw new System.ArgumentOutOfRangeException(nameof(number), "Invalid number");

            NumberStrength = Number - TrumpConstData.MinCardNumber;
            if (Number == 1)
                NumberStrength = TrumpConstData.MaxCardNumber;
            
            if(NumberStrength <= 0 || NumberStrength > TrumpConstData.MaxCardNumber)
                throw new System.ArgumentOutOfRangeException(nameof(number), "Invalid number strength");
            
        }
    }
}
