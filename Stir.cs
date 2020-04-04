using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct Stir
    {
        BeadPosition f;
        BeadPosition t;
        int score;
        public Stir(Stir oldstir)
        {
            f = oldstir.F;
            t = oldstir.T;
            score = oldstir.Score;
        }
        public BeadPosition F
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
            }
        }
        public BeadPosition T
        {
            get
            {
                return t;
            }
            set
            {
                t = value;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
    }
}
