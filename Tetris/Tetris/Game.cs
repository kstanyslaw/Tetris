using System;
using System.Threading;

namespace Tetris
{
    internal class Game
    {
        private static Direction direction;
        public static Brick brick;
        private static int timeout = 500;
        private static Random random = new Random();

        // Walls Variables
        public static int xLeft = 10;
        public static int xRight = 40;
        public static int yTop = 1;
        public static int yBottom = 23;
        private static ConsoleColor wallColor = ConsoleColor.DarkBlue;
        public static Walls walls = new Walls(xLeft, xRight, yTop, yBottom, wallColor);
        //Create Body
        public static Body body = new Body();

        private static bool On = true;
        private static Brick.Form nextBrickForm = new Brick.Form();
        private static Brick nextBrick;

        internal static void CreatePlayground()
        {
            // Set Console Window View
            Console.SetBufferSize(80, 25);  //Size
            Console.CursorVisible = false;  //Invisible Cursor

            //Create Walls
            walls.Draw();

            

            //SandBox
            brick = new Brick(BrickStartPoint(xLeft, xRight, yTop), RandomBrick());
            nextBrickForm = RandomBrick();
            Point preview = new Point(75, 5, '█', ConsoleColor.Black);
            nextBrick = new Brick(preview, nextBrickForm);
        }

        internal static void Play()
        {
            DropBrick();
            while(On == true)
            {
                Handle();
                Rule();
            }
        }

        internal static void Rule()
        {
            if(brick.IsHit(Direction.Down, walls) == true || brick.IsHit(Direction.Down, body) == true)
            {
                body.AddBrick(brick);
                body.Draw();
                brick = new Brick(BrickStartPoint(xLeft, xRight, yTop), nextBrickForm);
                nextBrickForm = RandomBrick();
            }
            if(body.IsHit(Direction.Up, walls) == true)
            {
                On = false;
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
                else if(key.Key == ConsoleKey.UpArrow)
                {
                    brick.Rotate();
                }
                else if (key.Key == ConsoleKey.Spacebar)
                {
                    brick.DropDown();
                }
            }
        }

        private static void Step()
        {
            brick.Move(Direction.Down);
            Thread.Sleep(timeout);
        }

        private static void Steps()
        {
            while(On == true)
            {
                Step();
            }
        }

        private static void DropBrick()
        {
            Thread thread = new Thread(Steps);
            thread.IsBackground = false;
            thread.Start();
        }

        private static Brick.Form RandomBrick()
        {
            Brick.Form brickForm = new Brick.Form();
            brickForm = (Brick.Form)random.Next(0, 6);
            return brickForm;
        }
    }
}