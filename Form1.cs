using System.Text;
namespace Guess
{
    public partial class Form1 : Form
    {
        private string word = "Computer";
        private StringBuilder display;
        private int wrong = 0;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            display = new StringBuilder(new string('?', word.Length));
            display[0] = word[0];
            display[word.Length - 1] = word[word.Length - 1];
            label1.Text = display.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string guess = textBox1.Text.ToLower();
            if (string.IsNullOrEmpty(guess) || guess.Length != 1)
            {
                MessageBox.Show("Please enter a single letter.");
                return;

            }
            char guessChar = guess[0];
            bool corrGuess = false;

            for (int i = 1; i < word.Length - 1; i++)
            {
                if (word[i] == guessChar)
                {
                    display[i] = guessChar;
                    corrGuess = true;
                }
            }
            if (corrGuess)
            {
                label2.Text = display.ToString();
                if (!display.ToString().Contains('?'))
                {
                    MessageBox.Show("You guessed the word!");
                    InitializeGame();
                }
            }
            else
            {
                wrong++;
                listBox1.Items.Add(guessChar);
                if (wrong >= 6)
                {
                    MessageBox.Show("The word was " + word);
                    InitializeGame();
                }
            }
            textBox1.Clear();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}