using cardgame_war;
using System;

public enum Winner
{
    Tie,
    Player1,
    Player2
}

public class CardValueCalculator
{
    public static int GetFor(Face face)
    {
        switch(face)
        {
            case Face.Jack: return 11;
            case Face.Queen: return 12;
            case Face.King: return 13;
            case Face.Ace: return 14;
        }
        throw new NotSupportedException("no valid face");
    }

    public static Winner WhoWon(ICard card1, ICard card2)
    {
        if (card1.Value() > card2.Value())
        {
            return Winner.Player1;
        }
        else if (card2.Value() > card1.Value())
        {
            return Winner.Player2;
        }
        else 
        {
            return Winner.Tie;
        }
    }
}
