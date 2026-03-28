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
        while (_player.GetHP() > 0 && _boss.GetHP() >0)
        {
            foreach (Entity fighter in _fightParticipants)
            {
                if (fighter.GetName() == "Player")
                {
                    // go through each character. Check conditions first. Print menus with descriptions as needed.
                    // 
                }
                else if (fighter.GetName() == "Baron Wight")
                {
                    // I only needed to separate boss from other bad guys because he has more functionality
                    // to pick between different attacks, in a future design I might have another inherited generation for bad guy
                }
                else
                {
                    
                }
            }
        }
    }
}