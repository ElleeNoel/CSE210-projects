public class Reflection : Activity
{
    private List<string> _reflectionPrompts = new List<string>();
    private List<string> _questions = new List<string>();
    // this second questions list is part of my extra thing, I made it so it won't give you a duplicate question
    private List<string> _usedQuestions = new List<string>();
    public Reflection(string activityType, int seconds) : base(activityType, seconds)
    {
        _reflectionPrompts.Add("Think of a time when you did something really dificult.");
        _reflectionPrompts.Add("Think of a time when you did the right thing, even though it was unpopular.");
        _reflectionPrompts.Add("Think of a time when you shared your testimony with a friend.");
        _reflectionPrompts.Add("Think of a time when you worked hard to get something you wanted.");

        _questions.Add("Why was this experience meaningful?");
        _questions.Add("What did you learn from this experience?");
        _questions.Add("What made this experience different from other times that you were not as successful?");
        _questions.Add("What is your favorite thing about this memory?");
        _questions.Add("How did this moment come about?");
        _questions.Add("What did you learn about yourself from this experience?");
        _questions.Add("How can you remember this experience going forward?");
        _questions.Add("How did this moment make you stronger?");

    }
    public void ReflectionActivity()
    {
        Console.Clear();
        Console.WriteLine(GetWelcomeMessage());
        Console.WriteLine();
        Thread.Sleep(1000);
        Console.WriteLine(GetInstructions());
        Thread.Sleep(5000);
        Console.Write("Get ready");
        for (int i = 5; i>0; i--)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Random random = new Random();
        int promptIndex = random.Next(_reflectionPrompts.Count());
        Console.WriteLine(_reflectionPrompts[promptIndex]);
        Console.WriteLine("When you are ready to continue, press enter.");
        Console.ReadLine();

        Console.WriteLine("Now, ponder on each of the following questions and how they relate to this experience.");
        Console.WriteLine("Begin in: ");
        for(int i = 5; i>0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetActivitySeconds());

        DateTime currentTime = DateTime.Now;
        
        while (DateTime.Now < futureTime)
        {
            int index = random.Next(_questions.Count());
            Console.WriteLine($">{_questions[index]}");
            Spinner();
            _usedQuestions.Add(_questions[index]);
            _questions.Remove(_questions[index]);
        }
        
        Console.WriteLine();
        Console.WriteLine(GetWellDoneMessage());
        Thread.Sleep(1000);
        Console.WriteLine($"You have completed another {GetActivitySeconds()} seconds of the Reflection Activity.");
        Spinner();
        Console.Clear();
    }
}