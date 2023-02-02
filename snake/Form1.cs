using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace snake
{
    public partial class SnakeGame : Form
    {

        private enum SnakeDirection
        {
            Up,
            Down,
            Left,
            Right,
        }

        SnakeDirection direction = SnakeDirection.Right;
        List<PictureBox> snakePartsList = new List<PictureBox>();
        PictureBox apple = new PictureBox();
        Random random = new Random();
        Image snakeHeadImage = Properties.Resources.SnakeHead;
        bool gameRunning = false;

        public SnakeGame()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            gameRunning = true;

            foreach (PictureBox pictureBox in snakePartsList)
            {
                board.Controls.Remove(pictureBox);
            }
            snakePartsList.Clear();


            direction = SnakeDirection.Right;

            instructionLabel.Visible = false;
            mainLabel.Visible = false;

            // Initialize Apple
            apple.Height = 18;
            apple.Width = 18;
            apple.BackColor = Color.IndianRed;
            this.board.Controls.Add(apple);
            RepositionApple();

            // Draw first snake part
            DrawNewSnakePart();

            snakePartsList[0].BackgroundImage = snakeHeadImage;

            // Update score and start game
            UpdateScore();
            mainTimer.Start();
        }

        private void MoveSnake(object sender, EventArgs e)
        {
            for (int i = snakePartsList.Count - 1; i > 0; i--)
            {
                snakePartsList[i].Left = snakePartsList[i - 1].Left;
                snakePartsList[i].Top = snakePartsList[i - 1].Top;
            }
            if (direction == SnakeDirection.Up)
                snakePartsList[0].Top -= 25;
            else if (direction == SnakeDirection.Down)
                snakePartsList[0].Top += 25;
            else if (direction == SnakeDirection.Left)
                snakePartsList[0].Left -= 25;
            else
                snakePartsList[0].Left += 25;

            if (snakePartsList[0].Left > 400 || snakePartsList[0].Left < 0 || snakePartsList[0].Top > 400 || snakePartsList[0].Top < 0)
            {
                GameOver();
                return;
            }

            if (apple.Bounds.IntersectsWith(snakePartsList[0].Bounds))
            {
                EatApple();
                return;
            }

            for (int i = snakePartsList.Count - 1; i > 0; i--)
            {
                if (snakePartsList[i].Left == snakePartsList[0].Left && snakePartsList[i].Top == snakePartsList[0].Top)
                    GameOver();
            }
        }

        private void EatApple()
        {
            DrawNewSnakePart();
            UpdateScore();
            RepositionApple();
        }

        private void UpdateScore()
        {
            score.Text = "Score: " + (snakePartsList.Count - 1);
        }

        private void DrawNewSnakePart()
        {
            snakePartsList.Add(new PictureBox());
            PictureBox snakePart = snakePartsList[snakePartsList.Count - 1];
            snakePart.Height = 25;
            snakePart.Width = 25;
            if (snakePartsList.Count > 1)
            {
                snakePart.Left = snakePartsList[snakePartsList.Count - 2].Left;
                snakePart.Top = snakePartsList[snakePartsList.Count - 2].Top;
                snakePart.BackColor = Color.Green;
            }
            this.board.Controls.Add(snakePart);
        }

        private void RepositionApple()
        {
            apple.Left = random.Next(16) * 25 + 3;
            apple.Top = random.Next(16) * 25 + 3;

            foreach (PictureBox snakePart in snakePartsList)
            {
                if (apple.Bounds.IntersectsWith(snakePart.Bounds))
                    RepositionApple();
            }
        }

        private void GameOver()
        {
            gameRunning = false;
            mainTimer.Stop();
            mainLabel.Text = "Game over!";
            mainLabel.Visible = true;
            instructionLabel.Visible = true;
        }

        private void ChangeDirection(object sender, KeyEventArgs e)
        {
            snakeHeadImage = Properties.Resources.SnakeHead;


            switch (e.KeyCode)
            {
                case Keys.Left:
                    snakeHeadImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    direction = SnakeDirection.Left;
                    break;
                case Keys.Right:
                    snakeHeadImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    direction = SnakeDirection.Right;
                    break;
                case Keys.Up:
                    snakeHeadImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    direction = SnakeDirection.Up;
                    break;
                case Keys.Down:
                    snakeHeadImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    direction = SnakeDirection.Down;
                    break;
                case Keys.Enter:
                    if (!mainTimer.Enabled)
                        StartGame();
                    return;
                case Keys.Escape:
                    PauseGame();
                    return;
                default:
                    return;
            }

            snakePartsList[0].BackgroundImage = snakeHeadImage;

        }

        private void PauseGame()
        {
            if (gameRunning && mainTimer.Enabled)
            {
                mainTimer.Stop();
                mainLabel.Text = "Paused";
                mainLabel.Visible = true;
            }
            else
            {
                mainTimer.Start();
                mainLabel.Visible = false;
            }
        }

        private void NewGame(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
