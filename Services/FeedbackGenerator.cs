namespace word_guessing_game.Services;

public class FeedbackGenerator
{
    Dictionary<char, int> _freqChar = new Dictionary<char, int>();
    public string Feedback(string userguess, string secretword)
    {   
        foreach(char ch in secretword)
        {
            if (_freqChar.ContainsKey(ch))
            {
                _freqChar[ch] += 1;
            }
            else
            {
                _freqChar[ch] = 1;
            }
        }
        
        string feedbackExpression = "";  
            
        for ( int i = 0; i < userguess.Length; i++)
        {
            if (userguess[i] == secretword[i])
            {
                feedbackExpression += "G ";
                _freqChar[userguess[i]] -= 1;
            }
            else if(secretword.Contains(userguess[i]) && _freqChar[userguess[i]]>0)
            {
                feedbackExpression += "Y ";
                _freqChar[userguess[i]] -= 1;
            }
            else
            {
                feedbackExpression += "X ";
            }
        }
        return feedbackExpression;
    }
}