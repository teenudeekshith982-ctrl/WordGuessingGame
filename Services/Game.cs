using word_guessing_game.Exceptions;
using word_guessing_game.Services;

namespace word_guessing_game.Services;

public class Game
{
    private string _secretWord = string.Empty;
    WordProvider wordprovider = new WordProvider();
    GuessValidator guessValidator = new GuessValidator();
    FeedbackGenerator feedbackGenerator = new FeedbackGenerator();
    
    // class Game constructor describes the rules if a player dont know the rules or new to the game.
    public Game()
    {
        Console.WriteLine(" -----    Welcome to Word Guessing Game   ----- ");
        Console.WriteLine("Before Starting the game we would like to know whether you know about the game or not");
        Console.WriteLine(" Please Enter the option 1 or 2 before starting the game \n 1. I know the game very well \n 2. Iam new to the game.");
        int option = Convert.ToInt32(Console.ReadLine());

        if (option == 1)
        {
            Console.WriteLine("we are excited that you already know about the game");
            Console.WriteLine("Lets Begin the game");
        }
        else
        {   
            Console.WriteLine("\n");
            Console.WriteLine("Dont worry we are here to help you out");
            Console.WriteLine("The word guessing game is very simple....");
            Console.WriteLine("\n");
            Console.WriteLine(" -----   These are the game rules:   ----- ");
            Console.WriteLine(" 1. We have a secret word and you need to guess the word within six attempts");
            Console.WriteLine(" 2. For each attempt you need to guess the word \n    -> Based on the your guess we will provide you the feedback.");
            Console.WriteLine(" 3. If you are able to guess the word in six attempts you are winner!!.");
            Console.WriteLine("\n");
            Console.WriteLine(" We hope you understand the game rules and best of luck in guessing the word..");
            Console.WriteLine(" If you are understand the game rules, Please type YES ");
            string useropinion = Console.ReadLine();
            if (useropinion == "YES")
            {
                Console.WriteLine(" Lets Begin the Game ");
            }
        }

    }
    
    // main Method that run the game it has the core logic.
    public void StartGame()
    {   
        
        // Getting secret word 
        _secretWord = wordprovider.Get_Secret_Word(); 
        // For having different colors for each attempt in the ouptut.
        List<ConsoleColor> colors = new List<ConsoleColor>
        {
            ConsoleColor.Red,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Yellow,
            ConsoleColor.DarkYellow,
            ConsoleColor.Magenta
        };
        
        // Maxattempts = 6
        int maxAttempts = 6;

        int attemptsUsed = 1;
        
        
        
         /*
          Im storing the previous guessed words in the list becasue the user might enter his 1st guess in the fifth guess also right
            so i need to store all the guessed words in a list so that the user cannot repeat any word that he had already been guessed.
             
        */ 
        
        List<string> previousguessedwords = new List<string>();
        while (attemptsUsed <= maxAttempts)
            {
                try
                {
                    Console.ForegroundColor = colors[attemptsUsed - 1];
                    Console.WriteLine($"\nAttempt {attemptsUsed} :");
                    Console.WriteLine("Please Guess the Word");
                    // Taking input from the user and also converting it into uppercase
                    string userGuess = Console.ReadLine().ToUpper();
                    
                    // validiating the inputs and handling duplicate guesses
                    guessValidator.Isvalidguess(userGuess);
                    guessValidator.Isduplicateguess(userGuess, previousguessedwords);
                    Console.WriteLine("----- OUTPUT -----");
                    for (int i = 0; i < userGuess.Length; i++)
                    {
                        Console.Write(userGuess[i] + " ");
                    }

                    Console.WriteLine("\n");
                    if (guessValidator.IsUserGuessedCorrect(userGuess, _secretWord))
                    {
                        Console.WriteLine("You Won!!!");
                        break;
                    }
                    else
                    {
                        string feedback = feedbackGenerator.Feedback(userGuess, _secretWord);
                        Console.WriteLine(feedback);

                    }

                    attemptsUsed++;
                    previousguessedwords.Add(userGuess);

                }
                catch (InvalidGuessException ige)
                {
                    Console.WriteLine(ige.Message);
                }
                catch (DuplicateGuessException dge)
                {
                    Console.WriteLine(dge.Message);
                }

                
            }
        string message;

        switch (attemptsUsed)
        {
            case 1:
                message = "Genius!";
                break;

            case 2:
                message = "Excellent!";
                break;

            case 3:
                message = "Great job!";
                break;

            case 4:
                message = "Good work!";
                break;

            case 5:
                message = "Nice try!";
                break;

            case 6:
                message = "That was close!";
                break;

            default:
                message = "Well played!";
                break;
        }

        Console.WriteLine(message);
        Console.WriteLine("Thanks for playing");

            }
            
            
}

