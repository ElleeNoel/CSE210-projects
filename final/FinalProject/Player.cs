public class Player : Entity
{
    private string _kronixName = "Kronix";
    // haven't figured out how to make it work out with the base class so the base atk is Kronix's
    private string _kronixCondition;
    private int _kronixConditionCounter = -1;
    private string _emilyName = "Emily";
    private string _emilyCondition;
    private int _emilyConditionCounter = -1;
    private string _julianName = "Julian";
    private string _julianCondition;
    private int _julianConditonCounter = -1;
    private string _hubertName = "Hubert";
    private string _hubertCondition;
    private int _hubertConditionCounter = -1;
    private Watch _watch;
    private Inventory _inventory;
    private int _maxMagic;
    private int _magic;
    
    
    
    
    public Player() : base("Player", 60, 5)
    {
       // set values 
    }

    // getters
    public string GetKronixName()
    {
        return _kronixName;
    }
    public string GetEmilyName()
    {
        return _emilyName;
    }
    public string GetJulianName()
    {
        return _julianName;
    }
    public string GetHubertName()
    {
        return _hubertName;
    }
    public int GetMagic()
    {
        return _magic;
    }
    public int GetMaxMagic()
    {
        return _maxMagic;
    }

    // Kronix's stuff
    public int KronixSwordATK(string enemyToATK)
    {
        Console.WriteLine($"Kronix attacks {enemyToATK} with his sword!");
        string roll = HitDie();
        if (roll == "hit")
        {
            Console.WriteLine($"He succeeds! {enemyToATK} takes 5 damage!");
            return 5;
        }
        else
        {
            Console.WriteLine("He misses!");
            return 0;
        }
    }
    public void UseWatch()
    {
        // finally something I can actually not code out
        // REMEMBER to subtract magic power appropriately
    }

    // Emily stuff
    public int EmilyMeleeATK(string enemyToATK)
    {
        // change return to int 1, add to hit roll
        Console.WriteLine($"Emily attacks {enemyToATK} with a flying kick!");
        string roll = HitDie();
        if (roll == "hit")
        {
            Console.WriteLine($"She succeeds! {enemyToATK} takes 1 damage!");
            return 1;
        }
        else
        {
            Console.WriteLine("She misses!");
            return 0;
        }
    }
    public void EmilyShield()
    {
        // figure out how to make this make you take 25% less damage for 1 turn but still whole numbers
        // probably I'll have to override the take damage thing and have a shielded condition *sigh*
    }
    public string EmilyDanceATK()
    {
        // add some flavor text, remember this targets ALL enemies
        Console.WriteLine("Emily does a dizzying dance!");
        return "dizzy";
    }

    // next is Julian
    public int JulianGunATK(string enemyToATK)
    {
        // change to yield int 7, this might cost 1 mp, guaranteed hit
        if ((_magic - 1) >= 0)
        {
            Console.WriteLine($"Julian shoots {enemyToATK}! He takes 7 damage!");
            _magic -= 1;
            return 7;
        }
        else
        {
            Console.WriteLine("You don't have enough magic!");
            return 0;
        }
    }
    public int JulianMeleeATK(string enemyToATK)
    {
        // flavor text
        // returns int 7 on success
        Console.WriteLine($"Julian punches {enemyToATK}!");
        string roll = HitDie();
        if (roll == "hit")
        {
            Console.WriteLine($"He succeeds! {enemyToATK} takes 7 damage!");
            return 7;
        }
        else
        {
            Console.WriteLine("He misses!");
            return 0;
        }
    }
    public void HubertShieldSpell()
    {
        // cost 3 mp, make you take 50% less damage for 3 turns, idk how to even do that
    }
    public void HubertHealSpell()
    {
        // to full HP, mp 4, this one might actually be a void return
        if ((_magic - 4) >= 0)
        {
            Console.WriteLine("Hubert casts a healing spell!");
            _magic -=4;
            SetHP(GetMaxHP());
        }
        else
        {
            Console.WriteLine("You don't have enough magic!");
        }
    }
    public int HubertMeleeATK(string enemyToATK)
    {
        // return int 2 damage on success
        Console.WriteLine($"Hubert attacks {enemyToATK} with his staff!");
        string roll = HitDie();
        if (roll == "hit")
        {
            Console.WriteLine($"He succeeds! {enemyToATK} takes 2 damage!");
            return 2;
        }
        else
        {
            Console.WriteLine("He misses!");
            return 0;
        }
    }
    public void HubertInspect(string enemyName)
    {
        // this might also be a true void return, basically depending on the enemy
        // passed in he tells you different info, in a future game I might have the
        // monster encyclopedia in a separate file or class or something
    }
    public int HubertLightningSpell()
    {
        // not sure if I'll keep this one but I like the idea of him being able to
        // do crazy damage if he feels like it (mp cost? or a separate charger?)
        return 0;
    }

    public void UseInventory()
    {
        // utilize inventory stuff here, and do math to heal you
        // inventory returns number values FYI
        Console.WriteLine("Inventory:");
        _inventory.DisplayInventory();
        Console.Write("What item do you want to use? ");
        string input = Console.ReadLine();
        int statIncrease = _inventory.UseItem(input);
        if (statIncrease == 5)
        {
            // if adding the increase doesn't put you over max, make sure Hubert's spell doesn't either
            if ((GetHP() + statIncrease) !> GetMaxHP())
            {
            SetHP(GetHP() + statIncrease);
            }
            else
            {
                SetHP(GetMaxHP());
            }
        }
        else
        {
           if ((_magic+statIncrease) !> _maxMagic)
            {
                _magic += statIncrease;
            }
            else
            {
                _magic = _maxMagic;
            } 
        }

    }
    public void DisplayActionMenu()
    {
        // basically print what all your options for action are based on which character
        // is currently going
    }
    public override void GainCondition(string effect, string character)
    {
        Random random = new Random();
        int randomNumber = random.Next(1,5);
        if (randomNumber == 2)
        {
            Console.WriteLine($"{character} is frozen!");
            if (character == "Kronix")
            {
                _kronixCondition = effect;
                _kronixConditionCounter = 1;
            }
            else if (character == "Emily")
            {
                _emilyCondition = effect;
                _emilyConditionCounter = 1;
            }
            else if (character == "Julian")
            {
                _julianCondition = effect;
                _julianConditonCounter = 1;
            }
            else
            {
                _hubertCondition = effect;
                _hubertConditionCounter = 1;
            }
        }
    }
    public string HitDie()
    {
        Random random = new Random();
        List<string> playerHitDie = new List<string>();
        playerHitDie.Add("hit");
        playerHitDie.Add("hit");
        playerHitDie.Add("hit");
        playerHitDie.Add("hit");
        playerHitDie.Add("miss");
        int randomNumber = random.Next(0,4);
        string roll = playerHitDie[randomNumber];
        return roll;
    }
}