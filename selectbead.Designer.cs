namespace Chess
{
    partial class selectbead
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
            this.pib_Queen = new System.Windows.Forms.PictureBox();
            this.pib_Rook = new System.Windows.Forms.PictureBox();
            this.pib_Bishop = new System.Windows.Forms.PictureBox();
            this.pib_Knight = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pib_Queen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pib_Rook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pib_Bishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pib_Knight)).BeginInit();
            this.SuspendLayout();
            // 
            // pib_Queen
            // 
            this.pib_Queen.BackColor = System.Drawing.Color.Gainsboro;
            this.pib_Queen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pib_Queen.Image = global::Chess.Properties.Resources.Queen_White;
            this.pib_Queen.Location = new System.Drawing.Point(11, 7);
            this.pib_Queen.Name = "pib_Queen";
            this.pib_Queen.Size = new System.Drawing.Size(49, 50);
            this.pib_Queen.TabIndex = 1;
            this.pib_Queen.TabStop = false;
            this.pib_Queen.MouseLeave += new System.EventHandler(this.pib_Knight_MouseLeave);
            this.pib_Queen.Click += new System.EventHandler(this.pib_Queen_Click);
            this.pib_Queen.MouseEnter += new System.EventHandler(this.pib_Knight_MouseEnter);
            // 
            // pib_Rook
            // 
            this.pib_Rook.BackColor = System.Drawing.Color.Gainsboro;
            this.pib_Rook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pib_Rook.Image = global::Chess.Properties.Resources.Rook_White;
            this.pib_Rook.Location = new System.Drawing.Point(66, 7);
            this.pib_Rook.Name = "pib_Rook";
            this.pib_Rook.Size = new System.Drawing.Size(49, 50);
            this.pib_Rook.TabIndex = 1;
            this.pib_Rook.TabStop = false;
            this.pib_Rook.MouseLeave += new System.EventHandler(this.pib_Knight_MouseLeave);
            this.pib_Rook.Click += new System.EventHandler(this.pib_Rook_Click);
            this.pib_Rook.MouseEnter += new System.EventHandler(this.pib_Knight_MouseEnter);
            // 
            // pib_Bishop
            // 
            this.pib_Bishop.BackColor = System.Drawing.Color.Gainsboro;
            this.pib_Bishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pib_Bishop.Image = global::Chess.Properties.Resources.Bishop_White;
            this.pib_Bishop.Location = new System.Drawing.Point(121, 7);
            this.pib_Bishop.Name = "pib_Bishop";
            this.pib_Bishop.Size = new System.Drawing.Size(49, 50);
            this.pib_Bishop.TabIndex = 1;
            this.pib_Bishop.TabStop = false;
            this.pib_Bishop.MouseLeave += new System.EventHandler(this.pib_Knight_MouseLeave);
            this.pib_Bishop.Click += new System.EventHandler(this.pib_Bishop_Click);
            this.pib_Bishop.MouseEnter += new System.EventHandler(this.pib_Knight_MouseEnter);
            // 
            // pib_Knight
            // 
            this.pib_Knight.BackColor = System.Drawing.Color.Gainsboro;
            this.pib_Knight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pib_Knight.Image = global::Chess.Properties.Resources.Knight_White;
            this.pib_Knight.Location = new System.Drawing.Point(176, 7);
            this.pib_Knight.Name = "pib_Knight";
            this.pib_Knight.Size = new System.Drawing.Size(49, 50);
            this.pib_Knight.TabIndex = 1;
            this.pib_Knight.TabStop = false;
            this.pib_Knight.MouseLeave += new System.EventHandler(this.pib_Knight_MouseLeave);
            this.pib_Knight.Click += new System.EventHandler(this.pib_Knight_Click);
            this.pib_Knight.MouseEnter += new System.EventHandler(this.pib_Knight_MouseEnter);
            // 
            // selectbead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(235, 65);
            this.Controls.Add(this.pib_Knight);
            this.Controls.Add(this.pib_Bishop);
            this.Controls.Add(this.pib_Rook);
            this.Controls.Add(this.pib_Queen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "selectbead";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Select a Bead";
            ((System.ComponentModel.ISupportInitialize)(this.pib_Queen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pib_Rook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pib_Bishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pib_Knight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pib_Queen;
        private System.Windows.Forms.PictureBox pib_Rook;
        private System.Windows.Forms.PictureBox pib_Bishop;
        private System.Windows.Forms.PictureBox pib_Knight;
    }
}