using System;
using System.Threading;

namespace Tetris
{
    internal class Game
    {
        static int xLeft;
        static int xRight;
        static int yTop;

        internal static void CreatePlayground()
        {
            // Walls Variables
            xLeft = 10;
            xRight = 40;
            yTop = 1;
            int yBottom = 23;
            ConsoleColor wallColor = ConsoleColor.DarkBlue;

            // Set Console Window View
            Console.SetBufferSize(80, 25);  //Size
            Console.CursorVisible = false;  //Invisible Cursor

            //Create Walls
            Walls walls = new Walls(xLeft, xRight, yTop, yBottom, wallColor);
            walls.Draw();           
        }

        private static Point BrickStartPoint(int xLeft, int xRight, int y)
        {
            int x = ((xLeft + xRight) / 2);
            Point p = new Point(x, y + 1, '█', ConsoleColor.Black);
            return p;
        }

        private static void Handle()
        {
            
        }

        public static void SandBox()
        {
            Brick brick = new Brick(BrickStartPoint(xLeft, xRight, yTop), Brick.Form.T);
            Thread.Sleep(300);
            brick.Move(Direction.Down);
            brick.Rotate();
            Thread.Sleep(300);
            brick.Rotate();
        }
    }
}