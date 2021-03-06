﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Body : Figure
    {
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
    }
}
