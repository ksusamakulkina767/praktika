namespace Задание_3
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
            txtTaskInput = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            lstTasks = new CheckedListBox();
            SuspendLayout();
            // 
            // txtTaskInput
            // 
            txtTaskInput.Font = new Font("Segoe UI", 12F);
            txtTaskInput.Location = new Point(12, 12);
            txtTaskInput.Name = "txtTaskInput";
            txtTaskInput.Size = new Size(460, 34);
            txtTaskInput.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.Location = new Point(12, 55);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(220, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить задачу";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Location = new Point(252, 55);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(220, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить выбранное";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // lstTasks
            // 
            lstTasks.Font = new Font("Segoe UI", 11F);
            lstTasks.FormattingEnabled = true;
            lstTasks.Location = new Point(485, 12);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(303, 424);
            lstTasks.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstTasks);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtTaskInput);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учет задач";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTaskInput;
        private Button btnAdd;
        private Button btnDelete;
        private CheckedListBox lstTasks;
    }
}