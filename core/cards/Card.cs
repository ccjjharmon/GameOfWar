using cardgame_war;

public enum Suit
{
    Spade,
    Heart,
    Diamond,
    Club
}

public class Card : ICard
{
    private int _number;
    private Suit _suit;

    public Card(int number, Suit suit) {
        _number = number;
        _suit = suit;
    }

    public virtual int Number() { return _number; }

    public virtual Suit Suit() { return _suit; }

    public virtual int Value()
    {
        return _number;
    }

    public override string ToString()
    {
        return Number().ToString() + Suit().ToFriendlyString();
    }

}

public static class SuitExtensions
{
    public static string ToFriendlyString(this Suit me)
    {
        switch (me)
        {
            case Suit.Club:
                return "♣";
            case Suit.Heart:
                return "♥";
            case Suit.Diamond:
                return "♦";
            case Suit.Spade:
                return "♠";
            default:
                return "?";
        }
    }
}