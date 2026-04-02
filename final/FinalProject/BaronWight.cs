public class BaronWight : Entity
{
    private string _meleeATKText;
    private string _flavText1;
    private int _attackChargeCounter = -1;
    private List<string> attackList = new List<string>();
    private List<string> smallEnemies = new List<string>();
    public BaronWight() : base("Baron Wight", 200, 6)
    {
        // need to write some flavor text. I think the basical "flav text" is displaying
        // at the top of the turn, so it's up while you're picking what you'll do.
        // and the other stuff is descirbing the actions and attacks of the enemies, on their turn
        _meleeATKText = "Baron Wight attacks you with his cane.";
        _flavText1 = "It all comes down to this.";
        attackList.Add("melee attack");
        attackList.Add("melee attack");
        attackList.Add("make new friends");
        attackList.Add("time freeze attack");
        attackList.Add("charged attack");
        attackList.Add("make new friends");
        attackList.Add("melee attack");
        attackList.Add("time freeze attack");
        attackList.Add("make new friends");
        attackList.Add("melee attack");
        attackList.Add("make new friends");
        smallEnemies.Add("Tick-Tock");
        smallEnemies.Add("Paradoxer");
        smallEnemies.Add("Tick-Tock");
    }
    public int GetChargeCount()
    {
        return _attackChargeCounter;
    }
    public void SetChargeCount(int countDown)
    {
        _attackChargeCounter = countDown;
    }
    public string GetFlavorText()
    {
        return _flavText1;
    }
    public string WhoToAttack()
    {
        // this will only be used for the time freeze attack
        Random random = new Random();
        int randomNumber = random.Next(1,4);
        if (randomNumber == 1)
        {
            return "Kronix";
        }
        else if (randomNumber == 2)
        {
            return "Emily";
        }
        else if (randomNumber == 3)
        {
            return "Julian";
        }
        else
        {
            return "Hubert";
        }
    }
    public string PickAttack()
    {
       Random random = new Random();
       int randomIndex = random.Next(0, 10);
       string selectedAttack = attackList[randomIndex];
       // call the stuff to do the attack in fight
       return selectedAttack;
    }
    public int MeleeATK()
    {
         Console.WriteLine(_meleeATKText);
        string roll = HitDie();
        if (roll == "hit")
        {
            Console.WriteLine($"He succeeds! You take {GetAttackDamage()} damage.");
            return GetAttackDamage();
        }
        else
        {
            Console.WriteLine("He missed!");
            return 0;
        }
    }
    // gotta make sure to remember to have fight check if damage is 0 and not print a damage message if so
    public int ChargedAttack()
    {
        // check charge value in fight, if it's -1 it's able to pick an attack
        int ChargedAttackDamage;
        if (_attackChargeCounter == -1)
        {
            Console.WriteLine("Baron Wight begins charging his temporal laser attack!");
            _attackChargeCounter = 2;
            ChargedAttackDamage = 0;
            return ChargedAttackDamage;
        }
        else if (_attackChargeCounter == 0)
        {
            ChargedAttackDamage = 12;
            return ChargedAttackDamage;
        }
        else
        {
            ChargedAttackDamage = 0;
            return ChargedAttackDamage;
        }
    }
    public string TimeFreezeATK()
    {
        Console.WriteLine("Baron Wight casts a time freeze spell!");
        return "frozen";
    }
    public Entity MakeNewFriends()
    {
        Random random = new Random();
       int randomIndex = random.Next(0, 2);
       string selectedEnemy = smallEnemies[randomIndex];
       if (selectedEnemy == "Tick-Tock")
        {
            Console.WriteLine("Baron Wight summoned a Tick-Tock!");
            TickTock tickTock = new TickTock();
            return tickTock;
        }
        else
        {
            Console.WriteLine("Baron Wight summoned a Paradoxer!");
            Paradoxer paradoxer = new Paradoxer();
            return paradoxer;
        }
    }
    public override void GainCondition(string name, string effect)
    {
        // so basically I need to figure out what I want the odds to be of success to
        // stun this guy. is 50/50 too easy? 1/3 maybe? randomly pick from numbers, then
        // if it's a success number he sets his condition to stunned. ooh, do I need an 
        // attribute for the turn countdown for stuns? would that go in fight?
        // well anyone could be stunned so I think it needs to go up top 
        // and is changed/ function implemented down in fight
        Random random = new Random();
        int randomNumber = random.Next(1,4);
        if (randomNumber == 3)
        {
            SetCondition(effect);
            Console.WriteLine($"You succeeded! Baron Wight is now {effect}.");
            if (effect == "frozen")
            {
                SetConditionCounter(2);
            }
            else
            {
                SetConditionCounter(1);
            }
        }
        else
        {
            Console.WriteLine("It didn't work!");
        }
    }
    public override string HitDie()
    {
        Random random = new Random();
        List<string> enemyHitDie = new List<string>();
        enemyHitDie.Add("hit");
        enemyHitDie.Add("hit");
        enemyHitDie.Add("hit");
        enemyHitDie.Add("hit");
        enemyHitDie.Add("hit");
        enemyHitDie.Add("miss");
        int randomNumber = random.Next(0,5);
        string roll = enemyHitDie[randomNumber];
        return roll;
    }
}