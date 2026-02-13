public class Word
{
    private string _word;
    public void SetWord(string word)
    {
        _word = word + " ";
    }
    public string GetWord()
    {
        return _word;
    }
    public void DisplayWord()
    {
        Console.Write(_word);
    }
}