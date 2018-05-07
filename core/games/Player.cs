using cardgame_war;
using System;
using System.Collections.Generic;

namespace core
{
    public class Player: IPlayer
    {
        public Stack<ICard> _cards;
        private string _name;

        public Player(string name)
        {
            _name = name;
            _cards = new Stack<ICard>();
        }

        public void Accept(ICard card)
        {
            _cards.Push(card);
        }

        public Stack<ICard> Cards()
        {
            return _cards;
        }

        public ICard Show()
        {
            if(_cards.Count > 0) return _cards.Pop();
            return null;
        }
        public void WinHand(ICard card1, ICard card2)
        {
            Accept(card1);
            Accept(card2);
        }
        public void WinWar(ICard card1a, ICard card1b, ICard card1c, ICard card1d, ICard card2a, ICard card2b, ICard card2c, ICard card2d)
        {
            Accept(card1a);
            Accept(card1b);
            Accept(card1c);
            Accept(card1d);
            Accept(card2a);
            Accept(card2b);
            Accept(card2c);
            Accept(card2d);
        }

        public override string ToString()
        {
            return _name;
        }
}
}
