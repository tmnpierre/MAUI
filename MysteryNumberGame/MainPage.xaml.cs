namespace MysteryNumberGame
{
    public partial class MainPage : ContentPage
    {
        int mysteryNumber;

        public MainPage()
        {
            InitializeComponent();
            InitializeGame();
        }

        void InitializeGame()
        {
            Random random = new Random();
            mysteryNumber = random.Next(1, 101);
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
                else if (userGuess < mysteryNumber)
                {
                    resultLabel.Text = "Le nombre mystère est plus grand.";
                    resultLabel.TextColor = Colors.Yellow;
                }
                else
                {
                    resultLabel.Text = "Le nombre mystère est plus petit.";
                    resultLabel.TextColor = Colors.Orange;
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