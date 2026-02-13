public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _scripture;
    private string _reference;

    public string GetBook()
    {
        return _book;
    }
    public void SetBook(string book)
    {
        _book = book;
    }
    public string GetChapter()
    {
        return _chapter;
    } 
    public void SetChapter(string chapter)
    {
        _chapter = chapter;
    }
    public string GetVerse()
    {
        return _verse;
    }
    public void SetVerse(string verses)
    {
        _verse = verses;
    }
    public void DisplayReference()
    {
        Console.Write($"{_book} {_chapter}:{_verse} ");
    }
    public Reference(string reference)
    {
        if (reference == "1 Nephi 3:7")
        {
            _scripture = @"And it came to pass that I, Nephi, said unto my father: 
I will go and do the things which the Lord has commanded, 
for I know that the Lord giveth no commandments unto the 
children of men, save he shall prepare a way for them 
that they may accomplish the thing which he commandeth them.";
        }
        else if (reference == "2 Timothy 1:7")
        {
            _scripture = @"For God hath not given us the spirit of fear; but 
of power, and of love, and of a sound mind.";
        }
        else if (reference == "John 3:16")
        {
            _scripture = @"For God so loved the world, that he gave his only 
begotten Son, that whosoever believeth in him should not 
perish, but have everlasting life.";
        }
        else if (reference == "John 3:16-17")
        {
            _scripture = @"For God so loved the world, that he gave his only 
begotten Son, that whosoever believeth in him should not 
perish, but have everlasting life. For God sent not his Son 
into the world to condemn the world; but that the world 
through him might be saved.";
        }
        else if (reference == "2 Nephi 2:24-25")
        {
            _scripture = @"But behold, all things have been done in the 
wisdom of him who knoweth all things. Adam fell that men 
might be; and men are, that they might have joy.";
        }
        else
        {
            Console.WriteLine("Invalid response, sorry.");
        }

    }
    // okay, let's do 1 Ne 3:7, the one in Timothy, John 3:16, and 2 Ne 2:24-25
    public void SetReference(string reference)
    {
        _reference = reference;
    }
    public string GetScripture()
    {
        return _scripture;
    }
}