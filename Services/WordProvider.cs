namespace word_guessing_game.Services;
using System.Collections.Generic;

// Word Provider class aim is to provide a random secret word.
public class WordProvider
{   
    // Collection of secret words
    private List<string> _words = new List<string>();
    
    public WordProvider()
    {   
        _words.Add("MANGO");
        _words.Add("PLANT");
        _words.Add("TRAIN");
        _words.Add("BRAIN");
        _words.Add("GRAPE");
        _words.Add("APPLE");
    }
    
    // get_secret_word method to get a random secret word.
    public string Get_Secret_Word()
    {
        Random rnd = new Random();
        string word = _words[rnd.Next(0, _words.Count)];
        return word;
    }
    
}