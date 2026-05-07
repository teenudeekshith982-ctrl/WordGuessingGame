namespace word_guessing_game.Services;

public class FeedbackGenerator
{   
    
    // I took a dictionary becuase i need frequency of characters in the word.
    // I needed the frequency because there may be edges cases like as shown below. 
    
    /*
            example:
                secretword:  P L A N T
                userguess:   A P P L E
                
                if i didnt have the frequency then here we have 2P's right,so
                feedback : Y Y Y Y X
                
                where as correct feedback is:
                feedback: Y Y X Y X
                becuase we have only one P right in secret word we need to handle the edge case thats why i took the dictionary.
                
     */
    
    //Intializing the dictionary 
    Dictionary<char, int> _freqChar = new Dictionary<char, int>();
    
    // calculating the frequency of characters
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
        
        // checking each character of the user guess with secret word and then adding feedback.
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