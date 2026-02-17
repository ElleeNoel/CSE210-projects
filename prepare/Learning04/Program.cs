using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");

        MathAssignment myMathHomework = new MathAssignment("Section 3.5", "Problems 17-25", "Ellee Land", "Fractions");
        Console.WriteLine(myMathHomework.GetSummary());
        Console.WriteLine(myMathHomework.GetHomeworkList());

        WritingAssignment myEssay = new WritingAssignment("Heroes of Celtic Mythology", "Taran Wanderer", "Celtic Mythology");
        Console.WriteLine(myEssay.GetSummary());
        Console.WriteLine(myEssay.GetWritingInfo());
    }
}