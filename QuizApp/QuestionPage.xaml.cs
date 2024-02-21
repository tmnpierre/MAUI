namespace QuizApp;

public partial class QuestionPage : ContentPage
{
    int _questionNumber;
    string _correctAnswer;
    List<(string Question, string[] Options, string CorrectAnswer)> questions = new List<(string, string[], string)>
        {
        ("Quelle est la capitale de la France ?", new string[] { "Paris", "Lyon", "Marseille", "Bordeaux" }, "Paris"),
        ("Qui a peint la Joconde ?", new string[] { "Vincent Van Gogh", "Pablo Picasso", "Leonardo da Vinci", "Claude Monet" }, "Leonardo da Vinci"),
        ("Quel est l'oc�an le plus grand ?", new string[] { "Atlantique", "Indien", "Pacifique", "Arctique" }, "Pacifique"),
        ("Quelle est la plus grande plan�te du syst�me solaire ?", new string[] { "Terre", "Mars", "Jupiter", "Saturne" }, "Jupiter"),
        ("Qui a �crit 'Hamlet' ?", new string[] { "William Shakespeare", "Charles Dickens", "Leo Tolstoy", "Mark Twain" }, "William Shakespeare"),
        ("Quel pays est connu comme le pays du Soleil Levant ?", new string[] { "Inde", "Chine", "Japon", "Cor�e du Sud" }, "Japon"),
        ("Quel est l'�l�ment chimique le plus abondant dans l'univers ?", new string[] { "Oxyg�ne", "Hydrog�ne", "Carbone", "Azote" }, "Hydrog�ne"),
        ("Qui a invent� l'ampoule �lectrique ?", new string[] { "Nikola Tesla", "Thomas Edison", "Albert Einstein", "Benjamin Franklin" }, "Thomas Edison"),
        ("Quelle ville est surnomm�e 'La ville �ternelle' ?", new string[] { "Ath�nes", "Rome", "Le Caire", "Paris" }, "Rome"),
        ("Quel est le livre le plus vendu au monde apr�s la Bible ?", new string[] { "Le Seigneur des Anneaux", "Le Petit Prince", "Harry Potter", "Le Da Vinci Code" }, "Le Petit Prince")
    };

    public QuestionPage(int questionNumber)
    {
        InitializeComponent();
        _questionNumber = questionNumber;
        LoadQuestion(questionNumber - 1);
    }

    void LoadQuestion(int index)
    {
        var questionData = questions[index];
        QuestionLabel.Text = questionData.Question;
        Answer1.Text = questionData.Options[0];
        Answer2.Text = questionData.Options[1];
        Answer3.Text = questionData.Options[2];
        Answer4.Text = questionData.Options[3];
        _correctAnswer = questionData.CorrectAnswer;
    }

    private async void Answer_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        if (button.Text == _correctAnswer)
        {
            if (_questionNumber == 10)
            {
                await Navigation.PushAsync(new CongratulationsPage());
            }
            else
            {
                await Navigation.PushAsync(new QuestionPage(_questionNumber + 1));
            }
        }
        else
        {
            await DisplayAlert("Incorrect", "La r�ponse est incorrecte. Essayez encore.", "OK");
        }
    }
}