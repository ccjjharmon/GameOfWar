using cardgame_war;
using System;
using Xunit;

namespace tests
{
    public class FaceCardTest
    {
        private FaceCard sut;

        [Fact]
        public void ValidFace()
        {
            var face = Face.King;
            sut = new FaceCard(face, Suit.Heart);

            Assert.Equal(face, sut.Face());
        }

        [Fact]
        public void ValidCardValue()
        {
            var face = Face.Jack;
            sut = new FaceCard(face, Suit.Heart);
            var expected = CardValueCalculator.GetFor(face); //probably should mock

            Assert.Equal(expected, sut.Value());
        }

    }
}
