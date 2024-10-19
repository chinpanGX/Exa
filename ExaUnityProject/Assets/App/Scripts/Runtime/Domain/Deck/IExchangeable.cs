namespace App.Domain.Deck
{
    public interface IExchangeable
    {
        void Exchange(TrumpCard.Model.Card card);
    }
}