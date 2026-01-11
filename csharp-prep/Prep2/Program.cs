using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.Write("What was your grade?");
        string userGrade = Console.ReadLine();
        int gradeNumber = int.Parse(userGrade);
        string gradeLetter = "";

        if (gradeNumber >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradeNumber >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradeNumber >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradeNumber >= 60)
        {
            gradeLetter = "D";
        }
        else if (gradeNumber < 60)
        {
            gradeLetter = "F";
        }

        Console.WriteLine($"You got a {gradeLetter}");


        if (gradeNumber >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }
        else
        {
            Console.WriteLine("You failed. Better luck next time!");
        }
    }
}