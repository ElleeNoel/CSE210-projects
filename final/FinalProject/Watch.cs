public class Watch
{
    bool _haveStop;
    bool _haveRewind;
    bool _haveWither;

    // multiple constructors based on how many you have, just the one for now?
    public Watch(string stop, string rewind, string wither)
    {
        _haveStop = true;
        _haveRewind = true;
        _haveWither = true;
    }

    public void DisplayWatchMenu()
    {
        // have variations based on how many spells you have
        Console.WriteLine("WATCH:");
        if (_haveStop && _haveRewind && _haveWither)
        {
           Console.WriteLine("STOP - Freezes a selected enemy for 2 turns. Cost 2MP.");
           Console.WriteLine("REWIND - Make a selected enemy dizzy for 1 turn. Cost 1MP.");
           Console.WriteLine("WITHER - Magical attack that drains 40% of a selected enemy's total life force. Cost 10MP."); 
        }
        else if (_haveStop && _haveRewind)
        {
            Console.WriteLine("STOP - Freezes a selected enemy for 2 turns. Cost 2MP.");
            Console.WriteLine("REWIND - Make a selected enemy dizzy for 1 turn. Cost 1MP.");
        }
        else if (_haveStop)
        {
            Console.WriteLine("STOP - Freezes a selected enemy for 2 turns. Cost 2MP.");
        }
        else
        {
            Console.WriteLine();
        }
    }

    public string StopEnemy()
    {
        return "frozen";
    }
    public string RewindEnemy()
    {
        return "dizzy";
    }
    public int WitherEnemy(int enemyMaxHP)
    {
        int healthLoss = (int)((enemyMaxHP*4)/10);
        return healthLoss;
    }
}