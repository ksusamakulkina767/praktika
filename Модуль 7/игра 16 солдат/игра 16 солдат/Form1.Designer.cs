namespace игра_16_солдат
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelLeft = new System.Windows.Forms.Panel();
            btnMode = new System.Windows.Forms.Button();
            btnRules = new System.Windows.Forms.Button();
            btnDraw = new System.Windows.Forms.Button();
            btnSurrender = new System.Windows.Forms.Button();
            btnNewGame = new System.Windows.Forms.Button();
            panelTop = new System.Windows.Forms.Panel();
            lblStatus = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            panelBottom = new System.Windows.Forms.Panel();
            lblRedScore = new System.Windows.Forms.Label();
            lblGreenScore = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = System.Drawing.Color.FromArgb(245, 247, 248);
            panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelLeft.Controls.Add(btnMode);
            panelLeft.Controls.Add(btnRules);
            panelLeft.Controls.Add(btnDraw);
            panelLeft.Controls.Add(btnSurrender);
            panelLeft.Controls.Add(btnNewGame);
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(155, 571);
            panelLeft.TabIndex = 0;
            // 
            // btnMode
            // 
            btnMode.BackColor = System.Drawing.Color.DarkCyan;
            btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnMode.ForeColor = System.Drawing.Color.White;
            btnMode.Location = new System.Drawing.Point(15, 205);
            btnMode.Name = "btnMode";
            btnMode.Size = new System.Drawing.Size(124, 38);
            btnMode.TabIndex = 4;
            btnMode.Text = "Режим: Бот";
            btnMode.UseVisualStyleBackColor = false;
            // 
            // btnRules
            // 
            btnRules.BackColor = System.Drawing.Color.FromArgb(32, 178, 170);
            btnRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRules.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnRules.ForeColor = System.Drawing.Color.White;
            btnRules.Location = new System.Drawing.Point(15, 160);
            btnRules.Name = "btnRules";
            btnRules.Size = new System.Drawing.Size(124, 38);
            btnRules.TabIndex = 3;
            btnRules.Text = "Правила";
            btnRules.UseVisualStyleBackColor = false;
            // 
            // btnDraw
            // 
            btnDraw.BackColor = System.Drawing.Color.FromArgb(32, 178, 170);
            btnDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDraw.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnDraw.ForeColor = System.Drawing.Color.White;
            btnDraw.Location = new System.Drawing.Point(15, 115);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new System.Drawing.Size(124, 38);
            btnDraw.TabIndex = 2;
            btnDraw.Text = "Ничья";
            btnDraw.UseVisualStyleBackColor = false;
            // 
            // btnSurrender
            // 
            btnSurrender.BackColor = System.Drawing.Color.FromArgb(32, 178, 170);
            btnSurrender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSurrender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnSurrender.ForeColor = System.Drawing.Color.White;
            btnSurrender.Location = new System.Drawing.Point(15, 70);
            btnSurrender.Name = "btnSurrender";
            btnSurrender.Size = new System.Drawing.Size(124, 38);
            btnSurrender.TabIndex = 1;
            btnSurrender.Text = "Сдаться";
            btnSurrender.UseVisualStyleBackColor = false;
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = System.Drawing.Color.FromArgb(32, 178, 170);
            btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNewGame.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnNewGame.ForeColor = System.Drawing.Color.White;
            btnNewGame.Location = new System.Drawing.Point(15, 25);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new System.Drawing.Size(124, 38);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "Новая игра";
            btnNewGame.UseVisualStyleBackColor = false;
            // 
            // panelTop
            // 
            panelTop.BackColor = System.Drawing.Color.FromArgb(240, 244, 245);
            panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelTop.Controls.Add(lblStatus);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(155, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(839, 45);
            panelTop.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            lblStatus.Location = new System.Drawing.Point(680, 11);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(107, 19);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Ход: Зеленые";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            lblTitle.Location = new System.Drawing.Point(315, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(175, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ИГРА «16 СОЛДАТ»";
            // 
            // panelBottom
            // 
            panelBottom.BackColor = System.Drawing.Color.FromArgb(240, 244, 245);
            panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelBottom.Controls.Add(lblRedScore);
            panelBottom.Controls.Add(lblGreenScore);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(155, 526);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(839, 45);
            panelBottom.TabIndex = 2;
            // 
            // lblRedScore
            // 
            lblRedScore.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblRedScore.AutoSize = true;
            lblRedScore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblRedScore.ForeColor = System.Drawing.Color.Crimson;
            lblRedScore.Location = new System.Drawing.Point(695, 11);
            lblRedScore.Name = "lblRedScore";
            lblRedScore.Size = new System.Drawing.Size(95, 19);
            lblRedScore.TabIndex = 1;
            lblRedScore.Text = "Красные: 16";
            // 
            // lblGreenScore
            // 
            lblGreenScore.AutoSize = true;
            lblGreenScore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblGreenScore.ForeColor = System.Drawing.Color.ForestGreen;
            lblGreenScore.Location = new System.Drawing.Point(20, 11);
            lblGreenScore.Name = "lblGreenScore";
            lblGreenScore.Size = new System.Drawing.Size(99, 19);
            lblGreenScore.TabIndex = 0;
            lblGreenScore.Text = "Зеленые: 16";
            // 
            // pictureBox1
            // 
        
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Location = new System.Drawing.Point(155, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(839, 481);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(994, 571);
            Controls.Add(pictureBox1);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "16 солдат (Шоло Гути)";
            panelLeft.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnSurrender;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblGreenScore;
        private System.Windows.Forms.Label lblRedScore;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}