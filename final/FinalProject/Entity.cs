// enemy base class
public abstract class Entity
{
    // what attributes do they all have?
    private string _name;
    private int _maxHP;
    private int _HP;
    private string _condition;
    private int _conditionCounter = 0;
    private int _attackPower;


    // constructor(s)
    public Entity(string name, int maxHP, int attackPower)
    {
        _name = name;
        _maxHP = maxHP;
        _HP = maxHP;
        _attackPower = attackPower;
    }

    // getters/setters for any info that needs accessed elsewhere
    public int GetHP()
    {
        return _HP;
    }
    public void SetHP(int HPvalue)
    {
        _HP = HPvalue;
    }
    public int GetMaxHP()
    {
        return _maxHP;
    }
    public string GetName()
    {
        return _name;
    }
    public int GetAttackDamage()
    {
        return _attackPower;
    }
    public string GetCondition()
    {
        return _condition;
    }
    public void SetCondition(string effect)
    {
        _condition = effect;
    }
    public int GetConditionCounter()
    {
        return _conditionCounter;
    }
    public void SetConditionCounter(int conditionCount)
    {
        _conditionCounter = conditionCount;
    }

    // what functionality do they all need? And which ones need to be polymorphic?
    public virtual void TakeDamage(int damage)
    {
        _HP = _HP - damage;
    }
    public abstract void GainCondition(string effect, string name);
    public void CountdownCondition()
    {
        _conditionCounter -= 1;
        if (_conditionCounter == 0)
        {
            Console.WriteLine($"{_name} is no longer {_condition}.");
        }
    }
    // how is attack vs defense going to work? dice roll just in fight maybe? unless I want
    // enemies to have lower odds of success than players. But I guess I could just make multiple "dice" in there?
}