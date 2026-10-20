using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace игра_16_солдат
{
    public partial class Form1 : Form
    {
        public class Node
        {
            public int Id { get; set; }
            public Point Pt { get; set; }
            public int Owner { get; set; } // 0 - пусто, 1 - Зеленые, 2 - Красные
            public List<int> Neighbors { get; set; } = new List<int>();

            public Node(int id, Point pt)
            {
                Id = id;
                Pt = pt;
                Owner = 0;
            }
        }

        private readonly List<Node> boardNodes = new List<Node>();
        private Node? selectedNode = null;
        private int currentPlayer = 1; // 1 - Зеленые, 2 - Красные
        private int greenScore = 0;
        private int redScore = 0;
        private bool vsBot = true;     // Режим с ботом по умолчанию

        private System.Windows.Forms.Timer botTimer;

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;

            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.MouseClick += PictureBox1_MouseClick;

            btnNewGame.Click += (s, e) => { ResetGame(); pictureBox1.Invalidate(); };
            btnSurrender.Click += BtnSurrender_Click;
            btnDraw.Click += BtnDraw_Click;
            btnRules.Click += BtnRules_Click;
            btnMode.Click += BtnMode_Click; // Обработчик нажатия на кнопку режима

            botTimer = new System.Windows.Forms.Timer();
            botTimer.Interval = 500;
            botTimer.Tick += BotTimer_Tick;

            pictureBox1.Resize += (s, e) => { BuildBoardGraph(); pictureBox1.Invalidate(); };

            BuildBoardGraph();
            ResetGame();
        }

        private void BtnMode_Click(object? sender, EventArgs e)
        {
            vsBot = !vsBot;
            btnMode.Text = vsBot ? "Режим: Бот" : "Режим: 2 Игрока";
            ResetGame();
            pictureBox1.Invalidate();
        }

        private void BtnSurrender_Click(object? sender, EventArgs e)
        {
            string winner = (currentPlayer == 1) ? "Красные" : "Зеленые";
            MessageBox.Show($"Игрок сдался! Победили {winner}.", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetGame();
            pictureBox1.Invalidate();
        }

        private void BtnDraw_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Игроки согласились на ничью!", "Ничья", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetGame();
            pictureBox1.Invalidate();
        }

        private void BtnRules_Click(object? sender, EventArgs e)
        {
            string rulesText =
                "Правила игры «16 солдат» (Шоло Гути):\n\n" +
                "1. В игре участвуют два игрока: Зеленые и Красные. У каждого по 16 фишек.\n" +
                "2. Цель игры — срубить все фишки соперника.\n" +
                "3. Ход делается на любую соседнюю свободную точку по линиям сетки.\n" +
                "4. Чтобы срубить фишку врага, перепрыгните через неё на свободную точку сразу за ней.\n" +
                "5. В режиме «Бот» вы играете за Зеленых, а компьютер управляет Красными.";

            MessageBox.Show(rulesText, "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuildBoardGraph()
        {
            boardNodes.Clear();

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;
            int step = 52; // Расстояние между узлами

            int id = 0;

            // 1. Центральный квадрат 5x5 (ID: 0..24)
            for (int col = -2; col <= 2; col++)
            {
                for (int row = -2; row <= 2; row++)
                {
                    boardNodes.Add(new Node(id++, new Point(cx + col * step, cy + row * step)));
                }
            }

            // Связи внутри квадрата 5x5
            for (int i = 0; i < 25; i++)
            {
                int col = i / 5;
                int row = i % 5;

                if (row > 0) boardNodes[i].Neighbors.Add(i - 1);
                if (row < 4) boardNodes[i].Neighbors.Add(i + 1);
                if (col > 0) boardNodes[i].Neighbors.Add(i - 5);
                if (col < 4) boardNodes[i].Neighbors.Add(i + 5);

                if ((row + col) % 2 == 0)
                {
                    if (col > 0 && row > 0) boardNodes[i].Neighbors.Add(i - 6);
                    if (col > 0 && row < 4) boardNodes[i].Neighbors.Add(i - 4);
                    if (col < 4 && row > 0) boardNodes[i].Neighbors.Add(i + 4);
                    if (col < 4 && row < 4) boardNodes[i].Neighbors.Add(i + 6);
                }
            }

            // 2. ЛЕВЫЙ БОКОВОЙ ТРЕУГОЛЬНИК (6 точек: ID 25..30)
            boardNodes.Add(new Node(25, new Point(cx - 4 * step, cy - 2 * step)));
            boardNodes.Add(new Node(26, new Point(cx - 4 * step, cy - 1 * step)));
            boardNodes.Add(new Node(27, new Point(cx - 4 * step, cy + 1 * step)));
            boardNodes.Add(new Node(28, new Point(cx - 4 * step, cy + 2 * step)));

            boardNodes.Add(new Node(29, new Point(cx - 3 * step, cy - 1 * step)));
            boardNodes.Add(new Node(30, new Point(cx - 3 * step, cy + 1 * step)));

            Connect(25, 26); Connect(26, 27); Connect(27, 28);
            Connect(25, 29); Connect(26, 29); Connect(27, 29);
            Connect(26, 30); Connect(27, 30); Connect(28, 30);
            Connect(29, 30);

            Connect(29, 2);
            Connect(30, 2);

            // 3. ПРАВЫЙ БОКОВОЙ ТРЕУГОЛЬНИК (6 точек: ID 31..36)
            boardNodes.Add(new Node(31, new Point(cx + 3 * step, cy - 1 * step)));
            boardNodes.Add(new Node(32, new Point(cx + 3 * step, cy + 1 * step)));

            boardNodes.Add(new Node(33, new Point(cx + 4 * step, cy - 2 * step)));
            boardNodes.Add(new Node(34, new Point(cx + 4 * step, cy - 1 * step)));
            boardNodes.Add(new Node(35, new Point(cx + 4 * step, cy + 1 * step)));
            boardNodes.Add(new Node(36, new Point(cx + 4 * step, cy + 2 * step)));

            Connect(33, 34); Connect(34, 35); Connect(35, 36);
            Connect(33, 31); Connect(34, 31); Connect(35, 31);
            Connect(34, 32); Connect(35, 32); Connect(36, 32);
            Connect(31, 32);

            Connect(31, 22);
            Connect(32, 22);
        }

        private void Connect(int n1, int n2)
        {
            if (!boardNodes[n1].Neighbors.Contains(n2)) boardNodes[n1].Neighbors.Add(n2);
            if (!boardNodes[n2].Neighbors.Contains(n1)) boardNodes[n2].Neighbors.Add(n1);
        }

        private void ResetGame()
        {
            botTimer.Stop();
            currentPlayer = 1;
            greenScore = 0;
            redScore = 0;
            selectedNode = null;

            lblGreenScore.Text = "Зеленые: 16";
            lblRedScore.Text = "Красные: 16";
            lblStatus.Text = "Ход: Зеленые";

            for (int i = 0; i < boardNodes.Count; i++)
            {
                if (i < 10 || (i >= 25 && i <= 30))
                    boardNodes[i].Owner = 1;
                else if ((i >= 15 && i < 25) || (i >= 31 && i <= 36))
                    boardNodes[i].Owner = 2;
                else
                    boardNodes[i].Owner = 0;
            }
        }

        private void PictureBox1_MouseClick(object? sender, MouseEventArgs e)
        {
            if (vsBot && currentPlayer == 2) return;

            Node? clickedNode = boardNodes.Find(n => Math.Sqrt(Math.Pow(n.Pt.X - e.X, 2) + Math.Pow(n.Pt.Y - e.Y, 2)) < 18);
            if (clickedNode == null) return;

            ProcessPlayerClick(clickedNode);
        }

        private void ProcessPlayerClick(Node clickedNode)
        {
            if (selectedNode != null)
            {
                if (clickedNode.Owner == 0 && selectedNode.Neighbors.Contains(clickedNode.Id))
                {
                    ExecuteMove(selectedNode, clickedNode);
                }
                else if (clickedNode.Owner == 0)
                {
                    Node? midNode = FindMiddleNode(selectedNode, clickedNode);
                    if (midNode != null && midNode.Owner != 0 && midNode.Owner != currentPlayer)
                    {
                        midNode.Owner = 0;
                        if (currentPlayer == 1) greenScore++; else redScore++;

                        lblGreenScore.Text = $"Зеленые: {16 - redScore}";
                        lblRedScore.Text = $"Красные: {16 - greenScore}";

                        ExecuteMove(selectedNode, clickedNode);
                    }
                    else
                    {
                        selectedNode = null;
                    }
                }
                else
                {
                    selectedNode = (clickedNode.Owner == currentPlayer) ? clickedNode : null;
                }
            }
            else
            {
                if (clickedNode.Owner == currentPlayer)
                {
                    selectedNode = clickedNode;
                }
            }

            pictureBox1.Invalidate();

            if (vsBot && currentPlayer == 2)
            {
                botTimer.Start();
            }
        }

        private void ExecuteMove(Node fromNode, Node target)
        {
            target.Owner = currentPlayer;
            fromNode.Owner = 0;
            selectedNode = null;

            currentPlayer = (currentPlayer == 1) ? 2 : 1;
            lblStatus.Text = (currentPlayer == 1) ? "Ход: Зеленые" : "Ход: Красные (Бот)";
        }

        private Node? FindMiddleNode(Node start, Node end)
        {
            int midX = (start.Pt.X + end.Pt.X) / 2;
            int midY = (start.Pt.Y + end.Pt.Y) / 2;
            return boardNodes.Find(n => Math.Abs(n.Pt.X - midX) < 5 && Math.Abs(n.Pt.Y - midY) < 5);
        }

        private void BotTimer_Tick(object? sender, EventArgs e)
        {
            botTimer.Stop();

            // 1. Попытка срубить фишку игрока
            foreach (var redNode in boardNodes.FindAll(n => n.Owner == 2))
            {
                foreach (int neighborId in redNode.Neighbors)
                {
                    Node neighbor = boardNodes[neighborId];
                    if (neighbor.Owner == 1)
                    {
                        int targetX = neighbor.Pt.X + (neighbor.Pt.X - redNode.Pt.X);
                        int targetY = neighbor.Pt.Y + (neighbor.Pt.Y - redNode.Pt.Y);
                        Node? targetNode = boardNodes.Find(n => Math.Abs(n.Pt.X - targetX) < 5 && Math.Abs(n.Pt.Y - targetY) < 5 && n.Owner == 0);

                        if (targetNode != null)
                        {
                            neighbor.Owner = 0;
                            greenScore++;
                            lblGreenScore.Text = $"Зеленые: {16 - redScore}";

                            ExecuteMove(redNode, targetNode);
                            pictureBox1.Invalidate();
                            return;
                        }
                    }
                }
            }

            // 2. Обычный ход, если рубить нечего
            List<(Node from, Node to)> validMoves = new List<(Node, Node)>();
            foreach (var redNode in boardNodes.FindAll(n => n.Owner == 2))
            {
                foreach (int neighborId in redNode.Neighbors)
                {
                    Node neighbor = boardNodes[neighborId];
                    if (neighbor.Owner == 0)
                    {
                        validMoves.Add((redNode, neighbor));
                    }
                }
            }

            if (validMoves.Count > 0)
            {
                Random rnd = new Random();
                var move = validMoves[rnd.Next(validMoves.Count)];
                ExecuteMove(move.from, move.to);
            }

            pictureBox1.Invalidate();
        }

        private void PictureBox1_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen penBoard = new Pen(Color.FromArgb(70, 70, 70), 2))
            {
                foreach (var node in boardNodes)
                {
                    foreach (var neighborId in node.Neighbors)
                    {
                        Node neighbor = boardNodes[neighborId];
                        g.DrawLine(penBoard, node.Pt, neighbor.Pt);
                    }
                }
            }

            foreach (var node in boardNodes)
            {
                g.FillEllipse(Brushes.SaddleBrown, node.Pt.X - 4, node.Pt.Y - 4, 8, 8);

                if (node.Owner != 0)
                {
                    if (selectedNode != null && selectedNode.Id == node.Id)
                    {
                        using (Pen penHighlight = new Pen(Color.Gold, 4))
                        {
                            g.DrawEllipse(penHighlight, node.Pt.X - 16, node.Pt.Y - 16, 32, 32);
                        }
                    }

                    Brush pieceColor = (node.Owner == 1) ? Brushes.LimeGreen : Brushes.Crimson;
                    g.FillEllipse(pieceColor, node.Pt.X - 13, node.Pt.Y - 13, 26, 26);
                    g.DrawEllipse(Pens.Black, node.Pt.X - 13, node.Pt.Y - 13, 26, 26);
                }
            }
        }
    }
}