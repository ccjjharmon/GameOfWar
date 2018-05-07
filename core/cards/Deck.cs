using cardgame_war;
using core;
using System;
using System.Collections.Generic;
using System.Linq;

public class Deck : IDeck
{
    public IList<ICard> _cards;

    public Deck()
    {        
        //setup cards
        _cards = new List<ICard>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            // start at 2... and go for 8 more #s (to 10)
            foreach (int index in Enumerable.Range(2, 9))
            {
                _cards.Add(new Card(index, suit));
            }
            foreach (Face face in Enum.GetValues(typeof(Face)))
            {
                _cards.Add(new FaceCard(face, suit));
            }
        }       
    }

    public IList<ICard> Cards()
    {
        return _cards;
    }

    public void Shuffle()
    {
        Shuffler.Shuffle(_cards);
    }
    public ICard TakeACard()
    {
        var card = _cards.First();
        _cards.Remove(card);
        return card;
    }

}
