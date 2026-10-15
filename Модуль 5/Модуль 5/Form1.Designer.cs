
namespace Модуль_5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLine = new Button();
            btnCircle = new Button();
            btnSquare = new Button();
            btnClear = new Button();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLine
            // 
            btnLine.Location = new Point(3, 3);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(88, 39);
            btnLine.TabIndex = 0;
            btnLine.Text = "Линия";
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // btnCircle
            // 
            btnCircle.Location = new Point(97, 3);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(94, 39);
            btnCircle.TabIndex = 1;
            btnCircle.Text = "Круг";
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;
            // 
            // btnSquare
            // 
            btnSquare.Location = new Point(197, 3);
            btnSquare.Name = "btnSquare";
            btnSquare.Size = new Size(94, 39);
            btnSquare.TabIndex = 2;
            btnSquare.Text = "Квадрат";
            btnSquare.UseVisualStyleBackColor = true;
            btnSquare.Click += btnSquare_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(297, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 39);
            btnClear.TabIndex = 3;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 403);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += OnCanvasClick;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnLine);
            flowLayoutPanel1.Controls.Add(btnCircle);
            flowLayoutPanel1.Controls.Add(btnSquare);
            flowLayoutPanel1.Controls.Add(btnClear);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 403);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 47);
            flowLayoutPanel1.TabIndex = 5;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Рисование фигур";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Button btnLine;
        private Button btnCircle;
        private Button btnSquare;
        private Button btnClear;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
