// so I'm definitely not fluent in this language at all so let's put th blueprint
// in here and then try to figure out how to say it in computer
using System.IO;
public class Journal
{
    // attributes = list of type entries
    public List<Entry> _entries = new List<Entry>();

    
    public string GetFileName()
    {
        Console.WriteLine("Please enter your file name: ");
        string fileName = Console.ReadLine();
        return fileName;
    }
    // behavior: read saved file to an entry object
    // okay, correction: I need this to instantiate an entry for every journal entry,
    // not sure how to make it deliminate between chunks of a text file and lines, or even
    // if I can. Also need it to add entries to the list
    public void ReadFileToEntry(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        Entry entry = new Entry();
        

        
        /* Okay, so this is possibly the dumbest idea i've had yet, but it makes
        sense to me and the stuff I'm reading doesn't really. So what if I have a while 
        loop, I make a variable for the number of lines in the file, and while that number is
        >0 (-3= every time) it does the for loop I have right now, and the index #'s can
        be variables, and every time through I add 3 to each of them, so it can jusr be one list
        of lines of text. Theoretically if I do the math right it should work. Oh, and it needs
        to make the entry object and add it to the list inside the loop
        */
        // you know what forget it, this is impossible, I'll just make it look like 
        // in the assignment and turn it in
        foreach (string line in lines)
        {
        string[] parts = line.Split("~");
        
        

        string entryDate = parts[0];
        string entryPrompt = parts[1];
        string entryInput = parts[2];

        entry._date = entryDate;
        entry._prompt = entryPrompt;
        entry._userEntry = entryInput;
        }
        
    }
    // behavior: write to file
    // update: had to adjust it to access the list so it would do all of them
    public void WriteEntryToFile(string filename, List<Entry> _entries)
    {
        foreach (Entry entry in _entries)
        {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
           outputFile.WriteLine($"{entry._date} ~");
           outputFile.WriteLine($"{entry._prompt} ~");
           outputFile.WriteLine($"{entry._userEntry} ~");
        }
        }
    }
    // behavior: display entries
    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    // behavior: instantiate entry
    public Entry MakeEntry()
    {
        Entry entry = new Entry();
        _entries.Add(entry);
        return entry;
    }
    // behavior: instantiate and use prompt maker
    public string GetJournalPrompt()
    {Prompt promptmaker = new Prompt();
    string journalPrompt = promptmaker.GetRandomPrompt();
    return journalPrompt;
    }

}