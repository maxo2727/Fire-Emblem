using Fire_Emblem.SkillsFolder;
using Fire_Emblem.StatsFolder;

namespace Fire_Emblem.UnitsFolder;

public class Unit
{
    public string Name;
    public Weapon Weapon;
    public string Gender;
    public string DeathQuote;
    public HP Hp;
    // Class Stats Boundries
    public Dictionary<string, Stat> Stats = new Dictionary<string, Stat>()
    {
        { "Atk", new Attack() },
        { "Spd", new Speed() },
        { "Def", new Defense() },
        { "Res", new Resistence() }
    };
    public Skills Skills = new Skills();
    private Unit _rival;
    private Unit _mostRecentRival = null;
    public bool IsStartingCombat = false;
    public bool HasMadeFirstAttack = false;
    public bool InFollowUp = false;

    public Unit(string name)
    {
        Name = name;
        LoadUnitInfo();
    }

    private void LoadUnitInfo()
    {
        Dictionary<string, string> unitInfo = UnitsJsonReader.GetUnitInfo(Name);
        Weapon = new Weapon(unitInfo["Weapon"]);
        Gender = unitInfo["Gender"];
        DeathQuote = unitInfo["DeathQuote"];
        Hp = new HP(Convert.ToInt32(unitInfo["HP"]));
        Stats["Atk"].BaseStat = Convert.ToInt32(unitInfo["Atk"]);
        Stats["Spd"].BaseStat = Convert.ToInt32(unitInfo["Spd"]);
        Stats["Def"].BaseStat = Convert.ToInt32(unitInfo["Def"]);
        Stats["Res"].BaseStat = Convert.ToInt32(unitInfo["Res"]);
    }
    
    public void ResetRoundActions()
    {
        IsStartingCombat = false;
        HasMadeFirstAttack = false;
        InFollowUp = false;
        ClearEffectsForEveryStat();
    }
    
    public void ClearEffectsForEveryStat()
    {
        foreach (Stat stat in Stats.Values)
        {
            stat.ClearStatEffects();
        }
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
    
    // método de weapon
    public string GetDefenseFromWeaponType(Weapon attackingUnitWeapon)
    {
        return WeaponDefenseGetter.GetDefenseFromWeaponType(attackingUnitWeapon);
    }

    // necesario...? Lo dejaría público noma...
    // PERO, otras funciones no deben saber las entrañas de unit, mejor dejarlo como metodo?
    public Unit GetRivalUnit()
    {
        return _rival;
    }
    
    //necesario...?
    public void SetRivalUnit(Unit rival)
    {
        _rival = rival;
    }
    
    //necesario...?
    public Unit GetMostRecentRival()
    {
        return _mostRecentRival;
    }
    
    //necesario...?
    public void SetMostRecentRival(Unit rival)
    {
        _mostRecentRival = rival;
    }
    
    // Como es estructura de datos, no son necesarias estas funciones
    public void ModifyBonuses(string stat, int bonus)
    {
        Stats[stat].Bonus += bonus;
    }
    
    public void ModifyPenalties(string stat, int penalty)
    {
        Stats[stat].Penalty += penalty;
    }
    
    public void ModifyFirstAttackBonuses(string stat, int bonus)
    {
        Stats[stat].FirstAttackBonus += bonus;
    }
    
    public void ModifyFirstAttackPenalties(string stat, int penalty)
    {
        Stats[stat].FirstAttackPenalty += penalty;   
    }

    public void ModifyFollowUpBonuses(string stat, int bonus)
    {
        Stats[stat].FollowUpBonus += bonus;
    }
    
    public void ModifyFollowUpPenalties(string stat, int penalty)
    {
        Stats[stat].FollowUpPenalty += penalty;
    }
    
    public void ModifyRivalBonuses(string stat, int bonus)
    {
        _rival.ModifyBonuses(stat, bonus);
    }
    
    public void ModifyRivalPenalties(string stat, int penalty)
    {
        _rival.ModifyPenalties(stat, penalty);
    }

    public void ModifyRivalFirstAttackBonuses(string stat, int penalty)
    {
        _rival.ModifyFirstAttackBonuses(stat, penalty);
    }
    public void ModifyRivalFirstAttackPenalties(string stat, int penalty)
    {
        _rival.ModifyFirstAttackPenalties(stat, penalty);
    }
}
    
    
    
    