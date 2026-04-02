using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
        // the is where the "main" for the Kronicle boss fight will be

        // I guess just istantiate the fight and do a bit of flavor stuff before?
        Console.WriteLine("KRONICLE BOSS FIGHT");
        Console.WriteLine();
        Console.WriteLine("Welcome to the game! Press enter to start.");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("INSTRUCTIONS: This is a text-based RPG-style fight game. You will ");
        Console.WriteLine("be prompted for an input any time it is your turn to take an action. When ");
        Console.WriteLine("this happens, you should type one of the options provided with the prompt. ");
        Console.WriteLine();
        Console.WriteLine("BACKGROUND: You've come to the end of an arduous and wacky adventure ");
        Console.WriteLine("through time. Your party consists of: KRONIX, a modern teenager with a ");
        Console.WriteLine("sword and a magical pocketwatch he found in his father's inventing workshop; ");
        Console.WriteLine("EMILY, a dancer from the Age of the Sword; JULIAN, a sharpshooter with ");
        Console.WriteLine("a short temper from the Age of Lights; and HUBERT, an amateur wizard ");
        Console.WriteLine("with an encyclopedic knowledge of the world and a sarcastic sense of humor.");
        Console.WriteLine();
        Console.WriteLine("Press enter when you're ready to start.");
        Console.ReadLine();
        Player player = new Player();
        BaronWight baronWight = new BaronWight();
        Fight fight = new Fight(player, baronWight);
        fight.BossFight();
    }
}