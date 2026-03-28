public class Paradoxer : Entity
{
    string _flavText1;
    string _flavText2;
    string _attackText1;
    string _attackText2;
    
    public Paradoxer() : base("Paradoxer", 12, 3)
    {
        _flavText1 = "Paradoxer doesn't care if it's possible or not.";
        _flavText2 = "Paradoxer wants you to join his infinite loop.";
        _attackText1 = "Paradoxer time-punches you.";
        _attackText2 = "Paradoxer boggles your mind with infinite possibilities.";
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

    public string GetAttackText()
    {
        Random random = new Random();
        int randomNumber = random.Next(1,2);
        if (randomNumber == 1)
        {
            return _attackText1;
        }
        else
        {
            return _attackText2;
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
        Console.WriteLine($"It worked! Paradoxer is now {effect}.");
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
        List<string> enemyHitDie = new List<string>();
        enemyHitDie.Add("miss");
        enemyHitDie.Add("hit");
        enemyHitDie.Add("hit");
        enemyHitDie.Add("miss");
        int randomNumber = random.Next(0,3);
        string roll = enemyHitDie[randomNumber];
        return roll;
    }
}