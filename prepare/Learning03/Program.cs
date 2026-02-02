using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        Fraction fraction1 = new Fraction();
        string fraction1String = fraction1.GetFractionString();
        Console.WriteLine(fraction1String);
        

        Fraction fraction2 = new Fraction(5);

        Fraction fraction3 = new Fraction(3,4);
        fraction3.SetTop(3);
        fraction3.SetBottom(4);
        string fraction3String = fraction3.GetFractionString();
        Console.WriteLine(fraction3String);
        double fraction3Double = fraction3.GetDecimalValue();
        Console.WriteLine(fraction3Double);

        Fraction fraction4 = new Fraction(1,3);
        string fraction4String = fraction4.GetFractionString();
        Console.WriteLine(fraction4String);
        double fraction4Double = fraction4.GetDecimalValue();
        Console.WriteLine(fraction4Double);

        Random random = new Random();
        Fraction fraction5 = new Fraction();
        int fractionNumber = 1;
        for (int i=1; i <= 20; i++)
        {
            int randTop = random.Next(1,100);
            fraction5.SetTop(randTop);
            int randBottom = random.Next(1,100);
            fraction5.SetBottom(randBottom);
            Console.WriteLine($"Fraction {fractionNumber}: string: {fraction5.GetFractionString()} number: {fraction5.GetDecimalValue()}");
            fractionNumber++;
        }
    }
}