namespace Chess
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clbl = new System.Windows.Forms.Label();
            this.ylbl = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.Panel();
            this.upic = new System.Windows.Forms.PictureBox();
            this.p2 = new System.Windows.Forms.Panel();
            this.cpic = new System.Windows.Forms.PictureBox();
            this.pib_board = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.p1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upic)).BeginInit();
            this.p2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pib_board)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 431);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(416, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "      1           2           3           4            5           6           7 " +
                "          8";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(17, 397);
            this.label1.TabIndex = 9;
            this.label1.Text = "      A        B       C        D        E        F       G        H";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "_________________________________________________________________________";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(474, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.helpToolStripMenuItem.Text = "راهنما";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.aboutToolStripMenuItem.Text = "درباره  برنامه";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // clbl
            // 
            this.clbl.AutoSize = true;
            this.clbl.Location = new System.Drawing.Point(3, 9);
            this.clbl.Name = "clbl";
            this.clbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clbl.Size = new System.Drawing.Size(96, 13);
            this.clbl.TabIndex = 13;
            this.clbl.Text = "Computer Thinking";
            // 
            // ylbl
            // 
            this.ylbl.AutoSize = true;
            this.ylbl.Location = new System.Drawing.Point(28, 9);
            this.ylbl.Name = "ylbl";
            this.ylbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ylbl.Size = new System.Drawing.Size(54, 13);
            this.ylbl.TabIndex = 14;
            this.ylbl.Text = "Your Turn";
            // 
            // p1
            // 
            this.p1.Controls.Add(this.ylbl);
            this.p1.Controls.Add(this.upic);
            this.p1.Location = new System.Drawing.Point(322, 468);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(115, 36);
            this.p1.TabIndex = 16;
            // 
            // upic
            // 
            this.upic.Image = global::Chess.Properties.Resources.admin_24;
            this.upic.Location = new System.Drawing.Point(88, 3);
            this.upic.Name = "upic";
            this.upic.Size = new System.Drawing.Size(24, 24);
            this.upic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.upic.TabIndex = 15;
            this.upic.TabStop = false;
            // 
            // p2
            // 
            this.p2.Controls.Add(this.clbl);
            this.p2.Controls.Add(this.cpic);
            this.p2.Enabled = false;
            this.p2.Location = new System.Drawing.Point(36, 468);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(144, 36);
            this.p2.TabIndex = 16;
            // 
            // cpic
            // 
            this.cpic.Image = global::Chess.Properties.Resources.fSEARCH_00;
            this.cpic.Location = new System.Drawing.Point(105, 8);
            this.cpic.Name = "cpic";
            this.cpic.Size = new System.Drawing.Size(18, 19);
            this.cpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cpic.TabIndex = 12;
            this.cpic.TabStop = false;
            this.cpic.Visible = false;
            // 
            // pib_board
            // 
            this.pib_board.Location = new System.Drawing.Point(27, 38);
            this.pib_board.Name = "pib_board";
            this.pib_board.Size = new System.Drawing.Size(419, 388);
            this.pib_board.TabIndex = 0;
            this.pib_board.TabStop = false;
            this.pib_board.MouseLeave += new System.EventHandler(this.pib_board_MouseLeave);
            this.pib_board.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pib_board_MouseMove);
            this.pib_board.Click += new System.EventHandler(this.pib_board_Click);
            this.pib_board.Paint += new System.Windows.Forms.PaintEventHandler(this.pib_board_Paint);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(474, 506);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pib_board);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.p1.ResumeLayout(false);
            this.p1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upic)).EndInit();
            this.p2.ResumeLayout(false);
            this.p2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pib_board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pib_board;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox cpic;
        private System.Windows.Forms.Label clbl;
        private System.Windows.Forms.Label ylbl;
        private System.Windows.Forms.PictureBox upic;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Panel p2;
    }
}

