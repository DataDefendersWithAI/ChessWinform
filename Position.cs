using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;
namespace ChessAI
{
    internal class Position
    {
        public readonly int X;
        public readonly int Y;
        public readonly bool White;
        public Color color;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            White = (X + Y) % 2 == 0;

        }
        public Position(Position p)
        {
            X = p.X;
            Y = p.Y;
            White = p.White;
        }

        public bool Equals(Position p)
        {
            return p.X == X && p.Y == Y;
        }

        public string toSAN()
        {
            return "" + (char)('a' + X) + (8 - Y) + "";
        }

        public Position(string PGN)
        {
            X = PGN[0] - 'a';
            Y = 8 - (PGN[1] - '0');
        }

        public Color getColor()
        {
            return color;
        }
        public void setColor(Color c)
        {
            color = c;
        }

    }
}
