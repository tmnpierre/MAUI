namespace QuizApp;

public partial class QuestionPage : ContentPage
{
    int _questionNumber;
    string? _correctAnswer;
    List<(string Question, string[] Options, string CorrectAnswer)> questions = new List<(string, string[], string)>
{
    ("Qui est considéré comme le père du théâtre tragique grec ?", new string[] { "Sophocle", "Euripide", "Eschyle", "Aristophane" }, "Eschyle"),
    ("Quelle pièce de Shakespeare est connue pour la phrase 'Être ou ne pas être' ?", new string[] { "Macbeth", "Hamlet", "Le Roi Lear", "Othello" }, "Hamlet"),
    ("Quel dramaturge a écrit 'En attendant Godot' ?", new string[] { "Samuel Beckett", "Harold Pinter", "Eugène Ionesco", "Jean-Paul Sartre" }, "Samuel Beckett"),
    ("Qui a écrit 'Les Fourberies de Scapin' ?", new string[] { "Jean Racine", "Molière", "Pierre Corneille", "Voltaire" }, "Molière"),
    ("Quel est le nom du théâtre associé à William Shakespeare ?", new string[] { "Le Globe", "Le Royal Albert Hall", "Le National Theatre", "Le Lyceum Theatre" }, "Le Globe"),
    ("Dans quelle pièce de théâtre trouve-t-on les personnages de Rosencrantz et Guildenstern ?", new string[] { "Macbeth", "Hamlet", "Romeo et Juliette", "Le Roi Lear" }, "Hamlet"),
    ("Quelle pièce est un exemple classique du théâtre de l'absurde ?", new string[] { "La Cantatrice chauve", "Les Mains sales", "Antigone", "Le Malade imaginaire" }, "La Cantatrice chauve"),
    ("Qui a écrit 'La Maison de Bernarda Alba' ?", new string[] { "Federico García Lorca", "Antonio Buero Vallejo", "Miguel de Cervantes", "Lope de Vega" }, "Federico García Lorca"),
    ("Quel est le principal thème de 'La Tragédie de Macbeth' par Shakespeare ?", new string[] { "L'amour", "La guerre", "La trahison", "L'ambition" }, "L'ambition"),
    ("Quelle pièce de théâtre de Jean Anouilh reprend une célèbre histoire de la mythologie grecque ?", new string[] { "Antigone", "Becket", "L'Alouette", "Le Voyageur sans bagage" }, "Antigone")
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
            await DisplayAlert("Incorrect", "La réponse est incorrecte. Essayez encore.", "OK");
            await Navigation.PopToRootAsync();
        }
    }
}