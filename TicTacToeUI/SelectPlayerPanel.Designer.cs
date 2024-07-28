using TicTacToeUI.gui;

namespace TicTacToeUI
{
	partial class SelectPlayerPanel
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
			label1 = new Label();
			cmbPlayer1Type = new ComboBox();
			label2 = new Label();
			cmbPlayer2Type = new ComboBox();
			button1 = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(26, 23);
			label1.Name = "label1";
			label1.Size = new Size(51, 15);
			label1.TabIndex = 0;
			label1.Text = "Player 1:";
			// 
			// cmbPlayer1Type
			// 
			cmbPlayer1Type.FormattingEnabled = true;
			cmbPlayer1Type.Location = new Point(97, 20);
			cmbPlayer1Type.Name = "cmbPlayer1Type";
			cmbPlayer1Type.Size = new Size(170, 23);
			cmbPlayer1Type.TabIndex = 1;
			cmbPlayer1Type.SelectionChangeCommitted += cmbPlayer1Type_SelectionChangeCommitted;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(302, 23);
			label2.Name = "label2";
			label2.Size = new Size(51, 15);
			label2.TabIndex = 2;
			label2.Text = "Player 2:";
			// 
			// cmbPlayer2Type
			// 
			cmbPlayer2Type.FormattingEnabled = true;
			cmbPlayer2Type.Location = new Point(382, 20);
			cmbPlayer2Type.Name = "cmbPlayer2Type";
			cmbPlayer2Type.Size = new Size(170, 23);
			cmbPlayer2Type.TabIndex = 3;
			cmbPlayer2Type.SelectionChangeCommitted += cmbPlayer2Type_SelectionChangeCommitted;
			// 
			// button1
			// 
			button1.Location = new Point(232, 142);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 4;
			button1.Text = "OK";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// SelectPlayerPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(584, 450);
			Controls.Add(button1);
			Controls.Add(cmbPlayer2Type);
			Controls.Add(label2);
			Controls.Add(cmbPlayer1Type);
			Controls.Add(label1);
			Name = "SelectPlayerPanel";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "SelectPlayerPanel";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ComboBox cmbPlayer1Type;
		private Label label2;
		private ComboBox cmbPlayer2Type;
		private Button button1;
	}
}