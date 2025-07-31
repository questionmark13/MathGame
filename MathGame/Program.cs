
using System.Numerics;

string operation;
string difficulty;
int a;
int b;
InputOptions operationChosen;
DifficultyLevel difficultyLevel;

List<GameResult> gameResults = new List<GameResult>();

while (true)
{
    MainMenu();
    Random random = new Random();

    switch (operationChosen)
    {
        case InputOptions.Addition:
            {
                if (difficultyLevel == DifficultyLevel.Easy)
                {
                    a = random.Next(50);
                    b = random.Next(50);
                }
                else if (difficultyLevel == DifficultyLevel.Medium)
                {
                    a = random.Next(200);
                    b = random.Next(200);
                }
                else
                {
                    a = random.Next(500);
                    b = random.Next(500);
                }
               
                PerformOperation($"Sum of {a} + {b}", a + b);
                break;
            }
        case InputOptions.Substraction:
            {
                do
                {
                    a = random.Next(50);
                    b = random.Next(50);
                } while (b < 0 || b >= a);

                PerformOperation($"Difference of {a} - {b}", a - b);
                break;
            }
        case InputOptions.Multiplication:
            {
                a = random.Next(2,15);
                b = random.Next(2,15);

                PerformOperation($"Product of {a} * {b}", a * b);
                break;
            }
        case InputOptions.Division:
            {
                do
                {
                    a = random.Next(1,100);
                    b = random.Next(2,50);
                } while (a % b != 0 || a == b );

                PerformOperation($"Qotient of {a} / {b}", a / b);
                break;
            }
        case InputOptions.ShowGameHistory:
            {
                foreach (var entry in gameResults) 
                {
                    Console.WriteLine(entry);
                }
                Console.WriteLine();
                break;
            }
    }   
}


void MainMenu()
{
    bool validOperation = false;
    bool validDifficulty = false;
    do
    {
        Console.WriteLine("Choose difficulty: 1) Easy\n2) Medium\n3) Hard");
        Console.WriteLine();
        difficulty = Console.ReadLine();

        if (int.TryParse(difficulty, out int number) && Enum.IsDefined(typeof(DifficultyLevel), number))
        {
            difficultyLevel = (DifficultyLevel)number;
            validDifficulty = true;
        }
        else if (Enum.TryParse<DifficultyLevel>(difficulty, ignoreCase: true, out difficultyLevel))
        {
            validDifficulty = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Try again.\n");
        }

    } while (!validDifficulty);

    do
    {   
        Console.WriteLine("Choose an operation: 1) Addition\n2) Substraction\n3) Multiplication\n4) Division\n5) Show Game History");
        Console.WriteLine();
        operation = Console.ReadLine();

        if (int.TryParse(operation, out int number) && Enum.IsDefined(typeof(InputOptions), number))
        {
            operationChosen = (InputOptions)number;
            validOperation = true;
        }
        else if (Enum.TryParse<InputOptions>(operation, ignoreCase: true, out operationChosen))
        {
            validOperation = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Try again.\n");
        }
    } while (!validOperation);

    Console.WriteLine();
}

void GenerateTask()
{

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

enum DifficultyLevel
{
    Easy = 1,
    Medium,
    Hard
}
