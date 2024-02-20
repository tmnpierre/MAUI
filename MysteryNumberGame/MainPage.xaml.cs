namespace MysteryNumberGame
{
    public partial class MainPage : ContentPage
    {
        int mysteryNumber;
        int lives = 5;

        public MainPage()
        {
            InitializeComponent();
            InitializeGame();
            UpdateLivesDisplay();
        }

        void InitializeGame()
        {
            Random random = new Random();
            mysteryNumber = random.Next(1, 101);
            lives = 5;
            UpdateLivesDisplay();
        }

        void UpdateLivesDisplay()
        {
            livesLabel.Text = new String('❤', lives);
        }

        private void OnCheckClicked(object sender, EventArgs e)
        {
            if (int.TryParse(userInput.Text, out int userGuess))
            {
                if (userGuess == mysteryNumber)
                {
                    resultLabel.Text = "Bravo ! Vous avez trouvé le nombre mystère.";
                    resultLabel.TextColor = Colors.Green;
                    InitializeGame();
                }
                else
                {
                    lives--;
                    UpdateLivesDisplay();

                    if (lives > 0)
                    {
                        resultLabel.Text = userGuess < mysteryNumber ? "Le nombre mystère est plus grand." : "Le nombre mystère est plus petit.";
                        resultLabel.TextColor = Colors.Orange;
                    }
                    else
                    {
                        resultLabel.Text = "Game Over ! Le nombre mystère était " + mysteryNumber + ".";
                        resultLabel.TextColor = Colors.Red;
                        InitializeGame();
                    }
                }
            }
            else
            {
                resultLabel.Text = "Veuillez entrer un nombre valide.";
                resultLabel.TextColor = Colors.Red;
            }
        }
    }
}