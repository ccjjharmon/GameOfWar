using cardgame_war;
using System.Collections.Generic;

public interface IDeck
{
    IList<ICard> Cards();
    void Shuffle();
    ICard TakeACard();

}
