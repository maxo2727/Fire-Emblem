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

    public double HealingPercentageAfterAttack;
    public bool IsCounterDenied;
    public bool IsCounterDenialAnnulled;
    
    public int HealingBeforeCombat;
    public int DamageBeforeCombat;
    public int HealingAfterCombat;
    public int DamageAfterCombat;

    public bool HasAttacked;
    public int DamageAfterCombatIfHasAttacked;
    public Companions Companions = new();
    
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
        HealingPercentageAfterAttack = 0;
        IsCounterDenied = false;
        IsCounterDenialAnnulled = false;
        HealingBeforeCombat = 0;
        DamageBeforeCombat = 0;
        HealingAfterCombat = 0;
        DamageAfterCombat = 0;
        HasAttacked = false;
        DamageAfterCombatIfHasAttacked = 0;
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
    
    public void ApplyHealingBeforeCombat()
    {
        Hp.Heal(HealingBeforeCombat);
    }
    public void TakeDamageBeforeCombat()
    {
        Hp.TakeDamageBetweenCombat(DamageBeforeCombat);
    }
    
    public void ApplyHealAfterCombat()
    {
        Hp.Heal(HealingAfterCombat);
    }
    
    public void TakeDamageAfterCombat(int damage)
    {
        Hp.TakeDamageBetweenCombat(DamageAfterCombat);
    }
    
    public bool CanDoCounter()
    {
        if (IsCounterDenied)
        {
            if (IsCounterDenialAnnulled)
            {
                return true;
            }
            return false;
        }
        return true;
    }

    public bool IsCounterDeniedAndDenialAnnulled()
    {
        return IsCounterDenied && IsCounterDenialAnnulled;
    }

    public bool IsCounterDeniedButNotDenialAnnulled()
    {
        return IsCounterDenied && !IsCounterDenialAnnulled;
    }

    public bool IsWeaponNameEqualTo(string weaponName)
    {
        return Weapon.Name == weaponName;
    }
}