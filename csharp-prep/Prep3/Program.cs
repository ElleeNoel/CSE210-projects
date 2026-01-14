using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

        //Console.Write("What is the magic number? ");
        //string magicNumber = Console.ReadLine();
        //int magicInt = int.Parse(magicNumber);
        Random randomGenerator = new Random();
        int magicInt = randomGenerator.Next(1, 100);
        
        string guessString = "";
        int guessNumber = 0;

        do
        {
            Console.Write("What is your guess? ");
            guessString = Console.ReadLine();
            guessNumber = int.Parse(guessString);

            if (guessNumber < magicInt)
            {
                Console.WriteLine("Higher");
            }
            else if (guessNumber > magicInt)
            {
                Console.WriteLine("Lower");
            }
        } while (guessNumber != magicInt);
        Console.WriteLine("You guessed it!");
    }
}