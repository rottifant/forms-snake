namespace snake
{
    partial class SnakeGame
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.score = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.board = new System.Windows.Forms.Panel();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.board.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGame,
            this.score});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGame
            // 
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(77, 20);
            this.newGame.Text = "New Game";
            this.newGame.Click += new System.EventHandler(this.NewGame);
            // 
            // score
            // 
            this.score.Enabled = false;
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(60, 20);
            this.score.Text = "Score: 0";
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 200;
            this.mainTimer.Tick += new System.EventHandler(this.MoveSnake);
            // 
            // board
            // 
            this.board.Controls.Add(this.instructionLabel);
            this.board.Controls.Add(this.mainLabel);
            this.board.Location = new System.Drawing.Point(0, 24);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(400, 400);
            this.board.TabIndex = 1;
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new System.Drawing.Point(120, 215);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(160, 13);
            this.instructionLabel.TabIndex = 1;
            this.instructionLabel.Text = "Press Enter to start a new game!";
            // 
            // mainLabel
            // 
            this.mainLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(0, 0);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(400, 400);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "🐍 SNAKE 🐍";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 424);
            this.Controls.Add(this.board);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "SnakeGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeDirection);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.board.ResumeLayout(false);
            this.board.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGame;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.ToolStripMenuItem score;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Label instructionLabel;
    }
}

