using System;
using System.Collections.Generic;

namespace Tetris
{
    class Walls : Figure
    {
        private int xLeft;
        private int xRight;
        private int yBottom;
        private int yTop;
        private ConsoleColor fColor;

        public Walls(int xLeft, int xRight, int yTop, int yBottom, ConsoleColor fColor)
        {
            this.xLeft = xLeft;
            this.xRight = xRight;
            this.yTop = yTop;
            this.yBottom = yBottom;
            this.fColor = fColor;
            pList = new List<Point>();
            Corners();
            HorisontalWalls();
            VerticalWalls();
        }

        private void Corners()
        {
            Point LeftTopCorner = new Point(xLeft, yTop, '╔', fColor);
            Point LeftBottomCorner = new Point(xLeft, yBottom, '╚', fColor);
            Point RightTopCorner = new Point(xRight, yTop, '╗', fColor);
            Point RightBottomCorner = new Point(xRight, yBottom, '╝', fColor);

            pList.Add(LeftTopCorner);
            pList.Add(LeftBottomCorner);
            pList.Add(RightTopCorner);
            pList.Add(RightBottomCorner);
        }

        private void HorisontalWalls()
        {
            for (int x = xLeft + 1; x < xRight; x++)
            {
                Point p = new Point(x, yTop, '═', fColor);
                pList.Add(p);
                p = new Point(x, yBottom, '═', fColor);
                pList.Add(p);
            }
        }

        private void VerticalWalls()
        {
            for (int y = yTop + 1; y < yBottom; y++)
            {
                Point p = new Point(xLeft, y, '║', fColor);
                pList.Add(p);
                p = new Point(xRight, y, '║', fColor);
                pList.Add(p);
            }
        }
    }
}
