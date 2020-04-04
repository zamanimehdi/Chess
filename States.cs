using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct States
    {
        sbyte[,] states;
        public States copy()
        {
            States newStates=new States();
            newStates.Reset();
            for (int i = 0; i <= 7; i++)
                for (int j = 0; j <= 7; j++)
                    newStates.states[i, j] = states[i, j];
            return newStates;
        }
        public void Reset()
        {
            states = new sbyte[,]{
            {-4, -1, +0, +0, +0, +0, +1, +4},
            {-2, -1, +0, +0, +0, +0, +1, +2},
            {-3, -1, +0, +0, +0, +0, +1, +3},
            {-5, -1, +0, +0, +0, +0, +1, +5},
            {-6, -1, +0, +0, +0, +0, +1, +6},
            {-3, -1, +0, +0, +0, +0, +1, +3},
            {-2, -1, +0, +0, +0, +0, +1, +2},
            {-4, -1, +0, +0, +0, +0, +1, +4}
            };
        }
        public int NonDevCount(sbyte type)
        {
            int s=0;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (type==(-1) && j <= 1)
                        if (states[i, j] == 0)
                            s += 1;
                    if (type==(+1) &&  j >= 6)
                        if (states[i, j] == 0)
                            s += 1;
                }
            }
            return 16 - s;
        }
        public sbyte this[byte x, byte y]
        {
            set
            {
                if (x >= 1 && x <= 8 && y >= 1 && y <= 8)
                    states[x - 1, y - 1] = value;
            }
            get
            {
                if (x >= 1 && x <= 8 && y >= 1 && y <= 8)
                    return states[x - 1, y - 1];
                else return 0;
            }
        }
    }
}
