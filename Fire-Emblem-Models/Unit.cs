using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models;

public class Unit
{
    // Basic Info
    public string Name;
    public string Gender;
    public string DeathQuote;
    public bool IsAlive = true;
    
    // Unit Combat data
    public HP Hp;
    public Stats Stats = new Stats();
    public Skills Skills = new Skills();
    public Weapon Weapon;
    public DamageEffects DamageEffects = new DamageEffects();
    
    // Unit Relationships
    public Unit Rival;
    public Unit MostRecentRival = null;
    public Companions Companions = new();
    
    // Unit Combat State
    public bool IsStartingCombat = false;
    public bool HasMadeFirstAttack = false;
    public bool InFollowUp = false;
    public bool IsAttacking = false;
    public bool IsDefending = false;
    public bool IsFirstAttackingCombat = true;
    public bool IsFirstDefendingCombat = true;
    public bool IsCounterDenied;
    public bool IsCounterDenialAnnulled;
    public int HealingBeforeCombat;
    public int DamageBeforeCombat;
    public int HealingAfterCombat;
    public int DamageAfterCombat;
    public int DamageAfterCombatIfHasAttacked;
    public double HealingPercentageAfterAttack;

    public int NumberOfGuaranteedFollowUps;
    public int NumberOfDeniedFollowUps;
    public bool IsFollowUpGuaranteeAnnulled;
    public bool IsFollowUpDenialAnnulled;
    public bool CanDoFollowUp;
    
    
    public Unit(string name)
    {
        Name = name;
    }
}