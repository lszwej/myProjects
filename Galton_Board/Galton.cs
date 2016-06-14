using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;

namespace DeskaGaltona
{
    internal class Galton
    {
        private uint levels;
        private uint balls;
        private uint containerLevel;
        private Dictionary<Point, string> board = new Dictionary<Point, string>();
        private Point currentPosition = new Point(1, 1);
        private Dictionary<string, uint> results = new Dictionary<string, uint>();

        public Galton(uint levels, uint balls)
        {
            this.levels = levels;
            this.balls = balls;
            containerLevel = levels + 1;
            for (int i = 1; i <= containerLevel; ++i)
                results.Add("Kontener " + i, 0);
            ResetBoard();
        }

        public void PrintBoard()
        {
            for (int i = 1; i <= containerLevel; ++i)
            {
                for (int j = i; j <= containerLevel; ++j)
                    Console.Write(" ");
                for (int k = 1; k <= i; ++k)
                    Console.Write(board[new Point(k, i)] + " ");
                Console.WriteLine();
            }
            Thread.Sleep(1000);
            Console.Clear();
        }

        public bool CheckIfContainer()
        {
            bool res;
            if (currentPosition.Y != containerLevel)
                res = false;
            else
            {
                results["Kontener " + currentPosition.X] += 1;
                Console.WriteLine("*****Kontener numer " + currentPosition.X + " *****");
                Thread.Sleep(2000);
                Console.Clear();
                res = true; 
            }
            return res;
        }

        public void RandDirection()
        {   
            Random rand = new Random();
            double num = rand.NextDouble();
            if (num >= 0.5)
                currentPosition.X += 1;
            board[new Point(currentPosition.X, currentPosition.Y)] = "X";
            currentPosition.Y += 1;
        }

        public void ResetBoard()
        {
            currentPosition.Y = 1;
            currentPosition.X = 1;
            board.Clear();
            board[new Point(1, 1)] = "X";
            for (int i = 2; i <= containerLevel; ++i)
            {
                for (int j = 1; j <= i; ++j)
                {
                    Point tempPoint = new Point(j, i);
                    if (i == containerLevel)
                        board.Add(tempPoint, j.ToString());
                    else
                        board.Add(tempPoint, "O");
                }
            }
        }

        public void PrintResults()
        {
            Console.WriteLine("**********Statystyki koncowe**********");
            foreach (KeyValuePair<string, uint> elem in results)
                Console.WriteLine(elem.Key  + " = " + elem.Value);
        }
    }
}