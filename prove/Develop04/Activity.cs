public class Activity
{
    private string _welcomeMessage;
    private string _instructions;
    private int _activitySeconds;
    private string _wellDoneMessage;
    public string GetWelcomeMessage()
    {
        return _welcomeMessage;
    }
    public int GetActivitySeconds()
    {
        return _activitySeconds;
    }
    public string GetWellDoneMessage()
    {
        return _wellDoneMessage;
    }
    public string GetInstructions()
    {
        return _instructions;
    }
    public Activity(string activityType, int seconds)
    {
        _activitySeconds = seconds;
        _wellDoneMessage = "Well done!";
        // figure out if I'm setting the instructions here or if I do it in sub can I just use a blank constructor here?
        // jk definitely set the things in here, just pass them in through child constructor
        if (activityType == "Breathing")
        {
            _welcomeMessage = "Welcome to the Breathing Activity.";
            _instructions = "This activity will help you relax by walking you through breathing in and out. Clear your mind and focus on your breathing.";

        }
        else if (activityType == "Reflection")
        {
            _welcomeMessage = "Welcome to the Reflection Activity.";
            _instructions = "This activity will help you reflect on times in your life when you have showed strength or resilience. When you see these traits in yourself, it becomes easier to draw on that strength again.";
        }
        else if (activityType == "Listing")
        {
            _welcomeMessage = "Welcome to the Listing Activity";
            _instructions = "This activity will help you reflect on the good things in your life by having you list as many as you can.";
        }
    }
    public void Spinner()
    {
        List<string> spinnerPositions = new List<string>();
        spinnerPositions.Add("|");
        spinnerPositions.Add("/");
        spinnerPositions.Add("-");
        spinnerPositions.Add("\\");
        spinnerPositions.Add("|");
        spinnerPositions.Add("/");
        spinnerPositions.Add("-");
        spinnerPositions.Add("\\");
        spinnerPositions.Add("|");
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(6);

        DateTime currentTime = DateTime.Now;
        int i = 0;
        while (DateTime.Now < futureTime)
        {
            string s = spinnerPositions[i];
            //Console.Write("+");

            //Thread.Sleep(500);

            //Console.Write("\b \b"); // Erase the + character
            //Console.Write("-"); // Replace it with the - character
                Console.Write(s);
                Thread.Sleep(500);
                Console.Write("\b \b");

            i++;

            if (i >= spinnerPositions.Count)
            {
                i = 0;
            }

        }
    }
}