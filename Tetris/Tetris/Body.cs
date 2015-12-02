using System.Collections.Generic;

namespace Tetris
{
    class Body : Figure
    {
        public Body()
        {
            pList = new List<Point>();
        }

        public void RemoveLine()
        {
            for (int y = Game.yTop + 1; y < Game.yBottom; y++)
            {
                ClearLine(y);
                PushDownAllOfTop(y);
            }
        }

        private void PushDownAllOfTop(int y)
        {
            foreach(Point p in pList)
            {
                if (p.y > y)
                {
                    p.y = p.y - 1;
                }
            }
        }

        private void ClearLine(int y)
        {
            int count = 0;
            foreach (Point p in pList)
            {
                if (p.y == y)
                {
                    count = count + 1;
                }
            }
            if (count == (Game.xRight - Game.xLeft - 1))
            {
                foreach (Point p in pList)
                {
                    if (p.y == y)
                    {
                        p.Clear();
                        pList.Remove(p);
                    }
                }
            }
        }

        public void AddBrick(Figure brick)
        {
            foreach(Point p in brick.pList)
            {
                pList.Add(p);
            }
        }
    }
}
