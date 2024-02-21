namespace QuizApp;

public partial class QuestionPage : ContentPage
{
    int _questionNumber;
    string? _correctAnswer;
    List<(string Question, string[] Options, string CorrectAnswer)> questions = new List<(string, string[], string)>
{
    ("Qui est consid�r� comme le p�re du th��tre tragique grec ?", new string[] { "Sophocle", "Euripide", "Eschyle", "Aristophane" }, "Eschyle"),
    ("Quelle pi�ce de Shakespeare est connue pour la phrase '�tre ou ne pas �tre' ?", new string[] { "Macbeth", "Hamlet", "Le Roi Lear", "Othello" }, "Hamlet"),
    ("Quel dramaturge a �crit 'En attendant Godot' ?", new string[] { "Samuel Beckett", "Harold Pinter", "Eug�ne Ionesco", "Jean-Paul Sartre" }, "Samuel Beckett"),
    ("Qui a �crit 'Les Fourberies de Scapin' ?", new string[] { "Jean Racine", "Moli�re", "Pierre Corneille", "Voltaire" }, "Moli�re"),
    ("Quel est le nom du th��tre associ� � William Shakespeare ?", new string[] { "Le Globe", "Le Royal Albert Hall", "Le National Theatre", "Le Lyceum Theatre" }, "Le Globe"),
    ("Dans quelle pi�ce de th��tre trouve-t-on les personnages de Rosencrantz et Guildenstern ?", new string[] { "Macbeth", "Hamlet", "Romeo et Juliette", "Le Roi Lear" }, "Hamlet"),
    ("Quelle pi�ce est un exemple classique du th��tre de l'absurde ?", new string[] { "La Cantatrice chauve", "Les Mains sales", "Antigone", "Le Malade imaginaire" }, "La Cantatrice chauve"),
    ("Qui a �crit 'La Maison de Bernarda Alba' ?", new string[] { "Federico Garc�a Lorca", "Antonio Buero Vallejo", "Miguel de Cervantes", "Lope de Vega" }, "Federico Garc�a Lorca"),
    ("Quel est le principal th�me de 'La Trag�die de Macbeth' par Shakespeare ?", new string[] { "L'amour", "La guerre", "La trahison", "L'ambition" }, "L'ambition"),
    ("Quelle pi�ce de th��tre de Jean Anouilh reprend une c�l�bre histoire de la mythologie grecque ?", new string[] { "Antigone", "Becket", "L'Alouette", "Le Voyageur sans bagage" }, "Antigone")
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
            await Navigation.PopToRootAsync();
        }
    }
}