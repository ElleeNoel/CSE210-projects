public class Entry
{
    // date
    public string _date;
    // prompt
    public string _prompt;
    // user input
    public string _userEntry;

    // behavior: display entry
    public void DisplayEntry()
    {
        Console.WriteLine(_date);
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine(_userEntry);
    }
}