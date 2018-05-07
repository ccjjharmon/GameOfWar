using cardgame_war;
using System;
using Xunit;

namespace tests
{
    public class CardTest
    {
        private ICard sut;

        [Fact]
        public void ValidNumber()
        {
            var number = 1;
            sut = new Card(number, Suit.Heart);

            Assert.Equal(number, sut.Number());
        }

        [Fact]
        public void ValidSuit()
        {
            var suit = Suit.Diamond;
            sut = new Card(2, suit);

            Assert.Equal(suit, sut.Suit());
        }

        [Fact]
        public void ValidCardValue()
        {
            var number = 8;
            sut = new Card(number, Suit.Heart);

            Assert.Equal(number, sut.Value());
        }

    }
}
