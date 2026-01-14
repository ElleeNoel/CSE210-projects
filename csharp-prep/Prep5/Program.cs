using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int birthYear;
        PromptUserBirthYear(out birthYear);
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber, birthYear);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string userInput = Console.ReadLine();
        int userNumber = int.Parse(userInput);
        return userNumber;
    }
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.WriteLine("Please enter the year you were born: ");
        string userInput = Console.ReadLine();
        birthYear = int.Parse(userInput);
    }
    static int SquareNumber(int number)
    {
        int squared = number*number;
        return squared;
    }
    static void DisplayResult(string userName, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}.");
        int userAge = 2026 - birthYear;
        Console.WriteLine($"{userName}, this year you will turn {userAge}.");
    }
}