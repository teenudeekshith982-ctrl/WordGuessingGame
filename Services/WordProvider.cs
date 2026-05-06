namespace word_guessing_game.Services;
using System.Collections.Generic;

public class WordProvider
{
    private List<string> _Words = new List<string>();
    
    public WordProvider()
    {
        _Words.Add("PLANT");
    }

    public string Get_Secret_Word()
    {
        Random rnd = new Random();
        string word = _Words[rnd.Next(0, _Words.Count)];
        return word;
    }
    
}