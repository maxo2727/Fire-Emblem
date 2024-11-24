namespace Fire_Emblem_Models.StatsFolder;

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

    public int GetLostHP()
    {
        return _baseMaxHP + _bonusMaxHP - _currentHP;
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

    public void SetCurrentHpBetweenCombat(int value)
    {
        Console.WriteLine(value);
        if (value < 1)
            _currentHP = 1;
        else if (value > GetMaxHP())
            _currentHP = GetMaxHP();
        else
            _currentHP = value;
    }
    
    public bool IsAlive()
    {
        return _currentHP > 0;
    }
    
    public void TakeDamage(int damage)
    {
        SetCurrentHP(_currentHP - damage);
    }

    public void TakeDamageBetweenCombat(int damage)
    {
        SetCurrentHpBetweenCombat(_currentHP - damage);
    }

    public void Heal(int healBonus)
    {
        SetCurrentHP(_currentHP + healBonus);
    }
}