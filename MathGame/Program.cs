
using System.Numerics;

string operation;
int a;
int b;

List<GameResult> gameResults = new List<GameResult>();

while (true)
{
    MainMenu();
    Random random = new Random();

    switch (operation)
    {
        case "addition":
            {
                a = random.Next(50);
                b = random.Next(50);

                PerformOperation($"Sum of {a} + {b}", a + b);
                break;
            }
        case "substraction":
            {
                do
                {
                    a = random.Next(50);
                    b = random.Next(50);
                } while (b < 0 || b >= a);

                PerformOperation($"Difference of {a} - {b}", a - b);
                break;

            }
        case "multiplication":
            {
                a = random.Next(2,15);
                b = random.Next(2,15);

                PerformOperation($"Product of {a} * {b}", a * b);
                break;
            }
        case "division":
            {
                do
                {
                    a = random.Next(1,100);
                    b = random.Next(2,50);
                } while (a % b != 0 || a == b );

                PerformOperation($"Qotient of {a} / {b}", a / b);
                break;
            }
        case "showgamehistory":
            {
                foreach (var result in  gameResults) 
                {
                    Console.WriteLine(result);
                }
                Console.WriteLine();
                break;
            }
    }   
}


void MainMenu()
{
    bool validInput = false;

    do
    {
        Console.WriteLine("Choose an operation: 1) Addition \t2) Substraction \t3) Multiplication \t4) Division \t5) Show Game History");
        Console.WriteLine();
        operation = Console.ReadLine();
    } while (operation == null || !Enum.TryParse<InputOptions>(operation, ignoreCase: true, out var result));
}

void PerformOperation (string taskDescription, int correctAnswer)
{
    string input;
    int answer;
    string result;
    do
    {
        Console.WriteLine($"{taskDescription}"); ;
        input = Console.ReadLine();
    } while (!int.TryParse(input, out answer));

    if (answer == correctAnswer)
    {
        result = "Correct!";
        Console.WriteLine(result);
    }
    else
    {
        result = "Incorrect.";
        Console.WriteLine(result);
    }
    gameResults.Add(new GameResult { Task = $"{a} / {b}", UserAnswer = answer, Message = result });
    Console.WriteLine();

}
class GameResult
{
    public string Task { get; set; }
    public int UserAnswer { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        Console.WriteLine();
        return $"{Task} = {UserAnswer} → {Message}";
    }
}
enum InputOptions
{
    Addition = 1,
    Substraction,
    Multiplication,
    Division,
    ShowGameHistory
}

enum ResultOptions
{
    Sum,
    Difference,
    Product,
    Quotient
}