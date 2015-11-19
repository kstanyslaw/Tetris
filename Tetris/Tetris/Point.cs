using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Point
    {
        public int x;
        public int y;
        private ConsoleColor fColor;
        private char sym;

        public Point(int x, int y, char sym, ConsoleColor fColor)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
            this.fColor = fColor;
        }

        internal void Draw()
        {
            Console.ForegroundColor = fColor;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
            Console.ResetColor();
        }
    }
}
