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
    }

    public string StopEnemy()
    {
        return "frozen";
    }
    public string RewindEnemy()
    {
        return "dizzy";
    }
    public float WitherEnemy(float enemyMaxHP)
    {
        float healthLoss = enemyMaxHP * (4/10);
        return healthLoss;
    }
}