using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        // okay, print initial welcome, while input != 4, display menu, if 1 2 3, instantiate and use that activity
        string menuInput = "";
        while(menuInput != "4")
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Select an activity (by number) from the menu: ");
            menuInput = Console.ReadLine();
            Console.Write("How many seconds would you like to do the activity? ");
            string secondsInput = Console.ReadLine();
            int seconds = int.Parse(secondsInput);
            if (menuInput == "1")
            {
               
                Breathing breathing = new Breathing("Breathing", seconds);
                breathing.BreathingActivity();
            }
            else if (menuInput == "2")
            {
                
                Reflection reflection = new Reflection("Reflection", seconds);
                reflection.ReflectionActivity();
            }
            else if (menuInput == "3")
            {
               
                Listing listing = new Listing("Listing", seconds);
                listing.ListingActivity();
            }
        }
    }
}