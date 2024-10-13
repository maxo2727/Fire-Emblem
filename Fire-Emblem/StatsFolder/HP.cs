namespace Fire_Emblem.StatsFolder;

public class HP
{
    private int _baseMaxHP;
    private int _currentHP;
    private int _bonusMaxHP = 0;
    private bool HasRecievedInitialHPBonus = false;

    public HP(int baseMaxHp)
    {
        _baseMaxHP = baseMaxHp;
        _currentHP = _baseMaxHP;
    }
    
    public int GetCurrentHP()
    {
        return _currentHP;
    }

    public int GetMaxHP()
    {
        return _baseMaxHP + _bonusMaxHP;
    }
    
    //properties
    public void SetCurrentHP(int value)
    {
        if (value < 0)
            _currentHP = 0;
        else if (value > GetMaxHP())
            _currentHP = GetMaxHP();
        else
            _currentHP = value;
    }

    public void AddBonusMaxHP(int bonus)
    {
        if (!HasRecievedInitialHPBonus)
        {
            _bonusMaxHP = bonus;
        }
    }

    public void SetMaxHPForCombat()
    {
        if (!HasRecievedInitialHPBonus)
        {
            SetCurrentHP(GetMaxHP());
            HasRecievedInitialHPBonus = true;
        }
    }
    
    public bool IsAlive()
    {
        return _currentHP > 0;
    }
    
    public void TakeDamage(int damage)
    {
        SetCurrentHP(_currentHP - damage);
    }
}