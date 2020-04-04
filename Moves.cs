using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;


namespace Chess
{
    public class moves
    {
        public static ArrayList PawnCanMoveList(ref BeadPosition BP, ref  States states)
        {
            System.Collections.ArrayList bps = new System.Collections.ArrayList();
            if (states[BP.X, BP.Y] < 0)
            {
                if (states[BP.X, (byte)(BP.Y + 1)] == 0) bps.Add(new BeadPosition(BP.X, (byte)(BP.Y + 1)));
                if (BP.Y == 2 && states[BP.X, (byte)(BP.Y + 1)] == 0 && states[BP.X, (byte)(BP.Y + 2)] == 0)bps.Add(new BeadPosition(BP.X, (byte)(BP.Y + 2)));
                if (states[(byte)(BP.X + 1), (byte)(BP.Y + 1)] > 0)bps.Add(new BeadPosition((byte)(BP.X + 1), (byte)(BP.Y + 1)));
                if (states[(byte)(BP.X - 1), (byte)(BP.Y + 1)] > 0)bps.Add(new BeadPosition((byte)(BP.X - 1), (byte)(BP.Y + 1)));
                return bps;
            }
            else
            {
                if (states[BP.X, (byte)(BP.Y - 1)] == 0) bps.Add(new BeadPosition(BP.X, (byte)(BP.Y - 1)));
                if (BP.Y == 7 && states[BP.X, (byte)(BP.Y - 1)] == 0 && states[BP.X, (byte)(BP.Y - 2)] == 0) bps.Add(new BeadPosition(BP.X, (byte)(BP.Y - 2)));
                if (states[(byte)(BP.X + 1), (byte)(BP.Y - 1)] < 0) bps.Add(new BeadPosition((byte)(BP.X + 1), (byte)(BP.Y - 1)));
                if (states[(byte)(BP.X - 1), (byte)(BP.Y - 1)] < 0) bps.Add(new BeadPosition((byte)(BP.X - 1), (byte)(BP.Y - 1)));
                return bps;
            }
        }
        public static ArrayList RookCanMoveList(ref BeadPosition BP, ref States states)
        {
            System.Collections.ArrayList bps = new System.Collections.ArrayList();
            for (byte i = (byte)(BP.X - 1); i >= 1; i--)
            {
                if (states[i, BP.Y] == 0)
                {
                    bps.Add(new BeadPosition(i, BP.Y));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i, BP.Y] < 0)
                    {
                        bps.Add(new BeadPosition(i, BP.Y));
                        break;
                    }
                    else
                        break;
            }
            for (byte i = (byte)(BP.X + 1); i <= 8; i++)
            {
                if (states[i, BP.Y] == 0)
                {
                    bps.Add(new BeadPosition(i, BP.Y));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i, BP.Y] < 0)
                    {
                        bps.Add(new BeadPosition(i, BP.Y));
                        break;
                    }
                    else
                        break;
            }
            for (byte i = (byte)(BP.Y + 1); i <= 8; i++)
            {
                if (states[BP.X, i] == 0)
                {
                    bps.Add(new BeadPosition(BP.X, i));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[BP.X, i] < 0)
                    {
                        bps.Add(new BeadPosition(BP.X, i));
                        break;
                    }
                    else
                        break;
            }
            for (byte i = (byte)(BP.Y - 1); i >= 1; i--)
            {
                if (states[BP.X, i] == 0)
                {
                    bps.Add(new BeadPosition(BP.X, i));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[BP.X, i] < 0)
                    {
                        bps.Add(new BeadPosition(BP.X, i));
                        break;
                    }
                    else
                        break;
            }
            return bps;
        }
        public static ArrayList BishopCanMoveList(ref BeadPosition BP, ref States states)
        {
            System.Collections.ArrayList bps = new System.Collections.ArrayList();
            byte i = (byte)(BP.X - 1);
            byte j = (byte)(BP.Y - 1);
            for (; i >= 1 && j >= 1; i--, j--)
            {
                if (states[i, j] == 0)
                {
                    bps.Add(new BeadPosition(i, j));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i, j] < 0)
                    {
                        bps.Add(new BeadPosition(i, j));
                        break;
                    }
                    else
                        break;

            }
            i = (byte)(BP.X - 1);
            j = (byte)(BP.Y + 1);
            for (; i >= 1 && j <= 8; i--, j++)
            {
                if (states[i, j] == 0)
                {
                    bps.Add(new BeadPosition(i, j));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i, j] < 0)
                    {
                        bps.Add(new BeadPosition(i, j));
                        break;
                    }
                    else
                        break;
            }
            i = (byte)(BP.X + 1);
            j = (byte)(BP.Y + 1);
            for (; i <= 8 && j <= 8; i++, j++)
            {
                if (states[i, j] == 0)
                {
                    bps.Add(new BeadPosition(i, j));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i, j] < 0)
                    {
                        bps.Add(new BeadPosition(i, j));
                        break;
                    }
                    else
                        break;
            }
            i = (byte)(BP.X + 1);
            j = (byte)(BP.Y - 1);
            for (; i <= 8 && j >= 1; i++, j--)
            {
                if (states[i, j] == 0)
                {
                    bps.Add(new BeadPosition(i, j));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i, j] < 0)
                    {
                        bps.Add(new BeadPosition(i, j));
                        break;
                    }
                    else
                        break;
            }
            return bps;

        }
        public static ArrayList KingCanMoveList(ref BeadPosition BP, ref States states)
        {
            System.Collections.ArrayList bps = new System.Collections.ArrayList();
            byte i = (byte)(BP.X - 1);
            byte j = (byte)(BP.Y - 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X - 1);
            j = (byte)(BP.Y);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X - 1);
            j = (byte)(BP.Y + 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X);
            j = (byte)(BP.Y + 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X + 1);
            j = (byte)(BP.Y + 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X + 1);
            j = (byte)(BP.Y);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X + 1);
            j = (byte)(BP.Y - 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X);
            j = (byte)(BP.Y - 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            return bps;
        }
        public static ArrayList KnightCanMoveList(ref BeadPosition BP, ref States states)
        {
            System.Collections.ArrayList bps = new System.Collections.ArrayList();
            byte i = (byte)(BP.X - 2);
            byte j = (byte)(BP.Y + 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X - 1);
            j = (byte)(BP.Y + 2);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X + 1);
            j = (byte)(BP.Y + 2);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X + 2);
            j = (byte)(BP.Y + 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X + 2);
            j = (byte)(BP.Y - 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X + 1);
            j = (byte)(BP.Y - 2);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X - 1);
            j = (byte)(BP.Y - 2);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            i = (byte)(BP.X - 2);
            j = (byte)(BP.Y - 1);
            if (i <= 8 && i >= 1 && j <= 8 && j >= 1 && states[i, j] == 0 || states[BP.X, BP.Y] * states[i, j] < 0)
                bps.Add(new BeadPosition(i, j));
            return bps;
        }
        public static ArrayList QueenCanMoveList(ref BeadPosition BP, ref States states)
        {
            System.Collections.ArrayList bps = new System.Collections.ArrayList();
            /// ROOK
            for (byte i = (byte)(BP.X - 1); i >= 1; i--)
            {
                if (states[i, BP.Y] == 0)
                {
                    bps.Add(new BeadPosition(i, BP.Y));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i, BP.Y] < 0)
                    {
                        bps.Add(new BeadPosition(i, BP.Y));
                        break;
                    }
                    else
                        break;
            }
            for (byte i = (byte)(BP.X + 1); i <= 8; i++)
            {
                if (states[i, BP.Y] == 0)
                {
                    bps.Add(new BeadPosition(i, BP.Y));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i, BP.Y] < 0)
                    {
                        bps.Add(new BeadPosition(i, BP.Y));
                        break;
                    }
                    else
                        break;
            }
            for (byte i = (byte)(BP.Y + 1); i <= 8; i++)
            {
                if (states[BP.X, i] == 0)
                {
                    bps.Add(new BeadPosition(BP.X, i));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[BP.X, i] < 0)
                    {
                        bps.Add(new BeadPosition(BP.X, i));
                        break;
                    }
                    else
                        break;
            }
            for (byte i = (byte)(BP.Y - 1); i >= 1; i--)
            {
                if (states[BP.X, i] == 0)
                {
                    bps.Add(new BeadPosition(BP.X, i));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[BP.X, i] < 0)
                    {
                        bps.Add(new BeadPosition(BP.X, i));
                        break;
                    }
                    else
                        break;
            }
            /// Bishop
            byte i2 = (byte)(BP.X - 1);
            byte j2 = (byte)(BP.Y - 1);
            for (; i2 >= 1 && j2 >= 1; i2--, j2--)
            {
                if (states[i2, j2] == 0)
                {
                    bps.Add(new BeadPosition(i2, j2));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i2, j2] < 0)
                    {
                        bps.Add(new BeadPosition(i2, j2));
                        break;
                    }
                    else
                        break;

            }
            i2 = (byte)(BP.X - 1);
            j2 = (byte)(BP.Y + 1);
            for (; i2 >= 1 && j2 <= 8; i2--, j2++)
            {
                if (states[i2, j2] == 0)
                {
                    bps.Add(new BeadPosition(i2, j2));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i2, j2] < 0)
                    {
                        bps.Add(new BeadPosition(i2, j2));
                        break;
                    }
                    else
                        break;
            }
            i2 = (byte)(BP.X + 1);
            j2 = (byte)(BP.Y + 1);
            for (; i2 <= 8 && j2 <= 8; i2++, j2++)
            {
                if (states[i2, j2] == 0)
                {
                    bps.Add(new BeadPosition(i2, j2));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i2, j2] < 0)
                    {
                        bps.Add(new BeadPosition(i2, j2));
                        break;
                    }
                    else
                        break;
            }
            i2 = (byte)(BP.X + 1);
            j2 = (byte)(BP.Y - 1);
            for (; i2 <= 8 && j2 >= 1; i2++, j2--)
            {
                if (states[i2, j2] == 0)
                {
                    bps.Add(new BeadPosition(i2, j2));
                    continue;
                }
                else
                    if (states[BP.X, BP.Y] * states[i2, j2] < 0)
                    {
                        bps.Add(new BeadPosition(i2, j2));
                        break;
                    }
                    else
                        break;
            }
            return bps;
        }
        public static ArrayList BeadCanMoveList(ref BeadPosition BP, ref States states)
        {
            ArrayList tmp;
            switch (states[BP.X, BP.Y])
            {
                case 1:
                case -1:
                    tmp= PawnCanMoveList(ref BP, ref states);
                    break;
                case 2:
                case -2:
                    tmp = KnightCanMoveList(ref BP, ref  states);
                    break;
                case 3:
                case -3:
                    tmp = BishopCanMoveList(ref BP, ref  states);
                    break;
                case 4:
                case -4:
                    tmp = RookCanMoveList(ref BP, ref  states);
                    break;
                case 5:
                case -5:
                    tmp = QueenCanMoveList(ref BP, ref  states);
                    break;
                case 6:
                case -6:
                    tmp = KingCanMoveList(ref BP, ref  states);
                    break;
                default:
                    throw new Exception("to ghesmate moves omad to defalte switch");
            }
            ArrayList tmp2 = new ArrayList();
            for (int i = 0; i < tmp.Count; i++)
            {
                if (Math.Abs(states[((BeadPosition)tmp[i]).X, ((BeadPosition)tmp[i]).Y]) != 6)
                    tmp2.Add(tmp[i]);
            }
            return tmp2;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type">میتواند منفی یک یا مثبت یک که به ترتیب نماینده مهره سیاه و سفید است</param>
        /// <param name="states"></param>
        /// <returns></returns>
        public static ArrayList AllMoveList(sbyte Type, ref States states)
        {
            ArrayList AL = new ArrayList();
            for (byte i = 1; i <= 8; i++)
            {
                for (byte j = 1; j <= 8; j++)
                {
                    if ((states[i, j] * Type) > 0)
                    {
                        BeadPosition F = new BeadPosition(i, j);
                        ArrayList AL_TMP = BeadCanMoveList(ref F, ref states);
                        for (int x = 0; x < AL_TMP.Count; x++)
                        {
                            Stir STR_TMP = new Stir();
                            STR_TMP.F = F;
                            STR_TMP.T = (BeadPosition)AL_TMP[x];
                            AL.Add(STR_TMP);
                        }
                    }
                }
            }
            return AL;
        }
        public static ArrayList AllMoveList_With_score(sbyte Type, Board B)
        {
            ArrayList AL = new ArrayList();
            for (byte i = 1; i <= 8; i++)
            {
                for (byte j = 1; j <= 8; j++)
                {
                    if ((B.states[i, j] * Type) > 0)
                    {
                        BeadPosition F = new BeadPosition(i, j);
                        ArrayList AL_TMP = BeadCanMoveList(ref F, ref B.states);
                        for (int x = 0; x < AL_TMP.Count; x++)
                        {
                            Stir STR_TMP = new Stir();
                            think thinkobj = new think();
                            STR_TMP.F = F;
                            STR_TMP.T = (BeadPosition)AL_TMP[x];
                            sbyte savebead = B.states[STR_TMP.T.X, STR_TMP.T.Y];
                            B.MoveBead(STR_TMP,false);
                            STR_TMP.Score = thinkobj.Evaluating(-1,ref B.states);
                            //STR_TMP.Score += Math.Abs(savebead) * 100;
                            B.states[STR_TMP.F.X, STR_TMP.F.Y] = B.states[STR_TMP.T.X, STR_TMP.T.Y];
                            B.states[STR_TMP.T.X, STR_TMP.T.Y] = savebead;
                            AL.Add(STR_TMP);
                        }
                    }
                }
            }
            return AL;
        }
        public static int AllMoveCount(sbyte Type, ref States states)
        {
            int count = 0;
            for (byte i = 1; i <= 8; i++)
            {
                for (byte j = 1; j <= 8; j++)
                {
                    if ((states[i, j] * Type) > 0)
                    {
                        BeadPosition F = new BeadPosition(i, j);
                        ArrayList AL_TMP = BeadCanMoveList(ref F, ref states);
                        count += AL_TMP.Count;
                    }
                }
            }
            return count;
        }
        public static bool InCheck(sbyte Type, ref States states)
        {
            Type *= 6;
            for (byte i = 1; i <= 8; i++)
            {
                for (byte j = 1; j <= 8; j++)
                {
                    if (states[i, j] == Type)
                    {
                        ArrayList AL = new ArrayList();
                        byte x = (byte)(i + 1);
                        for (; x <= 8; x++)
                        {
                            if (states[x, j] * Type > 0)
                                break;
                            else
                                if (states[x, j] != 0)
                                {
                                    AL.Add(new BeadPosition(x, j));
                                    break;
                                }
                        }
                        x = (byte)(i - 1);
                        for (; x >= 1; x--)
                        {
                            if (states[x, j] * Type > 0)
                                break;
                            else
                                if (states[x, j] != 0)
                                {
                                    AL.Add(new BeadPosition(x, j));
                                    break;
                                }
                        }
                        byte y = (byte)(j + 1);
                        for (; y <= 8; y++)
                        {
                            if (states[i, y] * Type > 0)
                                break;
                            else
                                if (states[i, y] != 0)
                                {
                                    AL.Add(new BeadPosition(i, y));
                                    break;
                                }
                        }
                        y = (byte)(j - 1);
                        for (; y >= 1; y--)
                        {
                            if (states[i, y] * Type > 0)
                                break;
                            else
                                if (states[i, y] != 0)
                                {
                                    AL.Add(new BeadPosition(i, y));
                                    break;
                                }
                        }
                        //// movarabha
                        x = (byte)(i - 1);
                        y = (byte)(j - 1);
                        for (; y >= 1 && x >= 1; y--, x--)
                        {
                            if (states[x, y] * Type > 0)
                                break;
                            else
                                if (states[x, y] != 0)
                                {
                                    AL.Add(new BeadPosition(x, y));
                                    break;
                                }
                        }
                        x = (byte)(i + 1);
                        y = (byte)(j + 1);
                        for (; y <= 8 && x <= 8; y++, x++)
                        {
                            if (states[x, y] * Type > 0)
                                break;
                            else
                                if (states[x, y] != 0)
                                {
                                    AL.Add(new BeadPosition(x, y));
                                    break;
                                }
                        }
                        x = (byte)(i - 1);
                        y = (byte)(j + 1);
                        for (; y <= 8 && x >= 1; y++, x--)
                        {
                            if (states[x, y] * Type > 0)
                                break;
                            else
                                if (states[x, y] != 0)
                                {
                                    AL.Add(new BeadPosition(x, y));
                                    break;
                                }
                        }
                        x = (byte)(i + 1);
                        y = (byte)(j - 1);
                        for (; y >= 1 && x <= 8; y--, x++)
                        {
                            if (states[x, y] * Type > 0)
                                break;
                            else
                                if (states[x, y] != 0)
                                {
                                    AL.Add(new BeadPosition(x, y));
                                    break;
                                }
                        }
                        /// asb
                        x = (byte)(i - 2);
                        y = (byte)(j + 1);
                        if (states[x, y] != 0 && states[x, y] * Type < 0 && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                            AL.Add(new BeadPosition(x, y));
                        x = (byte)(i - 1);
                        y = (byte)(j + 2);
                        if (states[x, y] != 0 && states[x, y] * Type < 0 && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                            AL.Add(new BeadPosition(x, y));
                        x = (byte)(i + 1);
                        y = (byte)(j + 2);
                        if (states[x, y] != 0 && states[x, y] * Type < 0 && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                            AL.Add(new BeadPosition(x, y));
                        x = (byte)(i + 2);
                        y = (byte)(j + 1);
                        if (states[x, y] != 0 && states[x, y] * Type < 0 && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                            AL.Add(new BeadPosition(x, y));
                        x = (byte)(i + 2);
                        y = (byte)(j - 1);
                        if (states[x, y] != 0 && states[x, y] * Type < 0 && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                            AL.Add(new BeadPosition(x, y));
                        x = (byte)(i + 1);
                        y = (byte)(j - 2);
                        if (states[x, y] != 0 && states[x, y] * Type < 0 && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                            AL.Add(new BeadPosition(x, y));
                        x = (byte)(i - 1);
                        y = (byte)(j - 2);
                        if (states[x, y] != 0 && states[x, y] * Type < 0 && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                            AL.Add(new BeadPosition(x, y));
                        x = (byte)(i - 2);
                        y = (byte)(j - 1);
                        if (states[x, y] != 0 && states[x, y] * Type < 0 && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                            AL.Add(new BeadPosition(x, y));
                        bool incheck = false;
                        BeadPosition TempBP_king = new BeadPosition(i, j);
                        for (int tmp = 0; tmp < AL.Count; tmp++)
                        {
                            switch (states[((BeadPosition)AL[tmp]).X, ((BeadPosition)AL[tmp]).Y])
                            {
                                case 1:
                                case -1:
                                    {
                                        BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL[tmp]);
                                        ArrayList TempAL = PawnCanMoveList(ref TmpBP_Cheker, ref states);
                                        if (TempAL.Contains((object)TempBP_king))
                                            incheck = true;
                                        break;
                                    }
                                case 2:
                                case -2:
                                    {
                                        BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL[tmp]);
                                        ArrayList TempAL = KnightCanMoveList(ref TmpBP_Cheker, ref states);
                                        if (TempAL.Contains((object)TempBP_king))
                                            incheck = true;
                                        break;
                                    }
                                case 3:
                                case -3:
                                    {
                                        BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL[tmp]);
                                        ArrayList TempAL = BishopCanMoveList(ref TmpBP_Cheker, ref states);
                                        if (TempAL.Contains((object)TempBP_king))
                                            incheck = true;
                                        break;
                                    }
                                case 4:
                                case -4:
                                    {
                                        BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL[tmp]);
                                        ArrayList TempAL = RookCanMoveList(ref TmpBP_Cheker, ref states);
                                        if (TempAL.Contains((object)TempBP_king))
                                            incheck = true;
                                        break;
                                    }
                                case 5:
                                case -5:
                                    {
                                        BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL[tmp]);
                                        ArrayList TempAL = QueenCanMoveList(ref TmpBP_Cheker, ref states);
                                        if (TempAL.Contains((object)TempBP_king))
                                            incheck = true;
                                        break;
                                    }
                                case 6:
                                case -6:
                                    {
                                        BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL[tmp]);
                                        ArrayList TempAL = KingCanMoveList(ref TmpBP_Cheker, ref states);
                                        if (TempAL.Contains((object)TempBP_king))
                                            incheck = true;
                                        break;
                                    }
                            }//end switch
                            if (incheck == true) break;
                        }//end for
                        return incheck;
                    }//end if
                }
            }
            return false;
        }
        public static void attacked_protect(byte i, byte j, ref States states, out int attacked, out int protect)
        {
            attacked = protect = 0;
            sbyte Type = (sbyte)((states[i, j]) / Math.Abs(states[i, j]));
            sbyte Typeoposite = (sbyte)(Type * -1);
            ArrayList AL_oposite = new ArrayList();
            ArrayList AL_own = new ArrayList();
            byte x = (byte)(i + 1);
            for (; x <= 8; x++)
            {
                if (states[x, j] * Type > 0)
                    {
                        if (states[x, j] == Type * 4 || states[x, j] == Type * 6 || states[x, j] == Type * 5)
                            AL_own.Add(new BeadPosition(x, j));
                        break;
                    }
                else
                    if (states[x, j] != 0)
                    {
                        if (states[x, j] == Typeoposite * 4 || states[x, j] == Typeoposite * 6 || states[x, j]== Typeoposite * 5)
                            AL_oposite.Add(new BeadPosition(x, j));
                        break;
                    }
            }
            x = (byte)(i - 1);
            for (; x >= 1; x--)
            {
                if (states[x, j] * Type > 0)
                    {
                        if (states[x, j] == Type * 4 || states[x, j] == Type * 6 || states[x, j] == Type * 5)
                            AL_own.Add(new BeadPosition(x, j));
                        break;
                    }
                else
                    if (states[x, j] != 0)
                    {
                        if (states[x, j] == Typeoposite * 4 || states[x, j] == Typeoposite * 6 || states[x, j] == Typeoposite * 5)
                        AL_oposite.Add(new BeadPosition(x, j));
                        break;
                    }
            }
            byte y = (byte)(j + 1);
            for (; y <= 8; y++)
            {
                    if (states[i, y] != 0)
                    {
                        if (states[i, y] == Type * 4 || states[i, y] == Type * 6 || states[i, y] == Type * 5)
                            AL_own.Add(new BeadPosition(i, y));
                        break;
                    }
                else
                    if (states[i, y] != 0)
                    {
                        if (states[i, y] == Typeoposite * 4 || states[i, y] == Typeoposite * 6 || states[i, y] == Typeoposite * 5)
                        AL_oposite.Add(new BeadPosition(i, y));
                        break;
                    }
            }
            y = (byte)(j - 1);
            for (; y >= 1; y--)
            {
                if (states[i, y] * Type > 0)
                    {
                        if (states[i, y] == Type * 4 || states[i, y] == Type * 6 || states[i, y] == Type * 5)
                            AL_own.Add(new BeadPosition(i, y));
                        break;
                    }
                else
                    if (states[i, y] != 0)
                    {
                        if (states[i, y] == Typeoposite * 4 || states[i, y] == Typeoposite * 6 || states[i, y] == Typeoposite * 5)
                        AL_oposite.Add(new BeadPosition(i, y));
                        break;
                    }
            }
            //// movarabha
            x = (byte)(i - 1);
            y = (byte)(j - 1);
            for (; y >= 1 && x >= 1; y--, x--)
            {
                if (states[x, y] * Type > 0)
                    {
                        if (states[x, y] == Type * 6 || states[x, y] == Type * 3 || states[x, y] == Type * 1 || states[x, y] == Type * 5)
                            AL_own.Add(new BeadPosition(x, y));
                        break;
                    }
                else
                    if (states[x, y] != 0)
                    {
                        if (states[x, y] == Typeoposite * 6 || states[x, y] == Typeoposite * 3 || states[x, y] == Typeoposite * 1 || states[x, y] == Typeoposite * 5)
                        AL_oposite.Add(new BeadPosition(x, y));
                        break;
                    }
            }
            x = (byte)(i + 1);
            y = (byte)(j + 1);
            for (; y <= 8 && x <= 8; y++, x++)
            {
                if (states[x, y] * Type > 0)
                    {
                        if (states[x, y] == Type * 6 || states[x, y] == Type * 3 || states[x, y] == Type * 1 || states[x, y] == Type * 5)
                            AL_own.Add(new BeadPosition(x, y));
                        break;
                    }
                else
                    if (states[x, y] != 0)
                    {
                        if (states[x, y] == Typeoposite * 6 || states[x, y] == Typeoposite * 3 || states[x, y] == Typeoposite * 1 || states[x, y] == Typeoposite * 5)
                        AL_oposite.Add(new BeadPosition(x, y));
                        break;
                    }
            }
            x = (byte)(i - 1);
            y = (byte)(j + 1);
            for (; y <= 8 && x >= 1; y++, x--)
            {
                if (states[x, y] * Type > 0)
                    {
                        if (states[x, y] == Type * 6 || states[x, y] == Type * 3 || states[x, y] == Type * 1 || states[x, y] == Type * 5)
                            AL_own.Add(new BeadPosition(x, y));
                        break;
                    }
                else
                    if (states[x, y] != 0)
                    {
                        if (states[x, y] == Typeoposite * 6 || states[x, y] == Typeoposite * 3 || states[x, y] == Typeoposite * 1 || states[x, y] == Typeoposite * 5)
                        AL_oposite.Add(new BeadPosition(x, y));
                        break;
                    }
            }
            x = (byte)(i + 1);
            y = (byte)(j - 1);
            for (; y >= 1 && x <= 8; y--, x++)
            {
                if (states[x, y] * Type > 0)
                    {
                        if (states[x, y] == Type * 6 || states[x, y] == Type * 3 || states[x, y] == Type * 1 || states[x, y] == Type * 5)
                            AL_own.Add(new BeadPosition(x, y));
                        break;
                    }
                else
                    if (states[x, y] != 0)
                    {
                        if (states[x, y] == Typeoposite * 6 || states[x, y] == Typeoposite * 3 || states[x, y] == Typeoposite * 1 || states[x, y] == Typeoposite * 5)
                        AL_oposite.Add(new BeadPosition(x, y));
                        break;
                    }
            }
            /// asb
            x = (byte)(i - 2);
            y = (byte)(j + 1);
            if (states[x, y] == 2 * Type && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_own.Add(new BeadPosition(x, y));
            if (states[x, y] == 2 * Typeoposite && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_oposite.Add(new BeadPosition(x, y));
            x = (byte)(i - 1);
            y = (byte)(j + 2);
            if (states[x, y] == 2 * Type && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_own.Add(new BeadPosition(x, y));
            if (states[x, y] == 2 * Typeoposite && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_oposite.Add(new BeadPosition(x, y));
            x = (byte)(i + 1);
            y = (byte)(j + 2);
            if (states[x, y] == 2 * Type && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_own.Add(new BeadPosition(x, y));
            if (states[x, y] == 2 * Typeoposite && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_oposite.Add(new BeadPosition(x, y));
            x = (byte)(i + 2);
            y = (byte)(j + 1);
            if (states[x, y] == 2 * Type && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_own.Add(new BeadPosition(x, y));
            if (states[x, y] == 2 * Typeoposite && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_oposite.Add(new BeadPosition(x, y));
            x = (byte)(i + 2);
            y = (byte)(j - 1);
            if (states[x, y] == 2 * Type && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_own.Add(new BeadPosition(x, y));
            if (states[x, y] == 2 * Typeoposite && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_oposite.Add(new BeadPosition(x, y));
            x = (byte)(i + 1);
            y = (byte)(j - 2);
            if (states[x, y] == 2 * Type && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_own.Add(new BeadPosition(x, y));
            if (states[x, y] == 2 * Typeoposite && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_oposite.Add(new BeadPosition(x, y));
            x = (byte)(i - 1);
            y = (byte)(j - 2);
            if (states[x, y] == 2 * Type && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_own.Add(new BeadPosition(x, y));
            if (states[x, y] == 2 * Typeoposite && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_oposite.Add(new BeadPosition(x, y));
            x = (byte)(i - 2);
            y = (byte)(j - 1);
            if (states[x, y] == 2 * Type && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_own.Add(new BeadPosition(x, y));
            if (states[x, y] == 2 * Typeoposite && x <= 8 && x >= 1 && y >= 1 && y <= 8)
                AL_oposite.Add(new BeadPosition(x, y));
            BeadPosition TempBP = new BeadPosition(i, j);
            ////////// *** attack
            for (int tmp = 0; tmp < AL_oposite.Count; tmp++)
            {
                switch (states[((BeadPosition)AL_oposite[tmp]).X, ((BeadPosition)AL_oposite[tmp]).Y])
                {
                    case 1:
                    case -1:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_oposite[tmp]);
                            ArrayList TempAL = PawnCanMoveList(ref TmpBP_Cheker, ref states);
                            if (TempAL.Contains((object)TempBP))
                                attacked++;
                            break;
                        }
                    case 2:
                    case -2:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_oposite[tmp]);
                            ArrayList TempAL = KnightCanMoveList(ref TmpBP_Cheker, ref states);
                            if (TempAL.Contains((object)TempBP))
                                attacked++;
                            break;
                        }
                    case 3:
                    case -3:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_oposite[tmp]);
                            ArrayList TempAL = BishopCanMoveList(ref TmpBP_Cheker, ref states);
                            if (TempAL.Contains((object)TempBP))
                                attacked++;
                            break;
                        }
                    case 4:
                    case -4:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_oposite[tmp]);
                            ArrayList TempAL = RookCanMoveList(ref TmpBP_Cheker, ref states);
                            if (TempAL.Contains((object)TempBP))
                                attacked++;
                            break;
                        }
                    case 5:
                    case -5:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_oposite[tmp]);
                            ArrayList TempAL = QueenCanMoveList(ref TmpBP_Cheker, ref states);
                            if (TempAL.Contains((object)TempBP))
                                attacked++;
                            break;
                        }
                    case 6:
                    case -6:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_oposite[tmp]);
                            ArrayList TempAL = KingCanMoveList(ref TmpBP_Cheker, ref states);
                            if (TempAL.Contains((object)TempBP))
                                attacked++;
                            break;
                        }
                }//end switch 2
            }//end for 2
            ////////// *** Protect
            for (int tmp = 0; tmp < AL_own.Count; tmp++)
            {
                switch (states[((BeadPosition)AL_own[tmp]).X, ((BeadPosition)AL_own[tmp]).Y])
                {
                    case 1:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_own[tmp]);
                            if (i == (TmpBP_Cheker.X - 1) && j == (TmpBP_Cheker.Y - 1))
                                protect++;
                            if (i == (TmpBP_Cheker.X + 1) && j == (TmpBP_Cheker.Y - 1))
                                protect++;
                            break;
                        }
                    case -1:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_own[tmp]);
                            if (i==(TmpBP_Cheker.X-1) && j==(TmpBP_Cheker.Y+1))
                                protect++;
                            if (i == (TmpBP_Cheker.X + 1) && j == (TmpBP_Cheker.Y + 1))
                                protect++;
                            break;
                        }
                    case 2:
                    case -2:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_own[tmp]);
                            if (i == (TmpBP_Cheker.X - 2) && j == (TmpBP_Cheker.Y + 1))
                                protect++;
                            if (i == (TmpBP_Cheker.X - 1) && j == (TmpBP_Cheker.Y + 2))
                                protect++;
                            if (i == (TmpBP_Cheker.X + 1) && j == (TmpBP_Cheker.Y + 2))
                                protect++;
                            if (i == (TmpBP_Cheker.X + 2) && j == (TmpBP_Cheker.Y + 1))
                                protect++;
                            if (i == (TmpBP_Cheker.X + 2) && j == (TmpBP_Cheker.Y - 1))
                                protect++;
                            if (i == (TmpBP_Cheker.X + 1) && j == (TmpBP_Cheker.Y - 2))
                                protect++;
                            if (i == (TmpBP_Cheker.X - 1) && j == (TmpBP_Cheker.Y - 2))
                                protect++;
                            if (i == (TmpBP_Cheker.X - 2) && j == (TmpBP_Cheker.Y - 1))
                                protect++;
                            break;
                        }
                    case 3:
                    case -3:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_own[tmp]);
                            if (TmpBP_Cheker.X > i && TmpBP_Cheker.Y > j)
                            {
                                x = (byte)(TmpBP_Cheker.X - 1);
                                y = (byte)(TmpBP_Cheker.Y - 1);
                                for (; y >= 1 && x >= 1; y--, x--)
                                    if (i == x && j == y)
                                        protect ++;
                            }
                            if (TmpBP_Cheker.X < i && TmpBP_Cheker.Y < j)
                            {

                                x = (byte)(TmpBP_Cheker.X + 1);
                                y = (byte)(TmpBP_Cheker.Y + 1);
                                for (; y <= 8 && x <= 8; y++, x++)
                                    if (i == x && j == y)
                                        protect ++;
                            }
                            if (TmpBP_Cheker.X > i && TmpBP_Cheker.Y < j)
                            {

                                x = (byte)(TmpBP_Cheker.X - 1);
                                y = (byte)(TmpBP_Cheker.Y + 1);
                                for (; y <= 8 && x >= 1; y++, x--)
                                    if (i == x && j == y)
                                        protect ++;
                            }
                            if (TmpBP_Cheker.X < i && TmpBP_Cheker.Y > j)
                            {

                                x = (byte)(TmpBP_Cheker.X + 1);
                                y = (byte)(TmpBP_Cheker.Y - 1);
                                for (; y >= 1 && x <= 8; y--, x++)
                                    if (i == x && j == y)
                                        protect++;
                            }
                            break;
                        }
                    case 4:
                    case -4:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_own[tmp]);

                            if (TmpBP_Cheker.X < i && TmpBP_Cheker.Y == j)
                            {
                                x = (byte)(TmpBP_Cheker.X + 1);
                                for (; x <= 8; x++)
                                    if (i == x)
                                        protect++;
                            }

                            if (TmpBP_Cheker.X > i && TmpBP_Cheker.Y == j)
                            {
                                x = (byte)(TmpBP_Cheker.X - 1);
                                for (; x >= 1; x--)
                                    if (i == x)
                                        protect++;
                            }
                            if (TmpBP_Cheker.X == i && TmpBP_Cheker.Y < j)
                            {
                                y = (byte)(TmpBP_Cheker.Y + 1);
                                for (; y <= 8; y++)
                                    if (j == y)
                                        protect++;
                            }
                            if (TmpBP_Cheker.X == i && TmpBP_Cheker.Y > j)
                            {
                                y = (byte)(TmpBP_Cheker.Y - 1);
                                for (; y >= 1; y--)
                                    if (j == y)
                                        protect++;
                            }
                            break;
                        }
                    case 5:
                    case -5:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_own[tmp]);

                            if (TmpBP_Cheker.X > i && TmpBP_Cheker.Y > j)
                            {
                                x = (byte)(TmpBP_Cheker.X - 1);
                                y = (byte)(TmpBP_Cheker.Y - 1);
                                for (; y >= 1 && x >= 1; y--, x--)
                                    if (i == x && j == y)
                                        protect++;
                            }
                            if (TmpBP_Cheker.X < i && TmpBP_Cheker.Y < j)
                            {

                                x = (byte)(TmpBP_Cheker.X + 1);
                                y = (byte)(TmpBP_Cheker.Y + 1);
                                for (; y <= 8 && x <= 8; y++, x++)
                                    if (i == x && j == y)
                                        protect++;
                            }
                            if (TmpBP_Cheker.X > i && TmpBP_Cheker.Y < j)
                            {

                                x = (byte)(TmpBP_Cheker.X - 1);
                                y = (byte)(TmpBP_Cheker.Y + 1);
                                for (; y <= 8 && x >= 1; y++, x--)
                                    if (i == x && j == y)
                                        protect++;
                            }
                            if (TmpBP_Cheker.X < i && TmpBP_Cheker.Y > j)
                            {

                                x = (byte)(TmpBP_Cheker.X + 1);
                                y = (byte)(TmpBP_Cheker.Y - 1);
                                for (; y >= 1 && x <= 8; y--, x++)
                                    if (i == x && j == y)
                                        protect++;
                            }
                            ///
                            if (TmpBP_Cheker.X < i && TmpBP_Cheker.Y == j)
                            {
                                x = (byte)(TmpBP_Cheker.X + 1);
                                for (; x <= 8; x++)
                                    if (i == x)
                                        protect++;
                            }

                            if (TmpBP_Cheker.X > i && TmpBP_Cheker.Y == j)
                            {
                                x = (byte)(TmpBP_Cheker.X - 1);
                                for (; x >= 1; x--)
                                    if (i == x)
                                        protect++;
                            }
                            if (TmpBP_Cheker.X == i && TmpBP_Cheker.Y < j)
                            {
                                y = (byte)(TmpBP_Cheker.Y + 1);
                                for (; y <= 8; y++)
                                    if (j == y)
                                        protect++;
                            }
                            if (TmpBP_Cheker.X == i && TmpBP_Cheker.Y > j)
                            {
                                y = (byte)(TmpBP_Cheker.Y - 1);
                                for (; y >= 1; y--)
                                    if (j == y)
                                        protect++;
                            }
                            break;
                        }
                    case 6:
                    case -6:
                        {
                            BeadPosition TmpBP_Cheker = new BeadPosition((BeadPosition)AL_own[tmp]);
                            x = (byte)(TmpBP_Cheker.X+1);
                            y = (byte)(TmpBP_Cheker.Y);
                            if (i == x && j == y)
                                protect++;
                            x = (byte)(TmpBP_Cheker.X + 1);
                            y = (byte)(TmpBP_Cheker.Y - 1);
                            if (i == x && j == y)
                                protect++;
                            x = (byte)(TmpBP_Cheker.X);
                            y = (byte)(TmpBP_Cheker.Y - 1);
                            if (i == x && j == y)
                                protect++;
                            x = (byte)(TmpBP_Cheker.X - 1);
                            y = (byte)(TmpBP_Cheker.Y - 1);
                            if (i == x && j == y)
                                protect++;
                            x = (byte)(TmpBP_Cheker.X - 1);
                            y = (byte)TmpBP_Cheker.Y;
                            if (i == x && j == y)
                                protect ++;
                            x = (byte)(TmpBP_Cheker.X - 1);
                            y = (byte)(TmpBP_Cheker.Y + 1);
                            if (i == x && j == y)
                                protect++;
                            x = (byte)(TmpBP_Cheker.X);
                            y = (byte)(TmpBP_Cheker.Y + 1);
                            if (i == x && j == y)
                                protect++;
                            x = (byte)(TmpBP_Cheker.X + 1);
                            y = (byte)(TmpBP_Cheker.Y + 1);
                            if (i == x && j == y)
                                protect++;
                            break;
                        }
                }//end switch 2

            }//end for 2
        }
        public static void attacked_protect(BeadPosition BP, ref States states, out int attacked, out int protect)
        {
            attacked_protect(BP.X, BP.Y, ref states, out attacked, out protect);
        }
    }
}