namespace word_guessing_game.Exceptions;

public class InvalidGuessException : Exception
{
        private string _message;
        public InvalidGuessException (string userguess)
        {
                if (userguess.Length == 0)
                {
                        _message = "Please provide a valid guess it should not be empty";
                }
                else if (userguess.All(char.IsLetter))
                {

                        _message = "We are expecting a word , not a number or special characters";
                }
                else if (userguess.Length < 5)
                {
                        _message = "Too few guess characters, Please provide only 5 characters ";
                }
                else if (userguess.Length > 5)
                {
                        _message = "Too many guess characters, Please provide only 5 characters ";
                }
                else
                {
                        _message = "Invalid Guess";
                }
                
        }
        
        public override string Message => _message;
}