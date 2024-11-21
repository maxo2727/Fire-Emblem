using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models;

public class Unit
{
    public string Name;
    public string Gender;
    public string DeathQuote;
    
    public Weapon Weapon;
    public HP Hp;
    public Stats Stats = new Stats();
    public Skills Skills = new Skills();
    
    public Unit Rival;
    public Unit MostRecentRival = null; 
    public bool IsStartingCombat = false;
    public bool HasMadeFirstAttack = false;
    public bool InFollowUp = false;
    public bool IsAttacking = false;
    public bool IsDefending = false;
    public bool IsFirstAttackingCombat = true;
    public bool IsFirstDefendingCombat = true;
    
    public DamageEffects DamageEffects = new DamageEffects();

    public double HealPercentage;
        
    public Unit(string name)
    {
        Name = name;
    }
    
    public void ResetRoundActions()
    {
        IsStartingCombat = false;
        HasMadeFirstAttack = false;
        InFollowUp = false;
        Stats.ClearEffectsForEveryStat();
        DamageEffects.ResetDamageEffects();
    }
    
    public void TakeDamage(int damage)
    {
        Hp.TakeDamage(damage);
    }

    public int GetCurrentHP()
    {
        return Hp.GetCurrentHP();
    }

    public bool IsAlive()
    {
        return Hp.IsAlive();
    }
    
    public Unit GetRivalUnit()
    {
        return Rival;
    }
    
    public void SetRivalUnit(Unit rival)
    {
        Rival = rival;
    }
    
    public Unit GetMostRecentRival()
    {
        return MostRecentRival;
    }
    
    public void SetMostRecentRival(Unit rival)
    {
        MostRecentRival = rival;
    }

    public void UpdateAttackingCombatStatus()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
            IsDefending = false;
        }
    }
    
    public void UpdateDefendingCombatStatus()
    {
        if (!IsDefending)
        {
            IsAttacking = false;
            IsDefending = true;
        }
    }

    public void UpdateFirstAttackingCombatStatus()
    {
        if (IsFirstAttackingCombat)
        {
            IsFirstAttackingCombat = false;
        }
    }
    
    public void UpdateFirstDefendingCombatStatus()
    {
        if (IsFirstDefendingCombat)
        {
            IsFirstDefendingCombat = false;
        }
    }

    //UnitController
    public int HealAfterAttack(int damage)
    {
        int healBonus = (int)(damage * HealPercentage);
        Hp.Heal(healBonus);
        return healBonus;
    }
}
    
    
    
    