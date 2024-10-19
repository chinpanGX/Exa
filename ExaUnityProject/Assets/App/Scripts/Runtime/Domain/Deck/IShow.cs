using System.Collections.Generic;

namespace App.Domain.Deck
{
    public interface IShow
    {
        IList<TrumpCard.Model.Card> Show();
    }
}