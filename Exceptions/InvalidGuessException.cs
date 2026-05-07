namespace word_guessing_game.Exceptions;

public class InvalidGuessException : Exception
{
    private string _message;

    public InvalidGuessException(string userguess)
    {
        if (string.IsNullOrWhiteSpace(userguess))
        {
            _message = "Please provide a valid guess. It should not be empty.";
        }
        else if (userguess.Length < 5)
        {
            _message = "Too few guess characters. Please provide exactly 5 characters.";
        }
        else if (userguess.Length > 5)
        {
            _message = "Too many guess characters. Please provide exactly 5 characters.";
        }
        else if (!userguess.All(char.IsLetter))
        {
            _message = "We are expecting a word, not numbers or special characters.";
        }
        else
        {
            _message = "Invalid Guess.";
        }
    }

    public override string Message => _message;
}