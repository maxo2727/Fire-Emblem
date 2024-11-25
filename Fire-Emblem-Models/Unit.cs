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
    
    public int DamageAfterCombatIfHasAttacked;
    public Companions Companions = new();
    
    public bool IsAlive = true;
    
    
    public Unit(string name)
    {
        Name = name;
    }
}