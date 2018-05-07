using cardgame_war;
using System;

namespace core
{
    public class GameOfWar : IGame
    {
        private IPlayer player1;
        private IPlayer player2;
        private IDeck deck;

        public GameOfWar(IPlayer p1, IPlayer p2)
        {
            player1 = p1;
            player2 = p2;

            deck = new Deck();
            deck.Shuffle();
        }

        public void PassOutCards()
        {
            IPlayer player = player1;
            int rounds = 1;
            do
            {
                rounds++;
                var card = deck.TakeACard();
                player = (rounds % 2 == 0) ? player1 : player2;
                player.Accept(card);
            } while (deck.Cards().Count > 0);
        }

        private IPlayer PlayRound(IPlayer player1, IPlayer player2)
        {
            IPlayer whoWon = null;
            var card1 = player1.Show();
            var card2 = player2.Show();
            if (card1 != null && card2 != null)
            {
                Console.Write(card1 + "/" + card2 + "...");
                switch (CardValueCalculator.WhoWon(card1, card2))
                {
                    case Winner.Player1:
                        whoWon = player1;
                        Console.Write("Player 1 won (" + player1.Cards().Count + "/" + player2.Cards().Count + ")! ");
                        break; 
                    case Winner.Player2:
                        whoWon = player2;
                        Console.Write("Player 2 won (" + player1.Cards().Count + "/" + player2.Cards().Count + ")! ");
                        break;
                    case Winner.Tie:
                        whoWon = PlayWar(player1, player2); //play war!
                        Console.Write("Tie! ");
                        break;
                }
                if (whoWon != null) { whoWon.WinHand(card1, card2); }
            }
            return whoWon;
        }

        private IPlayer PlayWar(IPlayer player1, IPlayer player2)
        {
            IPlayer whoWon = null;
            var card1a = player1.Show();
            var card1b = player1.Show();
            var card1c = player1.Show();
            var card1d = player1.Show();
            var card2a = player2.Show();
            var card2b = player2.Show();
            var card2c = player2.Show();
            var card2d = player2.Show();
            if (card1d != null && card2d != null)
            {
                Console.Write(card1a + "/" + card2a + " | ");
                Console.Write(card1b + "/" + card2b + " | ");
                Console.Write(card1c + "/" + card2c + " | ");
                Console.Write(card1d + "/" + card2d + "...");
                switch (CardValueCalculator.WhoWon(card1d, card2d))
                {
                    case Winner.Player1:
                        whoWon = player1;
                        Console.Write("Player 1 won (" + player1.Cards().Count + "/" + player2.Cards().Count + ")! ");
                        break;
                    case Winner.Player2:
                        whoWon = player2;
                        Console.Write("Player 2 won (" + player1.Cards().Count + "/" + player2.Cards().Count + ")! ");
                        break;
                    case Winner.Tie:
                        whoWon = PlayRound(player1, player2); //play another round...recursive
                        Console.Write("Tie! ");
                        break;
                }
                if (whoWon != null) { whoWon.WinWar(card1a, card1b, card1c, card1d, card2a, card2b, card2c, card2d); }
            }
            return whoWon;
        }

        public int Play() {
            int rounds = 0;
            do
            {
                rounds++;
                PlayRound(player1, player2);
                Console.WriteLine();
                //Console.ReadKey();
            } while (player1.Cards().Count > 0 && player2.Cards().Count > 0);
            Console.Write("GAME OVER. ");
            if(player1.Cards().Count > 0)
            {
                Console.Write(player1);
            } else
            {
                Console.Write(player2);
            }
            Console.Write(" has won in " + rounds + " rounds! " + player1.Cards().Count + "/" + player2.Cards().Count + ")...");
            return rounds;
        }

    }
}
