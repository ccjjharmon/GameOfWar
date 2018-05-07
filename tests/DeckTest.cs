using core;
using System.Linq;
using Xunit;

namespace tests
{
    public class DeckTest
    {
        private Deck sut = new Deck();

        [Theory]
        [InlineData(2, Suit.Spade),InlineData(3, Suit.Spade), InlineData(4, Suit.Spade), InlineData(5, Suit.Spade), InlineData(6, Suit.Spade)]
        [InlineData(7, Suit.Spade), InlineData(8, Suit.Spade), InlineData(9, Suit.Spade), InlineData(10, Suit.Spade)]
        public void FindSingleCard(int value, Suit suit)
        {
            var ICard = sut.Cards().Where(c => c.Number() == value && c.Suit() == suit).ToList();
            var ct = ICard.Count;
            Assert.Equal(1, ct);
        }

        [Theory]
        [InlineData(Suit.Club, 13), InlineData(Suit.Spade, 13), InlineData(Suit.Heart, 13), InlineData(Suit.Diamond, 13)]
        public void FindAllPuppyDogs(Suit suit, int totalCards)
        {
            var ICard = sut.Cards().Where(c => c.Suit() == suit).ToList();
            var ct = ICard.Count;
            Assert.Equal(totalCards, ct);
        }

        [Theory]
        [InlineData(11, Suit.Spade), InlineData(0, Suit.Heart)]
        public void CannotFindSingleCard(int value, Suit suit)
        {
            var ICard = sut.Cards().Where(c => c.Number() == value && c.Suit() == suit).ToList();
            var ct = ICard.Count;
            Assert.Equal(0, ct);
        }

        [Fact]
        public void Has52Cards()
        {
            var num = sut.Cards().Count;
            Assert.Equal(52, num);
        }

    }
}
