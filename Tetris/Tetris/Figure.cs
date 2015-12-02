using System;
using System.Collections.Generic;

namespace Tetris
{

    class Figure
    {
        internal List<Point> pList;

        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        public bool IsHit(Direction direction, Figure figure)
        {
            bool result = false;
            foreach (Point point in figure.pList)
            {
                foreach (Point p in pList)
                {
                    Point p1 = GetNextPoint(p, direction);
                    if (p1.x == point.x && p1.y == point.y && result != true)
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

        internal void Clear()
        {
            foreach (Point p in pList)
                p.Clear();
        }
    }
}
