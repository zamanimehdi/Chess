using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    public partial class frm_main : Form
    {
        Board chessboard;
        int ymouseposition;
        int xmouseposition;
        public frm_main()
        {
            InitializeComponent();
            chessboard = new Board(pib_board.Width / 8, pib_board.Height / 8, pib_board);
        }
        private void pib_board_Paint(object sender, PaintEventArgs e)
        {
            chessboard.paintBoard(e.Graphics);
        }
        private void pib_board_MouseMove(object sender, MouseEventArgs e)
        {
            chessboard.MouseMoveboard(e);
            xmouseposition = e.Location.X;
            ymouseposition = e.Location.Y;
        }
        private void pib_board_MouseLeave(object sender, EventArgs e)
        {
            chessboard.MouseLeaveCell();
        }
        private void pib_board_Click(object sender, EventArgs e)
        {
          //treeView1.Nodes.Clear();
          /*treeView1.Nodes.Add(*/chessboard.clickboard(xmouseposition, ymouseposition,p1,p2)/*)*/;
        }
     
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

   
    }
}