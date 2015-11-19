using System;

namespace Tetris
{
    internal class Game
    {
        internal static void CreatePlayground()
        {
            // Walls Variables
            int xLeft = 10;
            int xRight = 40;
            int yTop = 1;
            int yBottom = 23;
            ConsoleColor wallColor = ConsoleColor.DarkBlue;

            int x = 0;
            int y = 0;
            Brick.Form f = Brick.Form.I;

            // Set Console Window View
            Console.SetBufferSize(80, 25);  //Size
            Console.CursorVisible = false;  //Invisible Cursor

            //Create Walls
            Walls walls = new Walls(xLeft, xRight, yTop, yBottom, wallColor);
            walls.Draw();

            //SandBox
            Brick brick = new Brick(45, 1, Brick.Form.I);
            brick.Draw();
            brick = new Brick(45, 6, Brick.Form.J);
            brick.Draw();
            brick = new Brick(45, 10, Brick.Form.L);
            brick.Draw();
            brick = new Brick(45, 14, Brick.Form.O);
            brick.Draw();
            brick = new Brick(45, 17, Brick.Form.S);
            brick.Draw();
            brick = new Brick(45, 20, Brick.Form.T);
            brick.Draw();
            brick = new Brick(50, 6, Brick.Form.Z);
            brick.Draw();
        }
    }
}