namespace GuessNumberGame
{
    public partial class Form1 : Form
    {
        private int secretNumber;
        private int attemptsLeft;

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            Random rand = new Random();
            secretNumber = rand.Next(1, 6);
            attemptsLeft = 5;
            UpdateStatusLabel();
        }

        private void UpdateStatusLabel()
        {
            statusLabel.Text = $"Attempts left: {attemptsLeft}";
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            int guessedNumber;
            if (int.TryParse(guessTextBox.Text, out guessedNumber))
            {
                attemptsLeft--;
                UpdateStatusLabel();

                if (guessedNumber == secretNumber)
                {
                    MessageBox.Show("Congratulations! You guessed the number!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartNewGame();
                }
                else if (attemptsLeft == 0)
                {
                    MessageBox.Show($"Sorry, you've run out of attempts. The secret number was {secretNumber}.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartNewGame();
                }
                else
                {
                    string message = guessedNumber < secretNumber ? "Try a higher number!" : "Try a lower number!";
                    MessageBox.Show(message, "Incorrect Guess", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            guessTextBox.Clear();
            guessTextBox.Focus();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Guess Number Game!\n\nThe computer will randomly choose a number between 1 and 5. Your task is to guess this number. You have a limited number of attempts to guess the correct number. After each attempt, the computer will tell you whether the guessed number is higher or lower than the secret number.\n\nGood luck!", "Game Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
