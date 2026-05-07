using word_guessing_game.Exceptions;
namespace word_guessing_game.Services;


// Guess validator class aim is to validate userguess and if it is invalid it throws exceptions.
public class GuessValidator
{
    // Handling validation of input such that it should contain only exact 5 characters. without containing numbers and special characters. 
    public void Isvalidguess(string userguess)
    {
        if (string.IsNullOrEmpty(userguess) || userguess.Length != 5 || !userguess.All(char.IsLetter))
        {
            throw new InvalidGuessException(userguess);
        }
    }
    
    // IsduplicateGuess method aim is to avoid duplicate guesses
    public void Isduplicateguess(string userguess, List<string> previousguessedwords)
    {
        if (previousguessedwords.Contains(userguess))
        {
            throw new DuplicateGuessException();
        }
    }
    
    // IsuserGuessesCorrect method is to check whether user guess is correct or not.
    public bool IsUserGuessedCorrect (string userguess , string secretword)
    {
        if (userguess == secretword)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }
}