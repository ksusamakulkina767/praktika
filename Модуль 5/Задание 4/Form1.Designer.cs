namespace Задание_4
{
    partial class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelImage = new Panel();
            picImage = new PictureBox();
            btnOpen = new Button();
            btnZoomIn = new Button();
            btnZoomOut = new Button();
            panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            SuspendLayout();
            // 
            // panelImage
            // 
            panelImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelImage.AutoScroll = true;
            panelImage.BackColor = SystemColors.ControlDark;
            panelImage.Controls.Add(picImage);
            panelImage.Location = new Point(12, 60);
            panelImage.Name = "panelImage";
            panelImage.Size = new Size(776, 378);
            panelImage.TabIndex = 0;
            // 
            // picImage
            // 
            picImage.Location = new Point(0, 0);
            picImage.Name = "picImage";
            picImage.Size = new Size(100, 50);
            picImage.SizeMode = PictureBoxSizeMode.AutoSize;
            picImage.TabIndex = 0;
            picImage.TabStop = false;
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnOpen.Location = new Point(12, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(150, 35);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Открыть файл";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += BtnOpen_Click;
            // 
            // btnZoomIn
            // 
            btnZoomIn.Font = new Font("Arial", 10.2F);
            btnZoomIn.Location = new Point(180, 12);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(45, 35);
            btnZoomIn.TabIndex = 2;
            btnZoomIn.Text = "+";
            btnZoomIn.UseVisualStyleBackColor = true;
            btnZoomIn.Click += BtnZoomIn_Click;
            // 
            // btnZoomOut
            // 
            btnZoomOut.Font = new Font("Arial", 10.2F);
            btnZoomOut.Location = new Point(231, 12);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(45, 35);
            btnZoomOut.TabIndex = 3;
            btnZoomOut.Text = "-";
            btnZoomOut.UseVisualStyleBackColor = true;
            btnZoomOut.Click += BtnZoomOut_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnZoomOut);
            Controls.Add(btnZoomIn);
            Controls.Add(btnOpen);
            Controls.Add(panelImage);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр изображений";
            Load += Form1_Load;
            panelImage.ResumeLayout(false);
            panelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
    }
}