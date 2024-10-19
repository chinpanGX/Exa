namespace App.Domain.Deck
{
    public interface IDrawable
    {
        TrumpCard.Model.Card Draw();
    }
}