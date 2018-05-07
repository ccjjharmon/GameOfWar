using cardgame_war;
using System;
using Xunit;

namespace tests
{
    public class CardValueCalculatorTest
    {
        [Fact]
        public void ValidFace()
        {
            Assert.Equal(11, CardValueCalculator.GetFor(Face.Jack));
            Assert.Equal(12, CardValueCalculator.GetFor(Face.Queen));
            Assert.Equal(13, CardValueCalculator.GetFor(Face.King));
            Assert.Equal(14, CardValueCalculator.GetFor(Face.Ace));
        }

        [Theory]
        [InlineData(1, 2, Winner.Player2), InlineData(3, 2, Winner.Player1), InlineData(4, 1, Winner.Player1), InlineData(5, 9, Winner.Player2), InlineData(9, 9, Winner.Tie)]
        [InlineData(7, 7, Winner.Tie), InlineData(6, 7, Winner.Player2), InlineData(2, 10, Winner.Player2), InlineData(10, 9, Winner.Player1), InlineData(10, 10, Winner.Tie)]
        public void WhoWonNonFaceCards(int card1Num, int card2Num, Winner winner)
        {
            ICard card1 = new Card(card1Num, Suit.Heart);
            ICard card2 = new Card(card2Num, Suit.Heart);
            Assert.Equal(winner, CardValueCalculator.WhoWon(card1, card2));
        }


        [Theory]
        [InlineData(Face.Jack, Face.Queen, Winner.Player2), InlineData(Face.King, Face.Queen, Winner.Player1), InlineData(Face.Ace, Face.Jack, Winner.Player1)]
        [InlineData(Face.King, Face.Ace, Winner.Player2), InlineData(Face.Jack, Face.Jack, Winner.Tie), InlineData(Face.King, Face.King, Winner.Tie)]
        public void WhoWonFaceCards(Face card1Face, Face card2Num, Winner winner)
        {
            ICard card1 = new FaceCard(card1Face, Suit.Heart);
            ICard card2 = new FaceCard(card2Num, Suit.Heart);
            Assert.Equal(winner, CardValueCalculator.WhoWon(card1, card2));
        }

    }
}
