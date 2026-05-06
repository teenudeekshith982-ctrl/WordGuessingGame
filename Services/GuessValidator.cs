using word_guessing_game.Exceptions;
namespace word_guessing_game.Services;

public class GuessValidator
{
    public void Isvalidguess(string userguess)
    {
        if (string.IsNullOrEmpty(userguess) || userguess.Length != 5 || !userguess.All(char.IsLetter))
        {
            throw new InvalidGuessException(userguess);
        }
    }

    public void Isduplicateguess(string userguess, List<string> previousguessedwords)
    {
        if (previousguessedwords.Contains(userguess))
        {
            throw new DuplicateGuessException();
        }
    }
    
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