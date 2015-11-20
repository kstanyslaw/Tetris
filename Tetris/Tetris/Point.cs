using System;

namespace Tetris
{
    class Point
    {
        public int x;
        public int y;
        public char sym;
        private ConsoleColor fColor;

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

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.Right)
            {
                x = x + offset;
            }
            else if (direction == Direction.Left)
            {
                x = x - offset;
            }
            else if (direction == Direction.Down)
            {
                y = y + offset;
            }
        }

        internal void Clear()
        {
            Console.ResetColor();
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
    }
}
