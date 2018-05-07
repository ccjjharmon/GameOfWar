using cardgame_war;
using core;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace tests
{
    public class GameOfWarTest
    {

        [Fact]
        public void PassOutCards_PlayerAcceptACard()
        {
            Mock<IPlayer> player1 = new Mock<IPlayer>();
            player1.Setup(p => p.Accept(It.IsAny<ICard>()));
            Mock<IPlayer> player2 = new Mock<IPlayer>();
            player2.Setup(p => p.Accept(It.IsAny<ICard>()));
            var sut = new GameOfWar(player1.Object, player2.Object);

            sut.PassOutCards();

            player1.Verify(p => p.Accept(It.IsAny<ICard>()), Times.Exactly(26));
            player2.Verify(p => p.Accept(It.IsAny<ICard>()), Times.Exactly(26));
        }

        [Fact]
        public void Play_BothPlayersShowACard()
        {
            Mock<IPlayer> player1 = new Mock<IPlayer>();
            player1.Setup(p => p.Cards()).Returns(new Stack<ICard>());
            Mock<IPlayer> player2 = new Mock<IPlayer>();
            player2.Setup(p => p.Cards()).Returns(new Stack<ICard>());
            var sut = new GameOfWar(player1.Object, player2.Object);

            sut.Play();

            player1.Verify(p => p.Show(), Times.Once());
            player2.Verify(p => p.Show(), Times.Once());
        }

        [Fact]
        public void Play_Player1WinsRoundGetsBothCards()
        {
            var card1Value = 9;
            var card2Value = 2;

            Mock<IDeck> deck = new Mock<IDeck>();
            Mock<ICard> card1 = new Mock<ICard>();
            card1.Setup(c => c.Value()).Returns(card1Value);
            Mock<ICard> card2 = new Mock<ICard>();
            card2.Setup(c => c.Value()).Returns(card2Value);
            deck.Setup(d => d.TakeACard()).Returns<ICard>(null);
            deck.Setup(d => d.Cards()).Returns(new List<ICard>());
            Mock<IPlayer> player1 = new Mock<IPlayer>();
            player1.Setup(p => p.Cards()).Returns(new Stack<ICard>());
            player1.Setup(p => p.Show()).Returns(card1.Object);
            player1.Setup(p => p.Accept(It.IsAny<ICard>()));
            Mock<IPlayer> player2 = new Mock<IPlayer>();
            player2.Setup(p => p.Cards()).Returns(new Stack<ICard>());
            player2.Setup(p => p.Show()).Returns(card2.Object);
            player2.Setup(p => p.Accept(It.IsAny<ICard>()));
            var sut = new GameOfWar(player1.Object, player2.Object);

            sut.Play();

            player1.Verify(p => p.WinHand(card1.Object, card2.Object), Times.Once());
        }

        [Fact]
        public void Play_Player2WinsRoundGetsBothCards()
        {
            var card1Value = 9;
            var card2Value = 13;

            Mock<IDeck> deck = new Mock<IDeck>();
            Mock<ICard> card1 = new Mock<ICard>();
            card1.Setup(c => c.Value()).Returns(card1Value);
            Mock<ICard> card2 = new Mock<ICard>();
            card2.Setup(c => c.Value()).Returns(card2Value);
            deck.Setup(d => d.TakeACard()).Returns<ICard>(null);
            deck.Setup(d => d.Cards()).Returns(new List<ICard>());
            Mock<IPlayer> player1 = new Mock<IPlayer>();
            player1.Setup(p => p.Cards()).Returns(new Stack<ICard>());
            player1.Setup(p => p.Show()).Returns(card1.Object);
            player1.Setup(p => p.Accept(It.IsAny<ICard>()));
            Mock<IPlayer> player2 = new Mock<IPlayer>();
            player2.Setup(p => p.Cards()).Returns(new Stack<ICard>());
            player2.Setup(p => p.Show()).Returns(card2.Object);
            player2.Setup(p => p.Accept(It.IsAny<ICard>()));
            var sut = new GameOfWar(player1.Object, player2.Object);

            sut.Play();

            player2.Verify(p => p.WinHand(card1.Object, card2.Object), Times.Once());
        }

        [Fact]
        public void Play_TieThenWar()
        {
            var initialTieCardValue = 2;
            var card1Value = 9;
            var card2Value = 8;

            Mock<ICard> card1Initial = new Mock<ICard>(), card2Initial = new Mock<ICard>();
            Mock<ICard> card1a = new Mock<ICard>(), card1b = new Mock<ICard>(), card1c = new Mock<ICard>(), card1d = new Mock<ICard>();
            Mock<ICard> card2a = new Mock<ICard>(), card2b = new Mock<ICard>(), card2c = new Mock<ICard>(), card2d = new Mock<ICard>();
            card1Initial.Setup(c => c.Value()).Returns(initialTieCardValue);
            card2Initial.Setup(c => c.Value()).Returns(initialTieCardValue);
            card1d.Setup(c => c.Value()).Returns(card1Value);
            card2d.Setup(c => c.Value()).Returns(card2Value);

            var cards1 = new Queue<ICard>();
            cards1.Enqueue(card1Initial.Object); cards1.Enqueue(card1a.Object); cards1.Enqueue(card1b.Object);
            cards1.Enqueue(card1c.Object); cards1.Enqueue(card1d.Object);
            var cards2 = new Queue<ICard>();
            cards2.Enqueue(card2Initial.Object); cards2.Enqueue(card2a.Object); cards2.Enqueue(card2b.Object);
            cards2.Enqueue(card2c.Object); cards2.Enqueue(card2d.Object);

            Mock<IPlayer> player1 = new Mock<IPlayer>(), player2 = new Mock<IPlayer>();
            player1.Setup(p => p.Cards()).Returns(new Stack<ICard>());
            player2.Setup(p => p.Cards()).Returns(new Stack<ICard>());
            player1.Setup(p => p.Accept(It.IsAny<ICard>()));
            player2.Setup(p => p.Accept(It.IsAny<ICard>()));
            player1.Setup(p => p.Show()).Returns(cards1.Dequeue);
            player2.Setup(p => p.Show()).Returns(cards2.Dequeue);

            var sut = new GameOfWar(player1.Object, player2.Object);

            sut.Play();

            player1.Verify(p => p.WinHand(card1Initial.Object, card2Initial.Object), Times.Once());
            player1.Verify(p => p.WinWar(card1a.Object, card1b.Object, card1c.Object, card1d.Object,
                card2a.Object, card2b.Object, card2c.Object, card2d.Object ), Times.Once());
        }

    }
}
