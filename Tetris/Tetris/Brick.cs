using System;
using System.Collections.Generic;

namespace Tetris
{
    internal class Brick : Figure
    {
        private Form f;
        private Point BrickPoint;   // Contain brick coordinates & symvol

        public Brick(Point p, Form f)
        {
            this.BrickPoint = p;
            this.f = f;
            pList = new List<Point>();
            SetBrick();
            Draw();        
             
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
            BrickPoint.x = BrickPoint.x - 1;
            for (int i = 0; i < 4; i++)
            {
                Point p = new Point(BrickPoint.x+1, BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Cyan);
                pList.Add(p);
            }
        }

        private void J()
        {
            Point p = new Point(BrickPoint.x, BrickPoint.y + 2, BrickPoint.sym, ConsoleColor.Blue);
            pList.Add(p);

            for (int i = 0; i < 3; i++)
            {
                p = new Point(BrickPoint.x + 1, BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Blue);
                pList.Add(p);
            }
        }

        private void L()
        {
            Point p = new Point(BrickPoint.x + 1, BrickPoint.y + 2, BrickPoint.sym, ConsoleColor.Gray);
            pList.Add(p);

            for (int i = 0; i < 3; i++)
            {
                p = new Point(BrickPoint.x , BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Gray);
                pList.Add(p);
            }
        }

        private void O()
        {
            for (int i = 0; i < 2; i++)
            {
                Point p = new Point(BrickPoint.x, BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Yellow);
                pList.Add(p);
                p = new Point(BrickPoint.x + 1, BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Yellow);
                pList.Add(p);
            }
        }

        private void S()

        {
            for (int i = 0; i < 2; i++)
            {
                Point p = new Point(BrickPoint.x + 1 - i, BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Green);
                pList.Add(p);
                p = new Point(BrickPoint.x + 2 - i, BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Green);
                pList.Add(p);
            }
        }

        private void T()
        {
            Point p = new Point(BrickPoint.x + 1, BrickPoint.y, BrickPoint.sym, ConsoleColor.Magenta);
            pList.Add(p);
            for(int i = 0; i < 3; i++)
            {
                p = new Point(BrickPoint.x + i, BrickPoint.y + 1, BrickPoint.sym, ConsoleColor.Magenta);
                pList.Add(p);
            }
        }

        private void Z()
        {
            for (int i = 0; i < 2; i++)
            {
                Point p = new Point(BrickPoint.x + i, BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Red);
                pList.Add(p);
                p = new Point(BrickPoint.x + 1 + i, BrickPoint.y + i, BrickPoint.sym, ConsoleColor.Red);
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

        public void Move(Direction direction)
        {
            if (IsHit(direction, Game.walls) != true && IsHit(direction, Game.body) != true)
            {
                foreach (Point p in pList)
                {
                    p.Clear();
                    p.Move(1, direction);
                }
                BrickPoint.Move(1, direction);
                Draw();
            }
        }

        public void Rotate() // Works good only with I S O Z
        {
            foreach(Point p in pList)
            {
                p.Clear();
                p.x = p.x - BrickPoint.x + p.y - BrickPoint.y;
                p.y = p.x - (p.y - BrickPoint.y) + BrickPoint.y;
                p.x = p.x - (p.y - BrickPoint.y) + BrickPoint.x; 
            }
            Draw();
        }

        public bool IsHit(Direction direction, Figure figure)
        {
            bool result = false;
            foreach (Point point in figure.pList)
            {
                foreach(Point p in pList)
                {
                    Point p1 = GetNextPoint(p, direction);
                    if(p1.x == point.x && p1.y == point.y && result != true)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        private Point GetNextPoint(Point p, Direction direction)
        {
            Point nextPoint = new Point(p.x, p.y, p.sym, ConsoleColor.Black);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
    }
}