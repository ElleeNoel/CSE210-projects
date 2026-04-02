public class Fight
{
    private List<Entity> _fightParticipants = new List<Entity>();
    private Player _player;
    private BaronWight _boss;
    public Fight(Player Player, BaronWight Boss)
    {
        _boss = Boss;
        _player = Player;
        _fightParticipants.Add(Player);
        _fightParticipants.Add(Boss);
    }
    // is it okay to just have a massive function implementing stuff here, then just play that in main?
    public void BossFight()
    {
        /* Okay, get ready to get crazy. This thing needs to display the "screen top" stats
        at the top of every turn, loop through the list while player and boss hp are greater than 0,
        take inputs and run functionality for each character's turn, print style stuff, 
        check at the top of every character's turn what condition they're in and if they have 
        any countdowns active, and pass damage, conditions, etc back and forth via (). Plus any
        probability stuff I decide not to do in entity classes, although I might just give them each
        a functino to do that
        Also remember to have people's condition counters go down every turn they are stunned
        */
        Console.WriteLine("You've reached the inner sanctum. Baron Wight looms over you. ");
        Console.WriteLine("Every timeline, every monster you've fought, has led to this ");
        Console.WriteLine("moment. The end of the world is only minutes away. If you fail, ");
        Console.WriteLine("it will happen.");
        Console.WriteLine(_boss.GetFlavorText());
        Console.WriteLine();
        while (_player.GetHP() > 0 && _boss.GetHP() >0)
        {
            foreach (Entity fighter in _fightParticipants)
            {
                if (fighter.GetName() == "Player")
                {
                    // go through each character. Check conditions first. Print menus with descriptions as needed.
                    // remember to subtract from all shield, condition, etc counters every turn
                    Console.WriteLine();
                    Console.WriteLine("Enemies standing:");
                    foreach (Entity creature in _fightParticipants)
                    {
                        if (creature.GetName() != "Player")
                        {
                            if (creature.GetHP() >0)
                            {
                            Console.WriteLine($"{creature.GetName()} - {creature.GetHP()} HP");
                            }
                            else
                            {
                                _fightParticipants.Remove(creature);
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Player HP: {_player.GetHP()} MP: {_player.GetMagic()}");
                    if (_player.GetEShield())
                    {
                        _player.SetEShield(false);
                    }
                    if (_player.GetHShield())
                    {
                        _player.SetHShieldCount(_player.GetHShieldCount()-1);
                        if (_player.GetHShieldCount() < 0)
                        {
                            _player.SetHShield(false);
                        }
                    }
                    if (_player.GetKronixCondition() != "none")
                    {
                        _player.SetKConditionCount(_player.GetKConditionCount()-1);
                        if (_player.GetKConditionCount() < 0)
                        {
                            _player.SetKronixCondition("none");
                        }
                    }
                    if (_player.GetEmilyCondition() != "none")
                    {
                        _player.SetEConditionCount(_player.GetEConditionCount()-1);
                        if (_player.GetEConditionCount() < 0)
                        {
                            _player.SetEmilyCondition("none");
                        }
                    }
                    if (_player.GetJulianCondition() != "none")
                    {
                        _player.SetJConditionCount(_player.GetJConditionCount()-1);
                        if (_player.GetJConditionCount() < 0)
                        {
                            _player.SetJulianCondition("none");
                        }
                    }
                    if (_player.GetHubertCondition() != "none")
                    {
                        _player.SetHConditionCount(_player.GetHConditionCount()-1);
                        if (_player.GetHConditionCount() < 0)
                        {
                            _player.SetHubertCondition("none");
                        }
                    }
                    if (_player.GetHLightningCharger() == 0)
                    {
                        _player.SetHLightning(true);
                        Console.WriteLine("Hubert's lightning attack is charged!");
                        _player.SetHLightningCharger(2);
                    }
                    else if (_player.GetHLightning() != true)
                    {
                        _player.SetHLightningCharger(_player.GetHLightningCharger()-1);
                    }
                    Console.WriteLine();
                    Console.WriteLine("It's KRONIX'S turn!");
                    if (_player.GetKronixCondition() == "frozen")
                    {
                        Console.WriteLine("Kronix is frozen!");
                        _player.SetKConditionCount(_player.GetKConditionCount() - 1);
                        if (_player.GetKConditionCount() < 0)
                        {
                            _player.SetKronixCondition("none");
                        }
                    }
                    else
                    {
                       string input = "";
                       while (input.ToUpper() != "SWORD" && input.ToUpper() != "WATCH" && input.ToUpper() != "INVENTORY")
                        {
                            _player.DisplayActionMenu("Kronix");
                            input = Console.ReadLine();
                        } 
                        if (input.ToUpper() == "SWORD")
                        {
                            Console.Write("Who do you want to attack? ");
                            string target = Console.ReadLine();
                            int damage = _player.KronixSwordATK(target);
                            foreach (Entity creature in _fightParticipants)
                            {
                                if (creature.GetName() == target)
                                {
                                    creature.TakeDamage(damage);
                                    break;
                                }
                            }
                        }
                        else if (input.ToUpper() == "WATCH")
                        {
                            _player.GetWatch().DisplayWatchMenu();
                            Console.Write("What spell do you want to use? ");
                            string spell = Console.ReadLine();
                            Console.Write("Who do you want to attack? ");
                            string target = Console.ReadLine();
                            if (spell.ToUpper() == "STOP")
                            {
                                _player.WatchMagicCost("STOP");
                                string condition = _player.GetWatch().StopEnemy();
                                foreach (Entity creature in _fightParticipants)
                                {
                                if (creature.GetName() == target)
                                    {
                                    creature.GainCondition(target, condition);
                                    break;
                                    }
                                }
                            }
                            else if (spell.ToUpper() == "REWIND")
                            {
                                _player.WatchMagicCost("REWIND");
                                string condition = _player.GetWatch().RewindEnemy();
                                foreach (Entity creature in _fightParticipants)
                                {
                                if (creature.GetName() == target)
                                    {
                                    creature.GainCondition(target, condition);
                                    break;
                                    }
                                } 
                            }
                            else if (spell.ToUpper() == "WITHER")
                            {
                                _player.WatchMagicCost("WITHER");
                                foreach (Entity creature in _fightParticipants)
                                {
                                if (creature.GetName() == target)
                                    {
                                    int magicDamage = _player.WitherAttack(creature.GetName(), creature.GetMaxHP());
                                    creature.TakeDamage(magicDamage);
                                    break;
                                    }
                                }
                            }
                        }
                        else if (input.ToUpper() == "INVENTORY")
                        {
                            _player.GetInventory().DisplayInventory();
                            Console.Write("What item do you want to use? ");
                            string item = Console.ReadLine();
                            int statIncrease = _player.GetInventory().UseItem(item);
                            if (item.ToUpper() == "BUBBLEGUM")
                            {
                                _player.SetHP(_player.GetHP() + statIncrease);
                            }
                            else
                            {
                                _player.SetMagic(_player.GetMagic() + statIncrease);
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("It's EMILY'S turn!");
                    if (_player.GetEmilyCondition() == "frozen")
                    {
                        Console.WriteLine("Emily is frozen!");
                        _player.SetEConditionCount(_player.GetEConditionCount() - 1);
                        if (_player.GetEConditionCount() < 0)
                        {
                            _player.SetEmilyCondition("none");
                        }
                    }
                    else
                    {
                        string input = "";
                        while (input.ToUpper() != "DANCE" && input.ToUpper() != "SHIELD" && input.ToUpper() != "INVENTORY" && input.ToUpper() != "KICK")
                        {
                            _player.DisplayActionMenu("Emily");
                            input = Console.ReadLine();
                            if (input.ToUpper() == "DANCE")
                            {
                                string condition = _player.EmilyDanceATK();
                                foreach (Entity creature in _fightParticipants)
                                {
                                    if (creature.GetName() != "Player")
                                    {
                                        creature.GainCondition(creature.GetName(), condition);
                                    }
                                }
                            }
                            else if (input.ToUpper() == "SHIELD")
                            {
                                _player.EmilyShield();
                            }
                            else if (input.ToUpper() == "KICK")
                            {
                                Console.Write("Who do you want to attack? ");
                                string target = Console.ReadLine();
                                int damage = _player.EmilyMeleeATK(target);
                                foreach (Entity creature in _fightParticipants)
                                {
                                    if (creature.GetName() == target)
                                    {
                                        creature.TakeDamage(damage);
                                        break;
                                    }
                                }
                            }
                            else if (input.ToUpper() == "INVENTORY")
                            {
                                _player.GetInventory().DisplayInventory();
                                Console.Write("What item do you want to use? ");
                                string item = Console.ReadLine();
                                int statIncrease = _player.GetInventory().UseItem(item);
                                if (item.ToUpper() == "BUBBLEGUM")
                                {
                                    _player.SetHP(_player.GetHP() + statIncrease);
                                }
                                else
                                {
                                    _player.SetMagic(_player.GetMagic() + statIncrease);
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("It's JULIAN'S turn!");
                    if (_player.GetJulianCondition() == "frozen")
                    {
                        Console.WriteLine("Julian is frozen!");
                        _player.SetJConditionCount(_player.GetJConditionCount() - 1);
                        if (_player.GetJConditionCount() < 0)
                        {
                            _player.SetJulianCondition("none");
                        }
                    }
                    else
                    {
                        string input = "";
                        while (input.ToUpper() != "GUN" && input.ToUpper() != "PUNCH" && input.ToUpper() != "INVENTORY")
                        {
                            _player.DisplayActionMenu("Julian");
                            input = Console.ReadLine();
                            if (input.ToUpper() == "GUN")
                            {
                                Console.Write("Who do you want to attack? ");
                                string target = Console.ReadLine();
                                int damage = _player.JulianGunATK(target);
                                foreach (Entity creature in _fightParticipants)
                                {
                                    if (creature.GetName() == target)
                                    {
                                        creature.TakeDamage(damage);
                                        break;
                                    }
                                }
                            }
                            else if (input.ToUpper() == "PUNCH")
                            {
                                Console.Write("Who do you want to attack? ");
                                string target = Console.ReadLine();
                                int damage = _player.JulianMeleeATK(target);
                                foreach (Entity creature in _fightParticipants)
                                {
                                    if (creature.GetName() == target)
                                    {
                                        creature.TakeDamage(damage);
                                        break;
                                    }
                                }
                            }
                            else if (input.ToUpper() == "INVENTORY")
                            {
                                _player.GetInventory().DisplayInventory();
                                Console.Write("What item do you want to use? ");
                                string item = Console.ReadLine();
                                int statIncrease = _player.GetInventory().UseItem(item);
                                if (item.ToUpper() == "BUBBLEGUM")
                                {
                                    _player.SetHP(_player.GetHP() + statIncrease);
                                }
                                else
                                {
                                    _player.SetMagic(_player.GetMagic() + statIncrease);
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("It's HUBERT'S turn!");
                    if (_player.GetHubertCondition() == "frozen")
                    {
                        Console.WriteLine("Hubert is frozen!");
                        _player.SetHConditionCount(_player.GetHConditionCount() - 1);
                        if (_player.GetHConditionCount() < 0)
                        {
                            _player.SetHubertCondition("none");
                        }
                    }
                    else
                    {
                        string input = "";
                        while (input.ToUpper() != "INSPECT" && input.ToUpper() != "SHIELD" && input.ToUpper() != "INVENTORY" && input.ToUpper() != "HEAL" && input.ToUpper() != "STAFF" && input.ToUpper() != "LIGHTNING")
                        {
                            _player.DisplayActionMenu("Hubert");
                            input = Console.ReadLine();
                            if (input.ToUpper() == "INSPECT")
                            {
                                Console.Write("Which enemy do you want to inspect? ");
                                string target = Console.ReadLine();
                                foreach (Entity creature in _fightParticipants)
                                {
                                    if (creature.GetName() == target)
                                    {
                                        _player.HubertInspect(target);
                                        break;
                                    }
                                }
                            }
                            else if (input.ToUpper() == "SHIELD")
                            {
                                _player.HubertShieldSpell();
                            }
                            else if (input.ToUpper() == "HEAL")
                            {
                                _player.HubertHealSpell();
                            }
                            else if (input.ToUpper() == "LIGHTNING")
                            {
                                Console.Write("Who do you want to attack? ");
                                string target = Console.ReadLine();
                                int damage = _player.HubertLightningSpell(target);
                                foreach (Entity creature in _fightParticipants)
                                {
                                    if (creature.GetName() == target)
                                    {
                                        creature.TakeDamage(damage);
                                        break;
                                    }
                                }
                            }
                            else if (input.ToUpper() == "STAFF")
                            {
                                Console.Write("Who do you want to attack? ");
                                string target = Console.ReadLine();
                                int damage = _player.HubertMeleeATK(target);
                                foreach (Entity creature in _fightParticipants)
                                {
                                    if (creature.GetName() == target)
                                    {
                                        creature.TakeDamage(damage);
                                        break;
                                    }
                                }
                            }
                            else if (input.ToUpper() == "INVENTORY")
                             {
                                _player.GetInventory().DisplayInventory();
                                Console.Write("What item do you want to use? ");
                                string item = Console.ReadLine();
                                int statIncrease = _player.GetInventory().UseItem(item);
                                if (item.ToUpper() == "BUBBLEGUM")
                                {
                                    _player.SetHP(_player.GetHP() + statIncrease);
                                }
                                else
                                {
                                    _player.SetMagic(_player.GetMagic() + statIncrease);
                                }
                            } 
                        }
                    }
                }
                else if (fighter.GetName() == "Baron Wight")
                {
                    // I only needed to separate boss from other bad guys because he has more functionality
                    // to pick between different attacks, in a future design I might have another inherited generation for bad guy
                    if (_boss.GetCondition() == "none")
                    {
                        if (_boss.GetChargeCount() <0)
                        {
                            string bossAttack = _boss.PickAttack();
                            if (bossAttack == "melee attack")
                            {
                                int playerDamage = _boss.MeleeATK();
                                _player.TakeDamage(playerDamage);
                            }   
                            else if (bossAttack == "time freeze attack")
                            {
                                string condition = _boss.TimeFreezeATK();
                                string victim = _boss.WhoToAttack();
                                _player.GainCondition(condition, victim);
                            }
                            else if (bossAttack == "charged attack")
                            {
                                int damage = _boss.ChargedAttack();
                                _player.TakeDamage(damage);
                            }
                            else
                            {
                                Entity baddie = _boss.MakeNewFriends();
                                _fightParticipants.Add(baddie);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Baron Wight is charging his temporal laser!");
                            _boss.SetChargeCount(_boss.GetChargeCount()-1);
                            if (_boss.GetChargeCount() <0)
                            {
                                Console.WriteLine("Baron Wight unleashes a mighty magical attack!");
                                int damage = _boss.ChargedAttack();
                                _player.TakeDamage(damage);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Baron Wight is {_boss.GetCondition()}! He can't attack!");
                        _boss.SetConditionCounter(_boss.GetConditionCounter()-1);
                        if (_boss.GetConditionCounter() <0)
                        {
                            _boss.SetCondition("none");
                        }
                    }
                }
                else
                {
                    // okay, we have a slight problem. Can't access class-specific methods, bc
                    // it's a vague entity class. Can't specify, because they don't exist yet.
                    if (fighter.GetCondition() != "none")
                    {
                        Console.WriteLine($"{fighter.GetName()} is {fighter.GetCondition()}! He can't attack!");
                    }
                    else
                    {
                        int damage = fighter.Attack();
                        _player.TakeDamage(damage);
                    }
                }
            }
        }
        if (_player.GetHP() <= 0)
        {
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Restart the program to try again.");
        }
        else if (_boss.GetHP() <=0)
        {
            Console.WriteLine("You won! You've saved the world!");
        }
    }
}