namespace cardgame_war
{

    public interface ICard
    {
        Suit Suit();
        int Number();
        int Value();
    }

}