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
                userInput.Text = "";

                if (userGuess == mysteryNumber)
                {
                    ShowEndGameAlert("Félicitations !", $"Bravo ! Vous avez trouvé le nombre mystère {mysteryNumber}. Voulez-vous rejouer ?");
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
                        ShowEndGameAlert("Game Over", $"Vous avez perdu. Le nombre mystère était {mysteryNumber}. Voulez-vous rejouer ?");
                    }
                }
            }
            else
            {
                resultLabel.Text = "Veuillez entrer un nombre valide.";
                resultLabel.TextColor = Colors.Red;
            }
        }

        async void ShowEndGameAlert(string title, string message)
        {
            bool retry = await DisplayAlert(title, message, "Rejouer", "Quitter");
            if (retry)
            {
                InitializeGame();
            }
        }
    }
}