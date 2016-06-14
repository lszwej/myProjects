using System;

namespace DeskaGaltona
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Wpisz liczbe poziomow ");
                uint levels = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Wpisz liczbe kulek ");
                uint balls = Convert.ToUInt32(Console.ReadLine());
                Galton board = new Galton(levels, balls);
                Console.Clear();
                for (int ball = 1; ball <= balls; ++ball)
                {
                    int move = 1;
                    while (!board.CheckIfContainer())
                    {
                        Console.WriteLine("Kulka " + ball + " ruch " + move);
                        board.RandDirection();
                        board.PrintBoard();
                        ++move;
                    }
                    board.ResetBoard();
                }
                board.PrintResults();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}