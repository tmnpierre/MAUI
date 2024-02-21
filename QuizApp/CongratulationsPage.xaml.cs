namespace QuizApp;

public partial class CongratulationsPage : ContentPage
{
    public CongratulationsPage()
    {
        InitializeComponent();
    }
    private async void StartQuiz_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuestionPage(1));
    }
}