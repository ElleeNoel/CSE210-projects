using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
        // the is where the "main" for the Kronicle boss fight will be

        // I guess just istantiate the fight and do a bit of flavor stuff before?
        Player player = new Player();
        BaronWight baronWight = new BaronWight();
        Fight fight = new Fight(player, baronWight);
        fight.BossFight();
    }
}