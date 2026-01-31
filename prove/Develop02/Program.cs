using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");

        Console.WriteLine("Welcome to the journal program!");
        Journal journal1 = new Journal();
        string menuInput;
        // within a loop, display instructions, 1. Write 2. Display 3. Load 4. Save 5. Quit
        // have it throw a wrist slap message in they put an invalid input, still in the loop
        // exit the loop by saying quit, maybe have a cute little goodbye message
        // lotta if statements coming up

        do
        {
            Console.WriteLine("Please select an option by entering the corresponding number:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            menuInput = Console.ReadLine();

            // need to do if/ else if for 1-4, and else is invalid message thing
            if (menuInput == "1")
            {
                // put code here to write, I think this one will get gnarly

                // first, make an entry and a prompt
                Entry todaysEntry = journal1.MakeEntry();
                string journalPrompt = journal1.GetJournalPrompt();
                todaysEntry._prompt = journalPrompt;

                // then get the date from the user? The example looked fancier but we were told
                // to just leave it as a string
                Console.Write("What is today's date? ");
                string entryDate = Console.ReadLine();
                todaysEntry._date = entryDate;

                // display the prompt
                Console.WriteLine(journalPrompt);

                // entry
                Console.Write("> ");
                string userEntryInput = Console.ReadLine();
                todaysEntry._userEntry = userEntryInput;
            }
            else if (menuInput == "2")
            {
                // Display thing, this might have logical errors we didn't handle
                // to clarify, this shows all the entries (iterates)
                foreach (Entry entry in journal1._entries)
                {
                    journal1.DisplayEntries();
                }
            }
            else if (menuInput == "3")
            {
                // I have no idea what the difference between load and display is here
                // okay, so load is just to pull the save txt file out of the ether and make it usable again
                Console.Write("What is the file name? ");
                string filename = Console.ReadLine();
                journal1.ReadFileToEntry(filename);
            }
            else if (menuInput == "4")
            {
                // call the save to file code here, this looks intimidating but it should
                // all work as long as I remember to put parameters in right
                Console.Write("What is the file name? ");
                string filename = Console.ReadLine();
                journal1.WriteEntryToFile(filename, journal1._entries);
            }
            else
            {
                Console.WriteLine("Invalid response, please try again.");
            }
        } while (menuInput != "5");
        Console.WriteLine("Have a nice day! Goodbye!");
    }
}