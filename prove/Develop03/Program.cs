using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        string response;
        do
        {
           Console.WriteLine("Welcome to the scripture memorizer! Please type the name of the scripture you want to practice: ");
           Console.WriteLine("Select one: 1 Nephi 3:7, 2 Timothy 1:7, John 3:16, John 3:16-17, or 2 Nephi 2:24-25");
           response = Console.ReadLine(); 
        } while (response != "1 Nephi 3:7" && response != "2 Timothy 1:7" && response != "John 3:16" && response != "John 3:16-17" && response != "2 Nephi 2:24-25");
        Reference ref1 = new Reference(response);
        Memorizer scriptureMem = new Memorizer(ref1);
        // for the while loop here make a number that's the length of the words list
        // and subtract 3 every loop, just have it while number is greater than 0 
        // since they probably aren't perfectly divisible by 3
        // also remember to take enter or quit inputs
        ref1.DisplayReference();
        scriptureMem.DisplayText();
        string userInput = Console.ReadLine();
        int totalWords = scriptureMem.DeleteRandom3();
        // okay this last one didn't work, in memorizer have total words variable
        // global and a getter, and modify it inside delete random
        ref1.DisplayReference();
        scriptureMem.DisplayText();
        while (userInput != "quit" && totalWords >0)
        {
            Console.Clear();
            Console.WriteLine("Press enter to remove more words, or type 'quit' to stop.");
            Console.WriteLine();
            ref1.DisplayReference();
            scriptureMem.DisplayText();
            scriptureMem.DeleteRandom3();
            userInput = Console.ReadLine();
        }
        // As far as extra stuff, my program lets the user pick a scripture from a list
        // of options
    }
}