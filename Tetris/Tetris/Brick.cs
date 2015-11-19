using System;
using System.Collections.Generic;

namespace Tetris
{
    internal class Brick : Figure
    {
        private Form f;
        private int x;
        private int y;

        public Brick(int x, int y, Form f)
        {
            this.x = x;
            this.y = y;
            this.f = f;
            pList = new List<Point>();
            SetBrick();            
        }

        public enum Form
        {
            I,
            J,
            L,
            O,
            S,
            T,
            Z,
        }

        private void I()
        {

            for (int i = 0; i < 4; i++)
            {
                Point p = new Point(x, y + i, '█', System.ConsoleColor.Cyan);
                pList.Add(p);
            }
        }

        private void J()
        {
            Point p = new Point(x, y + 2, '█', System.ConsoleColor.Blue);
            pList.Add(p);

            for (int i = 0; i < 3; i++)
            {
                p = new Point(x + 1, y + i, '█', System.ConsoleColor.Blue);
                pList.Add(p);
            }
        }

        private void L()
        {
            Point p = new Point(x + 1, y + 2, '█', System.ConsoleColor.Gray);
            pList.Add(p);

            for (int i = 0; i < 3; i++)
            {
                p = new Point(x , y + i, '█', System.ConsoleColor.Gray);
                pList.Add(p);
            }
        }

        private void O()
        {
            for (int i = 0; i < 2; i++)
            {
                Point p = new Point(x, y + i, '█', System.ConsoleColor.Yellow);
                pList.Add(p);
                p = new Point(x + 1, y + i, '█', System.ConsoleColor.Yellow);
                pList.Add(p);
            }
        }

        private void S()
        {
            for (int i = 0; i < 2; i++)
            {
                Point p = new Point(x + 1 - i, y + i, '█', System.ConsoleColor.Red);
                pList.Add(p);
                p = new Point(x + 2 - i, y + i, '█', System.ConsoleColor.Red);
                pList.Add(p);
            }
        }

        private void T()
        {
            Point p = new Point(x + 1, y, '█', System.ConsoleColor.Magenta);
            pList.Add(p);
            for(int i = 0; i < 3; i++)
            {
                p = new Point(x + i, y + 1, '█', System.ConsoleColor.Magenta);
                pList.Add(p);
            }
        }

        private void Z()
        {
            for (int i = 0; i < 2; i++)
            {
                Point p = new Point(x + i, y + i, '█', System.ConsoleColor.Red);
                pList.Add(p);
                p = new Point(x + 1 + i, y + i, '█', System.ConsoleColor.Red);
                pList.Add(p);
            }
        }

        private void SetBrick()
        {
            if (f == Form.I)
            {
                I();
            }
            else if (f == Form.J)
            {
                J();
            }
            else if (f == Form.L)
            {
                L();
            }
            else if (f == Form.O)
            {
                O();
            }
            else if (f == Form.S)
            {
                S();
            }
            else if (f == Form.T)
            {
                T();
            }
            else if (f == Form.Z)
            {
                Z();
            }
        }
    }
}