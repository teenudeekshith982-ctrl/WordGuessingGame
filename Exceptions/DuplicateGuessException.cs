namespace word_guessing_game.Exceptions;

public class DuplicateGuessException : Exception
{
    private string _message;
    public DuplicateGuessException()
    { 
        _message = "You cant make the new guess same as previous guess.Try to guess new word.Dont lose Hope!";
    }
    
    public override string Message => _message;
    
    
}