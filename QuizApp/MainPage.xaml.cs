namespace QuizApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartQuiz_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionPage(1));
        }
    }
}