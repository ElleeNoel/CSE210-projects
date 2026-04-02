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
    private int _julianConditionCounter = -1;
    private string _hubertName = "Hubert";
    private string _hubertCondition;
    private int _hubertConditionCounter = -1;
    private Watch _watch;
    private Inventory _inventory;
    private int _maxMagic;
    private int _magic;
    private bool _eShield;
    private bool _hShield;
    private int _hShieldCounter = -1;
    private int _hLightningCharger = 2;
    private bool _hLightning;
    
    
    
    
    public Player() : base("Player", 60, 5)
    {
       // set values 
       _kronixCondition = "none";
       _emilyCondition = "none";
       _julianCondition = "none";
       _hubertCondition = "none";
       _watch = new Watch("stop", "rewind", "wither");
       _inventory = new Inventory();
       _maxMagic = 30;
       _magic = 30;
       _eShield = false;
       _hShield = false;
       _hLightning = false;
    }

    // getters
    public string GetKronixName()
    {
        return _kronixName;
    }
    public string GetKronixCondition()
    {
        return _kronixCondition;
    }
    public void SetKronixCondition(string condition)
    {
        _kronixCondition = condition;
    }
    public int GetKConditionCount()
    {
        return _kronixConditionCounter;
    }
    public void SetKConditionCount(int count)
    {
        _kronixConditionCounter = count;
    }
    public string GetEmilyName()
    {
        return _emilyName;
    }
    public int GetEConditionCount()
    {
        return _emilyConditionCounter;
    }
    public string GetEmilyCondition()
    {
        return _emilyCondition;
    }
    public void SetEmilyCondition(string condition)
    {
        _emilyCondition = condition;
    }
    public void SetEConditionCount(int count)
    {
        _emilyConditionCounter = count;
    }
    public bool GetEShield()
    {
        return _eShield;
    }
    public void SetEShield(bool shieldDown)
    {
        _eShield = shieldDown;
    }
    public string GetJulianName()
    {
        return _julianName;
    }
    public string GetJulianCondition()
    {
        return _julianCondition;
    }
    public void SetJulianCondition(string condition)
    {
        _julianCondition = condition;
    }
    public int GetJConditionCount()
    {
        return _julianConditionCounter;
    }
    public void SetJConditionCount(int count)
    {
        _julianConditionCounter = count;
    }
    public string GetHubertName()
    {
        return _hubertName;
    }
    public string GetHubertCondition()
    {
        return _hubertCondition;
    }
    public void SetHubertCondition(string condition)
    {
        _hubertCondition = condition;
    }
    public int GetHConditionCount()
    {
        return _hubertConditionCounter;
    }
    public void SetHConditionCount(int count)
    {
        _hubertConditionCounter = count;
    }
    public bool GetHShield()
    {
        return _hShield;
    }
    public void SetHShield(bool shieldDown)
    {
        _hShield = shieldDown;
    }
    public int GetHShieldCount()
    {
        return _hShieldCounter;
    }
    public void SetHShieldCount(int countDown)
    {
        _hShieldCounter = countDown;
    }
    public bool GetHLightning()
    {
        return _hLightning;
    }
    public void SetHLightning(bool lightningReady)
    {
        _hLightning = lightningReady;
    }
    public int GetHLightningCharger()
    {
        return _hLightningCharger;
    }
    public void SetHLightningCharger(int chargeCount)
    {
        _hLightningCharger = chargeCount;
    }
    public int GetMagic()
    {
        return _magic;
    }
    public void SetMagic(int magic)
    {
        _magic = magic;
    }
    public int GetMaxMagic()
    {
        return _maxMagic;
    }
    public Watch GetWatch()
    {
        return _watch;
    }
    public Inventory GetInventory()
    {
        return _inventory;
    }

    // Kronix's stuff
    public int KronixSwordATK(string enemyToATK)
    {
        Console.WriteLine($"Kronix attacks {enemyToATK} with his sword!");
        string roll = HitDie();
        if (roll == "hit")
        {
            Thread.Sleep(500);            
            Console.WriteLine($"He succeeds! {enemyToATK} takes 5 damage!");
            return 5;
        }
        else
        {
            Thread.Sleep(500);
            Console.WriteLine("He misses!");
            return 0;
        }
    }
    public void WatchMagicCost(string input)
    {
        // finally something I can actually not code out
        // REMEMBER to subtract magic power appropriately
        // okay neew idea, get rid of the choices here, just subtract magic basically
        if (input == "STOP")
        {
            if ((_magic -=2) >= 0)
            {
                _magic -= 2;
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
        }
        else if (input == "REWIND")
        {
            if ((_magic -=1) >= 0)
            {
                _magic -= 1;
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
        }
        else if (input == "WITHER")
        {
            if ((_magic -=10) >= 0)
            {
                _magic -= 10;
            }
            else
            {
                Console.WriteLine("You don't have enough magic!");
            }
        }
    }
    public int WitherAttack(string enemyName, int enemyMaxHP)
    {
        string roll = HitDie();
        if (roll == "hit")
        {
            int damage = _watch.WitherEnemy(enemyMaxHP);
            Thread.Sleep(500);
            Console.WriteLine($"It worked! {enemyName} takes {damage} damage!");
            return damage;
        }
        else
        {
            Thread.Sleep(500);
            Console.WriteLine("It didn't work!");
            return 0;
        }
    }

    // Emily stuff
    public int EmilyMeleeATK(string enemyToATK)
    {
        // change return to int 1, add to hit roll
        Console.WriteLine($"Emily attacks {enemyToATK} with a flying kick!");
        string roll = HitDie();
        if (roll == "hit")
        {
            Thread.Sleep(500);
            Console.WriteLine($"She succeeds! {enemyToATK} takes 1 damage!");
            return 1;
        }
        else
        {
            Thread.Sleep(500);
            Console.WriteLine("She misses!");
            return 0;
        }
    }
    public void EmilyShield()
    {
        // figure out how to make this make you take 25% less damage for 1 turn but still whole numbers
        // probably I'll have to override the take damage thing and have a shielded condition *sigh*
        Console.WriteLine("Emily raises her shield!");
        _eShield = true;
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
        if (_magic-3 >= 0)
        {
            Console.WriteLine("Hubert casts a shield spell!");
            _hShield = true;
            _hShieldCounter = 2;
            _magic -=3;
        }
        else
        {
            Console.WriteLine("You don't have enough magic!");
        }
    }
    public void HubertHealSpell()
    {
        // to full HP, mp 4, this one might actually be a void return
        if ((_magic - 4) >= 0)
        {
            Console.WriteLine("Hubert casts a healing spell!");
            Console.WriteLine("You recover all HP!");
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
        if (enemyName == "Tick-Tock")
        {
            Console.WriteLine("HUBERT: You've fought loads of these guys, remember? Tick-Tocks havbe a max HP ");
            Console.WriteLine("of 7 and an attack power of 2, no special attacks or anything. In other words, ");
            Console.WriteLine("they're pretty much losers. You can take them out easy.");
        }
        else if (enemyName == "Paradoxer")
        {
            Console.WriteLine("HUBERT: You mean you don't remember these guys? Fine, I guess I'll remind you. ");
            Console.WriteLine("Paradoxers have a max HP of 12, and an attack power of 3. You want to ");
            Console.WriteLine("watch out and avoid his punches, but there's not much else to it.");
        }
        else if (enemyName == "Baron Wight")
        {
            Console.WriteLine("HUBERT: This is Baron Wight, who as far as I can tell is the jerk responsible ");
            Console.WriteLine("for this whole mess. He's a lot more powerful than anyone else we've faced, so ");
            Console.WriteLine("be careful. This guy has a max HP of 200. He can hit you with his cane for ");
            Console.WriteLine("6 damamge, cast a time-stop spell to freeze any of us, or attack with magic. ");
            Console.WriteLine("Watch out if he starts charging his temporal laser beam attack, because you ");
            Console.WriteLine("do NOT want to get hit with that thing. Considering we don't want the world ");
            Console.WriteLine("to end, we've got to beat him. But I know you can do this!");
        }
    }
    public int HubertLightningSpell(string target)
    {
        // not sure if I'll keep this one but I like the idea of him being able to
        // do crazy damage if he feels like it (mp cost? or a separate charger?)
        Console.WriteLine($"Hubert attacks {target} with lightning!");
        string roll = HitDie();
        if (roll == "hit")
        {
            Console.WriteLine($"He succeeds! {target} takes 12 damage!");
            return 12;
        }
        else
        {
            Console.WriteLine("He misses!");
            return 0;
        }
    }

    public override void TakeDamage(int damage)
    {
        if (_eShield && _hShield)
        {
            // turn damage into 25% of total (minus 25 and 75 %) and turn her shield off
            SetHP (GetHP()-((int)damage/4));
            
        }
        else if (_eShield)
        {
            // make damage 75% of total, and turn her shield off
            SetHP (GetHP()-(3*(int)damage/4));
        }
        else if (_hShield)
        {
            // make damage 50% of total
            SetHP (GetHP()-((int)damage/2));
        }
        else
        {
            // do full damage
            SetHP(GetHP()-damage);
        }
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
    public void DisplayActionMenu(string character)
    {
        // basically print what all your options for action are based on which character
        // is currently going
        Console.WriteLine("What do you want to do?");
        if (character == "Kronix")
        {
           Console.WriteLine("SWORD - Melee attack. Deals 5 damage when successful.");
           Console.WriteLine("WATCH - Cast a spell! Be sure you have enough magic.");
           Console.WriteLine("INVENTORY - Use an item to recover HP or magic!"); 
        }
        else if (character == "Emily")
        {
            Console.WriteLine("DANCE - A dance attack that leaves many enemies dizzy for 1 turn!");
            Console.WriteLine("SHIELD - Use Emily's parasol as a shield! Take 25% less damage for one turn.");
            Console.WriteLine("KICK - A weak melee attack. Does 1 damage on success.");
            Console.WriteLine("INVENTORY - Use an item to recover HP or magic!");
        }
        else if (character == "Julian")
        {
            Console.WriteLine("GUN - He never misses! Guaranteed 7 damage to one enemy. Cost 1 MP.");
            Console.WriteLine("PUNCH - A mighty melee attack! Deals 7 damage on success.");
            Console.WriteLine("INVENTORY - Use an item to recover HP or magic!");
        }
        else
        {
            Console.WriteLine("INSPECT - Hubert's specialty. Use to learn an enemy's stats and weaknesses.");
            Console.WriteLine("SHIELD - A powerful shield spell. Take 50% less damage for 3 turns. Cost 3 MP");
            Console.WriteLine("HEAL - A powerful healing spell. Recover all HP for 4 MP.");
            Console.WriteLine("LIGHTNING - A mighty magical attack! When it's charged, use it to deal 12 damage.");
            Console.WriteLine("STAFF - A low-level melee attack. Deals 2 damage on success.");
            Console.WriteLine("INVENTORY - Use an item to recover HP or magic!");
        }
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
                _julianConditionCounter = 1;
            }
            else
            {
                _hubertCondition = effect;
                _hubertConditionCounter = 1;
            }
        }
        else
        {
            Console.WriteLine("It didn't work! You're okay!");
        }
    }
    public override string HitDie()
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