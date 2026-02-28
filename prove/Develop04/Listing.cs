public class Listing : Activity
{
    private List<string> _prompts = new List<string>();
    List<string> entries = new List<string>();
    public Listing(string activityType, int seconds) : base(activityType, seconds)
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are some of yuor personal strengths?");
        _prompts.Add("Who are people that have helped you this week?");
        _prompts.Add("What are some things you're grateful for?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("What are some personal heroes you have?");
        _prompts.Add("What are some things you've done that you're proud of?");
    }

    public void ListingActivity()
    {
        Console.Clear();
        Console.WriteLine(GetWelcomeMessage());
        Thread.Sleep(1000);
        Console.WriteLine(GetInstructions());
        Console.WriteLine("Get ready...");
        Spinner();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count());
        Console.WriteLine(_prompts[promptIndex]);
        Console.WriteLine();
        Console.Write("You may begin in ");
        for (int i = 5; i>0; i--)
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
            string userEntry = Console.ReadLine();
            entries.Add(userEntry);
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {entries.Count()} items!");
        Console.WriteLine();
        Console.WriteLine(GetWellDoneMessage());
        Spinner();
        Console.Clear();
    }
}