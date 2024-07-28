namespace TicTacToeUI
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            labelScore2 = new Label();
            labelPlayer2 = new Label();
            labelScore1 = new Label();
            labelPlayer1 = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            gamePanel = new TableLayoutPanel();
            txt21 = new Label();
            txt22 = new Label();
            txt00 = new Label();
            txt01 = new Label();
            txt02 = new Label();
            txt10 = new Label();
            txt11 = new Label();
            txt12 = new Label();
            txt20 = new Label();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            gamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelScore2);
            groupBox1.Controls.Add(labelPlayer2);
            groupBox1.Controls.Add(labelScore1);
            groupBox1.Controls.Add(labelPlayer1);
            groupBox1.Location = new Point(28, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(362, 53);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Scores:";
            // 
            // labelScore2
            // 
            labelScore2.AutoSize = true;
            labelScore2.Location = new Point(231, 15);
            labelScore2.Name = "labelScore2";
            labelScore2.Size = new Size(0, 15);
            labelScore2.TabIndex = 3;
            // 
            // labelPlayer2
            // 
            labelPlayer2.AutoSize = true;
            labelPlayer2.Location = new Point(174, 15);
            labelPlayer2.Name = "labelPlayer2";
            labelPlayer2.Size = new Size(51, 15);
            labelPlayer2.TabIndex = 2;
            labelPlayer2.Text = "Player 2:";
            // 
            // labelScore1
            // 
            labelScore1.AutoSize = true;
            labelScore1.Location = new Point(73, 17);
            labelScore1.Name = "labelScore1";
            labelScore1.Size = new Size(0, 15);
            labelScore1.TabIndex = 1;
            // 
            // labelPlayer1
            // 
            labelPlayer1.AutoSize = true;
            labelPlayer1.Location = new Point(15, 15);
            labelPlayer1.Name = "labelPlayer1";
            labelPlayer1.Size = new Size(51, 15);
            labelPlayer1.TabIndex = 0;
            labelPlayer1.Text = "Player 1:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(454, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(132, 22);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(132, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // gamePanel
            // 
            gamePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            gamePanel.ColumnCount = 3;
            gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            gamePanel.Controls.Add(txt21, 1, 2);
            gamePanel.Controls.Add(txt22, 2, 2);
            gamePanel.Controls.Add(txt00, 0, 0);
            gamePanel.Controls.Add(txt01, 1, 0);
            gamePanel.Controls.Add(txt02, 2, 0);
            gamePanel.Controls.Add(txt10, 0, 1);
            gamePanel.Controls.Add(txt11, 1, 1);
            gamePanel.Controls.Add(txt12, 2, 1);
            gamePanel.Controls.Add(txt20, 0, 2);
            gamePanel.Location = new Point(43, 95);
            gamePanel.MinimumSize = new Size(334, 304);
            gamePanel.Name = "gamePanel";
            gamePanel.RowCount = 3;
            gamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gamePanel.Size = new Size(334, 304);
            gamePanel.TabIndex = 2;
            // 
            // txt21
            // 
            txt21.AutoSize = true;
            txt21.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt21.Location = new Point(114, 203);
            txt21.Name = "txt21";
            txt21.Padding = new Padding(19);
            txt21.Size = new Size(38, 96);
            txt21.TabIndex = 9;
            txt21.TextAlign = ContentAlignment.MiddleCenter;
            txt21.Click += txt21_Click;
            // 
            // txt22
            // 
            txt22.AutoSize = true;
            txt22.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt22.Location = new Point(225, 203);
            txt22.Name = "txt22";
            txt22.Padding = new Padding(19);
            txt22.Size = new Size(38, 96);
            txt22.TabIndex = 8;
            txt22.TextAlign = ContentAlignment.MiddleCenter;
            txt22.Click += txt22_Click;
            // 
            // txt00
            // 
            txt00.AutoSize = true;
            txt00.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt00.Location = new Point(4, 1);
            txt00.Name = "txt00";
            txt00.Padding = new Padding(19);
            txt00.Size = new Size(38, 96);
            txt00.TabIndex = 0;
            txt00.TextAlign = ContentAlignment.MiddleCenter;
            txt00.Click += txt00_Click;
            // 
            // txt01
            // 
            txt01.AutoSize = true;
            txt01.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt01.Location = new Point(114, 1);
            txt01.Name = "txt01";
            txt01.Padding = new Padding(19);
            txt01.Size = new Size(38, 96);
            txt01.TabIndex = 1;
            txt01.TextAlign = ContentAlignment.MiddleCenter;
            txt01.Click += txt01_Click;
            // 
            // txt02
            // 
            txt02.AutoSize = true;
            txt02.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt02.Location = new Point(225, 1);
            txt02.Name = "txt02";
            txt02.Padding = new Padding(19);
            txt02.Size = new Size(38, 96);
            txt02.TabIndex = 2;
            txt02.TextAlign = ContentAlignment.MiddleCenter;
            txt02.Click += txt02_Click;
            // 
            // txt10
            // 
            txt10.AutoSize = true;
            txt10.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt10.Location = new Point(4, 102);
            txt10.Name = "txt10";
            txt10.Padding = new Padding(19);
            txt10.Size = new Size(38, 96);
            txt10.TabIndex = 3;
            txt10.Click += txt10_Click;
            // 
            // txt11
            // 
            txt11.AutoSize = true;
            txt11.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt11.Location = new Point(114, 102);
            txt11.Name = "txt11";
            txt11.Padding = new Padding(19);
            txt11.Size = new Size(38, 96);
            txt11.TabIndex = 4;
            txt11.Click += txt11_Click;
            // 
            // txt12
            // 
            txt12.AutoSize = true;
            txt12.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt12.Location = new Point(225, 102);
            txt12.Name = "txt12";
            txt12.Padding = new Padding(19);
            txt12.Size = new Size(38, 96);
            txt12.TabIndex = 5;
            txt12.TextAlign = ContentAlignment.MiddleCenter;
            txt12.Click += txt12_Click;
            // 
            // txt20
            // 
            txt20.AutoSize = true;
            txt20.Font = new Font("Tahoma", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt20.Location = new Point(4, 203);
            txt20.Name = "txt20";
            txt20.Padding = new Padding(19);
            txt20.Size = new Size(38, 96);
            txt20.TabIndex = 6;
            txt20.Click += txt20_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 411);
            Controls.Add(gamePanel);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(450, 450);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agent Tic Tac Toe";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            gamePanel.ResumeLayout(false);
            gamePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelScore1;
        private Label labelPlayer1;
        private Label labelScore2;
        private Label labelPlayer2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TableLayoutPanel gamePanel;
        private Label txt00;
        private Label txt01;
        private Label txt02;
        private Label txt10;
        private Label txt11;
        private Label txt12;
        private Label txt20;
        private Label txt21;
        private Label txt22;
    }
}
