using System;
using System.Threading;

namespace Tetris
{
    internal class Game
    {
        private static Direction direction;
        private static Brick brick;
        private static int timeout = 500;

        // Walls Variables
        public static int xLeft = 10;
        public static int xRight = 40;
        public static int yTop = 1;
        public static int yBottom = 23;

        internal static void CreatePlayground()
        {
            ConsoleColor wallColor = ConsoleColor.DarkBlue;

            // Set Console Window View
            Console.SetBufferSize(80, 25);  //Size
            Console.CursorVisible = false;  //Invisible Cursor

            //Create Walls
            Walls walls = new Walls(xLeft, xRight, yTop, yBottom, wallColor);
            walls.Draw();

            //SandBox
            brick = new Brick(BrickStartPoint(xLeft, xRight, yTop), Brick.Form.I);
        }

        internal static void Play()
        {
            while(true)
            {
                Handle();
                Step();
            }
        }

        private static Point BrickStartPoint(int xLeft, int xRight, int y)
        {
            int x = ((xLeft + xRight) / 2);
            Point p = new Point(x, y + 1, '█', ConsoleColor.Black);
            return p;
        }

        private static void Handle()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    direction = Direction.Left;
                    brick.Move(direction);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    direction = Direction.Right;
                    brick.Move(direction);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    direction = Direction.Down;
                    brick.Move(direction);
                }
            }
        }

        private static void Step()
        {
            brick.Move(Direction.Down);
            Thread.Sleep(timeout);
        }
    }
}