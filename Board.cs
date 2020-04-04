using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace Chess
{
    /// <summary>
    ///  رسم زمینه شطرنج و
    /// </summary>
    public class Board
    {
        Control ctr;
        int pieceswidth;
        int pieceshight;
        public States states;
        BeadPosition mouseposition = new BeadPosition(0, 0);
        BeadPosition selectcell = new BeadPosition(0, 0);
        ArrayList selectcellmoves = new ArrayList();
        public BeadPosition pixeltoposition(int x, int y)
        {
            BeadPosition temp = new BeadPosition();
            temp.X = Convert.ToByte((x / pieceswidth) + 1);
            temp.Y = Convert.ToByte((y / pieceshight) + 1);
            return temp;
        }
        /// <summary>
        /// تعیین ابعاد خانه های شطرنج و همچنین تعیین کنترلی که برد روی 
        /// آن قرار می گیرد
        /// </summary>
        /// <param name="pieceswidth">پهنای خانه ها</param>
        /// <param name="pieceshight">ارتفاع خانه ها</param>
        /// <param name="ctr">کنترلی که برد روی آن قرار می گیرد</param>
        public Board(int pieceswidth, int pieceshight, Control ctr)
        {
            this.pieceswidth = pieceswidth;
            this.pieceshight = pieceshight;
            this.ctr = ctr;
            resetboard();
        }
        public void CellPaint(byte x, byte y, Graphics Grp)
        {
            if (x <= 8 && y <= 8)
            {
                Point startpoint = new Point((x - 1) * pieceswidth, (y - 1) * pieceshight);
                Size sizeofpieces = new Size(pieceswidth, pieceshight);
                Rectangle piecesRectangle = new Rectangle(startpoint, sizeofpieces);
                Grp.Clip = new Region(new Rectangle(startpoint, new Size(pieceswidth + 1, pieceshight + 1)));
                if ((x + y) % 2 != 0)
                    Grp.FillRectangle(new SolidBrush(Color.BurlyWood), piecesRectangle);
                else
                    Grp.FillRectangle(new SolidBrush(Color.WhiteSmoke), piecesRectangle);
                if (mouseposition.X == x && mouseposition.Y == y)
                    Grp.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Khaki)), piecesRectangle);
                if (selectcell.Y == y && selectcell.X == x)
                    Grp.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.PowderBlue)), piecesRectangle);
                if (selectcellmoves.Contains(new BeadPosition(x, y)))
                    Grp.FillRectangle(new SolidBrush(Color.FromArgb(150, Color.Gray)), piecesRectangle);
                Grp.DrawRectangle(new Pen(new SolidBrush(Color.Black)), piecesRectangle);
                if (x <= 8 && y <= 8 && states[x, y] != 0)
                {
                    Bitmap bitmap = null;
                    switch (states[x, y])
                    {
                        case 1:
                            bitmap = Properties.Resources.Pawn_White;
                            break;
                        case 2:
                            bitmap = Properties.Resources.Knight_White;
                            break;
                        case 3:
                            bitmap = Properties.Resources.Bishop_White;
                            break;
                        case 4:
                            bitmap = Properties.Resources.Rook_White;
                            break;
                        case 5:
                            bitmap = Properties.Resources.Queen_White;
                            break;
                        case 6:
                            bitmap = Properties.Resources.King_White;
                            break;
                        case -1:
                            bitmap = Properties.Resources.Pawn_Black;
                            break;
                        case -2:
                            bitmap = Properties.Resources.Knight_Black;
                            break;
                        case -3:
                            bitmap = Properties.Resources.Bishop_Black;
                            break;
                        case -4:
                            bitmap = Properties.Resources.Rook_Black;
                            break;
                        case -5:
                            bitmap = Properties.Resources.Queen_Black;
                            break;
                        case -6:
                            bitmap = Properties.Resources.King_Black;
                            break;
                    }
                    Grp.DrawImage(bitmap, ((x - 1) * pieceswidth) + (pieceswidth / 2) - 23, ((y - 1) * pieceshight) + (pieceshight / 2) - 23);
                }
                Grp.ResetClip();
            }
        }
        /// <summary>
        /// رسم زمینه بازی به صورت 8*8
        /// </summary>
        /// <param name="Grp">گرافیک مربوط به کنترلی که زمینه شطرنج در آن رسم می شود و باید این گرافیک از متد اونپینت گرفته شود</param>
        public void paintBoard(Graphics Grp)
        {
            for (byte i = 1; i <= 8; i += 1)
            {
                for (byte j = 1; j <= 8; j += 1)
                {
                    CellPaint(i, j, Grp);
                }
            }
        }
        /// <summary>
        /// هنگامی که موس روی برد حرکت میکند با این متد
        /// رنگ خانه هایی که موس از آن عبور میکند عوض میشود
        /// </summary>
        /// <param name="e">آرگومانی که از اونت موسموو کنترل گرفته میشود</param>
        public void MouseMoveboard(MouseEventArgs e)
        {
            // برای اینکه با حرکت درون یک خانه آن خانه رندر نشود
            // به این صورت که تنها در صورت تغییر خانه وارد ایف میشود
            BeadPosition temp = new BeadPosition(mouseposition);
            mouseposition = pixeltoposition(e.Location.X, e.Location.Y);
            if (temp != mouseposition)
            {
                CellPaint(temp.X, temp.Y, ctr.CreateGraphics()); // خانه قبلی که از آن رد شدیم
                CellPaint(mouseposition.X, mouseposition.Y, ctr.CreateGraphics());//خانه جدید
            }
        }
        public void MouseLeaveCell()
        {
            BeadPosition temp = new BeadPosition(mouseposition);
            mouseposition.setNull();
            CellPaint(temp.X, temp.Y, ctr.CreateGraphics());
        }
        public void resetboard()
        {
            states.Reset();
        }
        public void clickboard(int xmouseposition, int ymouseposition, Panel p1, Panel p2)
        {
            BeadPosition click2position = pixeltoposition(xmouseposition, ymouseposition);
            if (states[click2position.X, click2position.Y] != -6) // شاه سیاه 
            {
                // اگر مهرای در مکانی که کلیک شد وجود داشت و مهره سفید بود
                if (states[click2position.X, click2position.Y] != 0 && states[click2position.X, click2position.Y] > 0)
                {
                    ////  *1 متغییر کمکی برای استفاده در قسمت
                    BeadPosition tempbp = new BeadPosition(selectcell);
                    ////  *2 متغییر کمکی برای استفاده در قسمت
                    ArrayList tempar = new ArrayList();
                    foreach (BeadPosition t2 in selectcellmoves)
                        tempar.Add(t2);
                    //*1////////// رسم و حذف خانه انتخاب شده  //////////////
                    selectcell = click2position;
                    if (tempbp == selectcell)
                    {
                        selectcell.setNull();
                        selectcellmoves.Clear();

                    }
                    CellPaint(tempbp.X, tempbp.Y, ctr.CreateGraphics());// خانه قبلی انتخاب شده
                    CellPaint(selectcell.X, selectcell.Y, ctr.CreateGraphics());//خانه جدید
                    //*2///// رسم و حذف خانه هایی که میشود به آنها حرکت کرد ///////
                    if (selectcell.X <= 8 && selectcell.Y <= 8 && selectcell.Y != 0 && selectcell.X != 0)
                        selectcellmoves = moves.BeadCanMoveList(ref selectcell, ref states);
                    for (int i = 0; i < tempar.Count; i++)
                        CellPaint(((BeadPosition)tempar[i]).X, ((BeadPosition)tempar[i]).Y, ctr.CreateGraphics());//  پاک کردن خانه های قبلی که میشود به آنها حرکت کرد
                    for (int i = 0; i < selectcellmoves.Count; i++)
                        CellPaint(((BeadPosition)selectcellmoves[i]).X, ((BeadPosition)selectcellmoves[i]).Y, ctr.CreateGraphics());// رسم خانه های جدید
                }// حرکت دادن مهره در صورتی که کلیک دوم در مکان قابل حرکت زده شد
                else if (selectcellmoves.Contains(click2position))
                {
                 //   bool canreplace = true;
                  ///  if (states[click2position.X, click2position.Y] != 0)
                    //    if (states[click2position.X, click2position.Y] < 0)
                   //         if (states[click2position.X, click2position.Y] == 6)
                           //     canreplace = false;// شاه سیاه نباید ریپلیس شود
                //    if (canreplace)
                    {
                        // اگر با این حرکت کیش نمی شود
                        sbyte x = states[click2position.X, click2position.Y];
                        states[click2position.X, click2position.Y] = states[selectcell.X, selectcell.Y];
                        states[selectcell.X, selectcell.Y] = 0;
                        bool isch = false;
                        if (isch = moves.InCheck(1, ref states))
                        {
                            states[selectcell.X, selectcell.Y] = states[click2position.X, click2position.Y];
                            states[click2position.X, click2position.Y] = x;
                            paintBoard(ctr.CreateGraphics());
                            MessageBox.Show("!!! کیش");
                        }
                        else
                        {
                            states[selectcell.X, selectcell.Y] = states[click2position.X, click2position.Y];
                            states[click2position.X, click2position.Y] = x;
                        }
                        if (isch) return;
                        MoveBead(new BeadPosition(selectcell.X, selectcell.Y), new BeadPosition(click2position.X, click2position.Y), true);
                        p2.Enabled = true;
                        p2.Controls[1].Visible = true;
                        p1.Enabled = false;
                        p1.Controls[1].Visible = false;
                        p2.Refresh();
                        think TH = new think();
                        States copstates = states.copy();
                        Stir TMP = TH.Main_think(this, 0);
                        states = copstates;
                        if (TMP.T.Y == 8 && states[TMP.F.X, TMP.F.Y] == -1)
                            states[TMP.F.X, TMP.F.Y] = -5;
                        MoveBead(TMP, true);
                        p2.Controls[1].Visible = false;
                        p2.Enabled = false;
                        p1.Enabled = true;
                        p1.Controls[1].Visible = true;
                    }

                }
            }
        }
        public States MoveBead(BeadPosition a, BeadPosition b, bool show)
        {

            if (b.Y == 0 && states[a.X, a.Y] == 1)
            {
                selectbead frms = new selectbead();
                while (frms.ShowDialog() != DialogResult.OK);
                switch (frms.post)
                {
                    case "Knight":
                        states[b.X, b.Y] = 2;
                        break;
                    case "Bishop":
                        states[b.X, b.Y] = 3;
                        break;
                    case "Rook":
                        states[b.X, b.Y] = 4;
                        break;
                    case "Queen":
                        states[b.X, b.Y] = 5;
                        break;
                }
            }
            else if (b.Y==8 && states[a.X, a.Y] == -1)
                states[b.X, b.Y] = -5;
            else
                states[b.X, b.Y] = states[a.X, a.Y];
            states[a.X, a.Y] = 0;
            ////  *1 متغییر کمکی برای استفاده در قسمت
            BeadPosition tempbp = new BeadPosition(selectcell);
            ////  *2 متغییر کمکی برای استفاده در قسمت
            ArrayList tempar = new ArrayList();
            foreach (BeadPosition t2 in selectcellmoves)
                tempar.Add(t2);
            ////
            selectcell.setNull();
            selectcellmoves.Clear();
            if (show)
            {
                CellPaint(tempbp.X, tempbp.Y, ctr.CreateGraphics());//*1 // دوباره کشیدن خانه انتخاب شده
                for (int i = 0; i < tempar.Count; i++)//*2 // دوباره کشیدن خانه هایی که راهنمای حرکت مهره انتخاب شده بود
                    CellPaint(((BeadPosition)tempar[i]).X, ((BeadPosition)tempar[i]).Y, ctr.CreateGraphics());//  پاک کردن خانه های قبلی که میشود به آنها حرکت کرد
                ///// برای رفرش شدن مهره های حریف ، چون مهره های حریف هیچوقت انتخاب نمیشود که دوباره کشیده شود
                CellPaint(a.X, a.Y, ctr.CreateGraphics());
                CellPaint(b.X, b.Y, ctr.CreateGraphics());
            }
            return states;
        }
        public States MoveBead(Stir St, bool show)
        {
            BeadPosition a = new BeadPosition(St.F.X, St.F.Y);
            BeadPosition b = new BeadPosition(St.T.X, St.T.Y);
            return MoveBead(a, b, show);
        }
    }
}