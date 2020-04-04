using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Chess
{
    class think
    {
        public int Evaluating(sbyte Type, ref States states)
        {
            int score = 0;
            // *** points for putting enemy in check ***
            if (moves.InCheck((sbyte)(Type * (-1)), ref states))
            {
                int NonDevCount = states.NonDevCount((sbyte)(Type * (-1)));
                if (NonDevCount < 9)
                    score += 40;
                else
                    if (NonDevCount < 12)
                        score += 4;
                    else
                        score += 0;
            }
            if (moves.InCheck(Type, ref states))
            {
                int NonDevCount = states.NonDevCount(Type);
                if (NonDevCount < 9)
                    score -= 40;
                else
                    if (NonDevCount < 12)
                        score -= 4;
                    else
                        score -= 0;
            }
            score *= 100;
            score += moves.AllMoveCount(Type, ref states);
            // *** points for pieces attacked / protect && sum of material***
            /*int Own_attacked = 0;
            int Own_protect = 0;
            int Enemy_attacked = 0;
            int Enemyn_protect = 0;*/
            int material = 0;
            for (byte i = 1; i <= 8; i++)
                for (byte j = 1; j <= 8; j++)
                {
                    // material
                    switch (states[i, j])
                    {
                        case 1:
                            material -= 3;
                            break;
                        case 2:
                        case 3:
                            material -= 5;
                            break;
                        case 4:
                            material -= 6;
                            break;
                        case 5:
                            material -= 15;
                            break;
                        case 6:
                            material -= 80;
                            break;
                        case -1:
                            material += 3;
                            break;
                        case -2:
                        case -3:
                            material += 5;
                            break;
                        case -4:
                            material += 6;
                            break;
                        case -5:
                            material += 15;
                            break;
                        case -6:
                            material += 80;
                            break;
                    }
                    // attacked / protect
                  /*  int attack;
                    int protect;
                    if (states[i, j] > 0)
                    {
                        moves.attacked_protect(i, j, ref states, out attack, out protect);
                        Own_attacked += attack;
                        Own_protect += protect;
                    }
                    else if (states[i, j] < 0)
                    {
                        moves.attacked_protect(i, j, ref states, out attack, out protect);
                        Enemy_attacked += attack;
                        Enemyn_protect += protect;
                    }*/
                }
            score = score /*+ (Own_protect - Own_attacked + Enemy_attacked - Enemyn_protect) */+ (material * 100);
            ///////////////////
            return score;
        }
        public Stir Main_think(Board B/*, TreeNode tn*/, byte MAXdepth)
        {
            // minimax
            Stir st1 = new Stir();
            Stir st2 = new Stir();
            st1.Score = -999999999;
            st2.Score = 999999999;
            return MaxMove(B/*, tn*/, MAXdepth, st1, st2);
        }
        public Stir MaxMove(Board B/*, TreeNode tn*/, byte MAXdepth, Stir Alpha, Stir Beta)
        {
            if (MAXdepth > 2)
            {
                ArrayList Al = moves.AllMoveList_With_score(-1, B);
                Stir maxmove = new Stir();
                if (Al.Count != 0)
                    maxmove = ((Stir)Al[0]);
                for (int i = 1; i < Al.Count; i++)
                {
                    //TreeNode newtn = new TreeNode();
                    //newtn.Text = "mind " + ((Stir)Al[i]).F.X + "-" + ((Stir)Al[i]).F.Y + " " + ((Stir)Al[i]).T.X + "-" + ((Stir)Al[i]).T.Y + " % " + ((Stir)Al[i]).Score;
                    //tn.Nodes.Add(newtn);
                    if (maxmove.Score < ((Stir)Al[i]).Score)
                    {
                        maxmove = new Stir(((Stir)Al[i]));
                    }
                }
                return maxmove;
            }
            else
            {
                // حرکاتی که موجب کیش میشود را از عمق اول حذف میکنیم
                ArrayList AL_MoveList = new ArrayList();
                ArrayList tmp = moves.AllMoveList(-1, ref B.states);
                for (int m = 0; m < tmp.Count; m++)
                {
                    sbyte x = B.states[((Stir)tmp[m]).T.X, ((Stir)tmp[m]).T.Y];
                    B.states[((Stir)tmp[m]).T.X, ((Stir)tmp[m]).T.Y] = B.states[((Stir)tmp[m]).F.X, ((Stir)tmp[m]).F.Y];
                    B.states[((Stir)tmp[m]).F.X, ((Stir)tmp[m]).F.Y] = 0;
                    if (moves.InCheck(-1, ref B.states) != true)
                        AL_MoveList.Add(tmp[m]);
                    B.states[((Stir)tmp[m]).F.X, ((Stir)tmp[m]).F.Y] = B.states[((Stir)tmp[m]).T.X, ((Stir)tmp[m]).T.Y];
                    B.states[((Stir)tmp[m]).T.X, ((Stir)tmp[m]).T.Y] = x;
                }
                //if (AL_MoveList.Count == 0)
                //    MessageBox.Show("sssssssssss");
                for (int i = 0; i < AL_MoveList.Count; i++)
                {
                    Stir Tmove = new Stir();
                    //TreeNode newtn = new TreeNode();
                    //newtn.Text = "min " + ((Stir)AL_MoveList[i]).F.X + "-" + ((Stir)AL_MoveList[i]).F.Y + " " + ((Stir)AL_MoveList[i]).T.X + "-" + ((Stir)AL_MoveList[i]).T.Y + " % ";
                    //tn.Nodes.Add(newtn);
                    sbyte savebead = B.states[((Stir)AL_MoveList[i]).T.X, ((Stir)AL_MoveList[i]).T.Y];
                    B.MoveBead(((Stir)AL_MoveList[i]), false);
                    Tmove = MinMove(B/*, tn.Nodes[i]*/, (byte)(MAXdepth + 1), Alpha, Beta);
                    if (Tmove.Score > Alpha.Score)
                    {
                        Alpha = new Stir(((Stir)AL_MoveList[i]));
                        Alpha.Score = Tmove.Score;
                    }
                    //newtn.Text += Tmove.Score.ToString() + " ** " + Alpha.Score.ToString() + " " + Beta.Score.ToString() + " ** " +  MAXdepth;
                    B.states[((Stir)AL_MoveList[i]).F.X, ((Stir)AL_MoveList[i]).F.Y] = B.states[((Stir)AL_MoveList[i]).T.X, ((Stir)AL_MoveList[i]).T.Y];
                    B.states[((Stir)AL_MoveList[i]).T.X, ((Stir)AL_MoveList[i]).T.Y] = savebead;
                    if (Alpha.Score > Beta.Score && Beta.Score != 999999999)
                        return Beta;
                }
                return Alpha;
            }
        }
        /////////////////////////////////
        public Stir MinMove(Board B/*, TreeNode tn*/, byte MAXdepth, Stir Alpha, Stir Beta)
        {

            if (MAXdepth > 2)
            {
                ArrayList Al = moves.AllMoveList_With_score(1, B);
                Stir minmove = new Stir();
                if (Al.Count != 0)
                    minmove = ((Stir)Al[0]);
                for (int i = 1; i < Al.Count; i++)
                {
                    //TreeNode newtn = new TreeNode();
                    //newtn.Text = "maxd " + ((Stir)Al[i]).F.X + "-" + ((Stir)Al[i]).F.Y + " " + ((Stir)Al[i]).T.X + "-" + ((Stir)Al[i]).T.Y + " % " + ((Stir)Al[i]).Score;
                    //tn.Nodes.Add(newtn);
                    if (minmove.Score > ((Stir)Al[i]).Score)
                    {
                        minmove = new Stir(((Stir)Al[i]));
                    }
                }
                return minmove;
            }
            else
            {
                ///////////
                ArrayList AL_MoveList = new ArrayList();
                ArrayList tmp = moves.AllMoveList(1, ref B.states);
                for (int m = 0; m < tmp.Count; m++)
                {
                    sbyte x = B.states[((Stir)tmp[m]).T.X, ((Stir)tmp[m]).T.Y];
                    B.states[((Stir)tmp[m]).T.X, ((Stir)tmp[m]).T.Y] = B.states[((Stir)tmp[m]).F.X, ((Stir)tmp[m]).F.Y];
                    B.states[((Stir)tmp[m]).F.X, ((Stir)tmp[m]).F.Y] = 0;
                    if (moves.InCheck(-1, ref B.states) != true)
                        AL_MoveList.Add(tmp[m]);
                    B.states[((Stir)tmp[m]).F.X, ((Stir)tmp[m]).F.Y] = B.states[((Stir)tmp[m]).T.X, ((Stir)tmp[m]).T.Y];
                    B.states[((Stir)tmp[m]).T.X, ((Stir)tmp[m]).T.Y] = x;
                }
                //if (AL_MoveList.Count == 0)
                //    MessageBox.Show("sssssssssss");
                ////////////
                //ArrayList AL_MoveList = new ArrayList();
                //AL_MoveList = moves.AllMoveList(1, ref B.states);
                for (int i = 0; i < AL_MoveList.Count; i++)
                {
                    Stir Tmove = new Stir();
                    //TreeNode newtn = new TreeNode();
                    //newtn.Text = "max " + ((Stir)AL_MoveList[i]).F.X + "-" + ((Stir)AL_MoveList[i]).F.Y + " " + ((Stir)AL_MoveList[i]).T.X + "-" + ((Stir)AL_MoveList[i]).T.Y + " % ";
                    //tn.Nodes.Add(newtn);
                    sbyte savebead = B.states[((Stir)AL_MoveList[i]).T.X, ((Stir)AL_MoveList[i]).T.Y];
                    B.MoveBead(((Stir)AL_MoveList[i]), false);
                    Tmove = MaxMove(B/*, tn.Nodes[i]*/, (byte)(MAXdepth + 1), Alpha, Beta);
                    if (Tmove.Score < Beta.Score)
                    {
                        Beta = new Stir((Stir)AL_MoveList[i]);
                        Beta.Score = Tmove.Score;
                    }
                    //newtn.Text += Tmove.Score.ToString() + " ** " + Alpha.Score.ToString() + " " + Beta.Score.ToString() + " ** " + MAXdepth;
                    B.states[((Stir)AL_MoveList[i]).F.X, ((Stir)AL_MoveList[i]).F.Y] = B.states[((Stir)AL_MoveList[i]).T.X, ((Stir)AL_MoveList[i]).T.Y];
                    B.states[((Stir)AL_MoveList[i]).T.X, ((Stir)AL_MoveList[i]).T.Y] = savebead;
                    if (Beta.Score < Alpha.Score && Alpha.Score != -999999999)
                        return Alpha;
                }
                return Beta;
            }
        }
    }
}