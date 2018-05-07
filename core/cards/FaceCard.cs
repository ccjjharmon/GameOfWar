using cardgame_war;

public enum Face
{
    Jack,
    Queen,
    King,
    Ace
}

public class FaceCard : Card
{
    private Face _face;

    public FaceCard(Face face, Suit suit) : base(1, suit) {
        _face = face;
    }

    public Face Face() { return _face; }

    public override int Value()
    {
        return CardValueCalculator.GetFor(_face);
    }
    public override string ToString()
    {
        return Face().ToFriendlyString() + Suit().ToFriendlyString();
    }

}

public static class FaceExtensions
{
    public static string ToFriendlyString(this Face me)
    {
        switch (me)
        {
            case Face.Jack:
                return "J";
            case Face.Queen:
                return "Q";
            case Face.King:
                return "K";
            case Face.Ace:
                return "A";
            default:
                return "?";
        }
    }
}