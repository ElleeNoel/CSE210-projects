using System.Text;

public class Memorizer
{
    private string _wholeText;
    private List<Word> _words = new List<Word>();

    // needs to take in or get a reference and all the attached info (constructor?)
    public Memorizer(Reference reference)
    {
        _wholeText = reference.GetScripture();
    
        string[] splitString = _wholeText.Split(" ");
        foreach (string newWord in splitString)
        {
            Word word = new Word();
            word.SetWord(newWord);
            _words.Add(word);
        }
    }
   
    // need to loop through the string delimited by spaces, make them into word objects,
    // and put them in the list
    // DONT forget to skip punctuation, and add spaces back in!
    public int DeleteRandom3()
    {
        Random random = new Random();
        int index1 = random.Next(_words.Count());
        int index2 = random.Next(_words.Count());
        int index3 = random.Next(_words.Count());
        int totalWords = _words.Count();
        // okay so I've got 3 random indexes that should referesh every time,
        // now I need to make random words by pulling from the list by the indexes,
        // do I need to particularly not make them variables so it's messing with the
        // list directly? Let's see if we can even do that.
        // nvm idk how to double index, just remember to reassign to same index
        Word randomWord1 = _words[index1];
        string randWord1 = randomWord1.GetWord();
        // maybe if I make variables of type char for the punctuation?
        // nvm IMPORTANT single quotes are characters, double quotes are strings! Not interchangeable!
        if (randWord1.Contains("_"))
        {
            int replaceIndex = random.Next(_words.Count());
            Word replaceWord = _words[replaceIndex];
            string repWord = replaceWord.GetWord();
            StringBuilder blankWord = new StringBuilder();
            foreach (char letter in repWord)
            {
                if (letter != ',' && letter != ';' && letter != ' ' && letter != '.' && letter != ':')
                {
                    //letter.Replace(letter, '_');
                    blankWord.Append('_');
                }
                else
                {
                    blankWord.Append(letter);
                }
            }
            string blank = blankWord.ToString();
            replaceWord.SetWord(blank);
            totalWords -=1;
        }
        else
        {
            StringBuilder blankWord = new StringBuilder();
            foreach (char letter in randWord1)
            {
               if (letter != ',' && letter != ';' && letter != ' ' && letter != '.' && letter != ':')
                {
                   // letter.Replace(letter, _");
                   blankWord.Append('_');
                }
                else
                {
                    blankWord.Append(letter);
                }

            }
            string blank = blankWord.ToString();
            randomWord1.SetWord(blank);
            totalWords -=1;
        }
        // then pull out the text and check if the first character is _, if not
        // foreach letter in the word if letter is not a punctuation or space
        // letter = _, if it's already blank make a replacement random index 
        Word randomWord2 = _words[index2];
        string randWord2 = randomWord2.GetWord();
        if (randWord2.Contains("_"))
        {
            int replaceIndex = random.Next(_words.Count());
            Word replaceWord = _words[replaceIndex];
            string repWord = replaceWord.GetWord();
            StringBuilder blankWord = new StringBuilder();
            foreach (char letter in repWord)
            {
                if (letter != ',' && letter != ';' && letter != ' ' && letter != '.' && letter != ':')
                {
                    //letter.Replace(letter, '_');
                    blankWord.Append('_');
                }
                else
                {
                    blankWord.Append(letter);
                }
            }
            string blank = blankWord.ToString();
            replaceWord.SetWord(blank);
            totalWords -=1;
        }
        else
        {
            StringBuilder blankWord = new StringBuilder();
            foreach (char letter in randWord2)
            {
               if (letter != ',' && letter != ';' && letter != ' ' && letter != '.' && letter != ':')
                {
                   // letter.Replace(letter, _");
                   blankWord.Append('_');
                }
                else
                {
                    blankWord.Append(letter);
                }

            }
            string blank = blankWord.ToString();
            randomWord2.SetWord(blank);
            totalWords -=1;
        }
        Word randomWord3 = _words[index3];
        string randWord3 = randomWord3.GetWord();
        if (randWord3.Contains("_"))
        {
            int replaceIndex = random.Next(_words.Count());
            Word replaceWord = _words[replaceIndex];
            string repWord = replaceWord.GetWord();
            StringBuilder blankWord = new StringBuilder();
            foreach (char letter in repWord)
            {
                if (letter != ',' && letter != ';' && letter != ' ' && letter != '.' && letter != ':')
                {
                    //letter.Replace(letter, '_');
                    blankWord.Append('_');
                }
                else
                {
                    blankWord.Append(letter);
                }
            }
            string blank = blankWord.ToString();
            replaceWord.SetWord(blank);
            totalWords -=1;
        }
        else
        {
            StringBuilder blankWord = new StringBuilder();
            foreach (char letter in randWord3)
            {
               if (letter != ',' && letter != ';' && letter != ' ' && letter != '.' && letter != ':')
                {
                   // letter.Replace(letter, _");
                   blankWord.Append('_');
                }
                else
                {
                    blankWord.Append(letter);
                }

            }
            string blank = blankWord.ToString();
            randomWord3.SetWord(blank);
            totalWords -=1;
        }
        
        return totalWords;
    
    }
    // use the print behavior in the word class to print the whole sentence
    public void DisplayText()
    {
        foreach (Word word in _words)
        {
            word.DisplayWord();
        }
    }

}