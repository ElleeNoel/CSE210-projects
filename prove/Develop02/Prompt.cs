using System.Security.Cryptography.X509Certificates;

public class Prompt
{
    // list of strings: prompts
    public static List<string> _prompts = new List<string>
    {
        "What was the coolest thing you did today?",
        "What's one thing you would change if you could?",
        "What did you dream about last night?",
        "How did you see the hand of the Lord in your life today?",
        "What did you eat for breakfast today?"
    };
    // alternative syntax: _prompts = new List<string>([item, item, etc.]) Can instantiate
    // new objects within a list too
    public string GetRandomPrompt()
    {
    Random random = new Random();
    int index = random.Next(_prompts.Count());

    string prompt = _prompts[index];
    return prompt;
    }

    

    // behavior: randomly choose one prompt and RETURN it
}