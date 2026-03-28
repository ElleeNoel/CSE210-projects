public class TickTock : Entity
{
    string _flavText1;
    string _flavText2;
    string _attackText1;
    
    public TickTock() : base("Tick-Tock", 7, 2)
    {
        _flavText1 = "Tick-Tock won't stop ticking at you.";
        _flavText2 = "Tick-Tock wants revenge for all the time you've killed.";
        _attackText1 = "Tick-Tock throws a cog at you.";
    }
    // getters
    public string GetAttackText()
    {
        return _attackText1;
    }
    public string GetFlavorText()
    {
        Random random = new Random();
        int randomNumber = random.Next(1,2);
        if (randomNumber == 1)
        {
            return _flavText1;
        }
        else
        {
            return _flavText2;
        }
    }
    public int Attack()
    {
        Console.WriteLine(GetAttackText());
        string roll = HitDie();
        if (roll == "hit")
        {
            Console.WriteLine($"He succeeds! You take {GetAttackDamage} damage.");
            return GetAttackDamage();
        }
        else
        {
            Console.WriteLine("He missed!");
            return 0;
        }
    }
    public override void GainCondition(string effect, string name)
    {
        SetCondition(effect);
        Console.WriteLine($"It worked! Tick-Tock is now {effect}.");
        if (effect == "frozen")
            {
                SetConditionCounter(2);
            }
            else
            {
                SetConditionCounter(1);
            }
    }
    public string HitDie()
    {
        Random random = new Random();
        List<string> playerHitDie = new List<string>();
        playerHitDie.Add("miss");
        playerHitDie.Add("miss");
        playerHitDie.Add("hit");
        playerHitDie.Add("miss");
        int randomNumber = random.Next(0,3);
        string roll = playerHitDie[randomNumber];
        return roll;
    }
}