using cardgame_war;
using System.Collections.Generic;

namespace core
{
    public interface IPlayer
    {
        Stack<ICard> Cards();
        void Accept(ICard card);
        ICard Show();
        void WinHand(ICard card1, ICard card2);
        void WinWar(ICard card1a, ICard card1b, ICard card1c, ICard card1d, ICard card2a, ICard card2b, ICard card2c, ICard card2d);
    }
}
