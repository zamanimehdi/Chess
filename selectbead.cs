using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    public partial class selectbead : Form
    {
        public string post;
        public selectbead()
        {
            InitializeComponent();
        }
        private void pib_Knight_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.LavenderBlush;
        }
        private void pib_Knight_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Gainsboro;
        }
        private void pib_Knight_Click(object sender, EventArgs e)
        {
            post = "Knight";
            DialogResult = DialogResult.OK;
        }
        private void pib_Bishop_Click(object sender, EventArgs e)
        {
            post = "Bishop";
            DialogResult = DialogResult.OK;
        }
        private void pib_Rook_Click(object sender, EventArgs e)
        {
            post = "Rook";
            DialogResult = DialogResult.OK;
        }
        private void pib_Queen_Click(object sender, EventArgs e)
        {
            post = "Queen"; 
            DialogResult=DialogResult.OK;
        }
    }
}