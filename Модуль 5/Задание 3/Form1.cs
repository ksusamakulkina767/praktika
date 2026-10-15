using System;
using System.Drawing;
using System.Windows.Forms;

namespace Задание_3
{
    public partial class Form1 : Form
    {
        private CheckedListBox myLstTasks = null!;
        private TextBox myTxtTaskInput = null!;
        private Button myBtnAdd = null!;
        private Button myBtnDelete = null!;
        private Button myBtnClearDone = null!;

        public Form1()
        {
            try { InitializeComponent(); } catch { }
            CreateTaskUI();
        }

        private void CreateTaskUI()
        {
            this.Text = "Учет задач";
            this.Size = new Size(450, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            myTxtTaskInput = new TextBox
            {
                Location = new Point(15, 15),
                Size = new Size(280, 25),
                Font = new Font("Segoe UI", 10)
            };

            myBtnAdd = new Button
            {
                Text = "Добавить",
                Location = new Point(305, 14),
                Size = new Size(110, 27),
                Font = new Font("Segoe UI", 9)
            };
            myBtnAdd.Click += BtnAdd_Click;

            myLstTasks = new CheckedListBox
            {
                Location = new Point(15, 50),
                Size = new Size(400, 340),
                Font = new Font("Segoe UI", 10),
                CheckOnClick = true
            };

            myBtnDelete = new Button
            {
                Text = "Удалить выбранное",
                Location = new Point(15, 410),
                Size = new Size(190, 30),
                Font = new Font("Segoe UI", 9)
            };
            myBtnDelete.Click += BtnDelete_Click;

            myBtnClearDone = new Button
            {
                Text = "Удалить выполненные",
                Location = new Point(225, 410),
                Size = new Size(190, 30),
                Font = new Font("Segoe UI", 9)
            };
            myBtnClearDone.Click += BtnClearDone_Click;

            this.Controls.Add(myTxtTaskInput);
            this.Controls.Add(myBtnAdd);
            this.Controls.Add(myLstTasks);
            this.Controls.Add(myBtnDelete);
            this.Controls.Add(myBtnClearDone);

            this.AcceptButton = myBtnAdd;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(myTxtTaskInput.Text))
            {
                myLstTasks.Items.Add(myTxtTaskInput.Text.Trim(), false);
                myTxtTaskInput.Clear();
                myTxtTaskInput.Focus();
            }
            else
            {
                MessageBox.Show("Введите текст задачи!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (myLstTasks.SelectedIndex != -1)
            {
                myLstTasks.Items.RemoveAt(myLstTasks.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnClearDone_Click(object? sender, EventArgs e)
        {
            for (int i = myLstTasks.Items.Count - 1; i >= 0; i--)
            {
                if (myLstTasks.GetItemChecked(i))
                {
                    myLstTasks.Items.RemoveAt(i);
                }
            }
        }

        // --- Заглушки для удаленных событий из дизайнера ---
        private void Form1_Load(object sender, EventArgs e) { }
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtTaskInput_TextChanged(object sender, EventArgs e) { }
    }
}