using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class Position
    {
        public readonly int X;
        public readonly int Y;
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public static double operator -(Position a, Position b)
        {
            return Math.Sqrt(Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.X - b.X, 2));
        }
    }
}
