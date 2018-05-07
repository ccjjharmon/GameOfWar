using System;

namespace core
{
    class Program
    {
        public static void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int highest = 0, ctr = 0;
            do
            {
                Player p1 = new Player("Arty");
                Player p2 = new Player("Babs");
                IGame game = new GameOfWar(p1, p2);

                game.PassOutCards();
                var i = game.Play();

                if (i > highest) {
                    highest = i;
                    ctr++;
                    if (ctr > 5)
                    {
                        Console.ReadKey();
                    }
                }
            } while (true);
        }
    }
}
 