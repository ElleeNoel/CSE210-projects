using System;
using System.Globalization;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        List <int> numbers = new List<int>();
        string stringNumber = "";
        int number = 0;
        while (stringNumber != "0")
        {
            Console.Write("Enter a number: ");
            stringNumber = Console.ReadLine();
            number = int.Parse(stringNumber);
            numbers.Add(number);
        }
        // get the sum first
        int sum = 0;
        foreach (int item in numbers)
        {
            sum += item;
        }
        Console.WriteLine($"The sum is: {sum}");
        // next, average, I think we can reuse the sum number?
        float average = ((float) sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        // finally, the maximum, I think there's a method or operator or whatever for that?
        // oh boy, this is going to be more complicated than I thought. 
        // max only compares 2 items, not a list. I think the easiest way to do this
        // will be to have a variable number the length of the list, a while loop,
        // subtract one each time, condition is >0.
        // if statement to compare two index values, probably need a special condition for
        // the first one in case the first number is smaller bc you'd need to skip an index
        
        // jk do a foreach loop, set a "max number" variable, compare each to THAT, replace if greater
        int maxNumber = 0;
        foreach (int digit in numbers)
        {
            if (digit >= maxNumber)
            {
                maxNumber = digit;
            }
        }
        Console.WriteLine($"The largest number is {maxNumber}");
        }
    }
