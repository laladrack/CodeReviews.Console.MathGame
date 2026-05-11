System.Console.WriteLine("Welcome to the Math Game!");
List<Dictionary<string, string>> past_games = new List<Dictionary<string, string>>();

bool question_play_bool = false;
bool playerAnswerBool;

while (!question_play_bool){
    System.Console.WriteLine("------- OPTIONS -------");
    System.Console.WriteLine("1) Play................");
    System.Console.WriteLine("2) Previous games......");
    System.Console.WriteLine("3) Exit................");
    System.Console.WriteLine("-----------------------");
    playerAnswerBool = int.TryParse(Console.ReadLine().Trim(), out int playerAnswer);
    while (!playerAnswerBool) continue;

    System.Console.WriteLine("-----------------------");
    switch(playerAnswer)
    {
        case 1: 
            past_games.Add(jogar());
            break;
        case 2:
            if (past_games.Count > 0){
                System.Console.WriteLine("Question: Your answer");
                foreach (var game in past_games)
                {
                    System.Console.WriteLine($"Game {past_games.IndexOf(game)}");
                    foreach (var question in game)
                    {
                        System.Console.WriteLine($"{question.Key}: {question.Value}");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("No games registered! Play a game first.");
            }
            break;
        case 3:
            System.Console.WriteLine("See you next time!");
            Environment.Exit(0);
            break;
    }
    System.Console.WriteLine("-----------------------");
}

Dictionary<string, string> jogar()
{
    int correct_answers = 0;
    Random rand = new Random();
    Dictionary<string, string> jogo = new Dictionary<string, string>();

    for (int i = 1; i < 6; i++)
    {
        int num1;
        int num2;
        int correct_answer; 
        string operador;
        string respostaString;

        int numOperador = rand.Next(1,4);
        switch(numOperador)
        {
            case 1: // adição
                operador = "+";
                num1 = rand.Next(100);
                num2 = rand.Next(100);
                correct_answer = num1 + num2;
                break;
            case 2: // subtração
                operador = "-";
                num1 = rand.Next(100);
                num2 = rand.Next(100);
                correct_answer = num1 - num2;
                break;
            case 3: // multiplicação
                operador = "*";
                num1 = rand.Next(100);
                num2 = rand.Next(100);
                correct_answer = num1 * num2;
                break;
            case 4: // divisão
                operador = "/";
                num1 = rand.Next(100);
                num2 = rand.Next(1,100);
                while (num1 % num2 != 0) num2 = rand.Next(1,100);
                correct_answer = num1 / num2;
                break;
            default:
                operador = "";
                num1 = 0;
                num2 = 0;
                correct_answer = 0;
                break; 
        }

        string question = $"{num1} {operador} {num2}";
        System.Console.WriteLine("----------------------");
        System.Console.WriteLine($"Question {i}: {question} = ?");
        respostaString = Console.ReadLine().Trim();
        bool respostaBool = int.TryParse(respostaString, out int resposta);
        while (!respostaBool)
        {
            System.Console.WriteLine("Only integers are accepted.");
            System.Console.WriteLine($"Question {i}: {question} = ?");
            respostaString = Console.ReadLine().Trim();
            respostaBool = int.TryParse(respostaString, out resposta);
        }

        if (resposta == correct_answer) {
            correct_answers++;
            System.Console.WriteLine("Correct!");
        }
        else
        {
            System.Console.WriteLine($"Incorrect. The answer was {correct_answer}");
        }

        jogo.Add(question, respostaString);
        
    }
    jogo.Add("Points", $"{correct_answers}");
    System.Console.WriteLine("----------------------");
    System.Console.WriteLine($"Correct answers: {correct_answers}.");
    if (correct_answers > 3) System.Console.WriteLine("Pretty good!");
    if (correct_answers <= 3) System.Console.WriteLine("Needs some work.");
    System.Console.WriteLine("----------------------");

    return jogo;
}