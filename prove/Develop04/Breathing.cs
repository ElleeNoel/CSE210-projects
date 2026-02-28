public class Breathing : Activity
{
    public Breathing(string activityType, int seconds) : base(activityType, seconds)
    {
        
    }
    public void BreathingActivity()
    {
        Console.Clear();
        Console.WriteLine(GetWelcomeMessage());
        Console.WriteLine();
        Thread.Sleep(1000);
        Console.WriteLine(GetInstructions());
        Console.WriteLine("Get ready...");
        Console.WriteLine();
        Spinner();
        // okay, main menu is taking which activity/how long, passing to constructor
        // need a timer to be like, while remaining seconds != 0, keep doing the thing
        // they all need a timer but how to make that work?

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetActivitySeconds());

        DateTime currentTime = DateTime.Now;
        
        while (DateTime.Now < futureTime)
        {
            Console.WriteLine("Breathe in... ");
            for (int i = 4; i>0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine("Breath out... ");
            for(int i=6; i>0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        Console.WriteLine(GetWellDoneMessage());
        Thread.Sleep(1000);
        Console.WriteLine($"You have completed another {GetActivitySeconds()} seconds of the Breathing Activity.");
        Spinner();
        Console.Clear();
    }
}