using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem_Models;

public class Unit
{
    public string Name;
    public Weapon Weapon;
    public string Gender;
    public string DeathQuote;
    public HP Hp;
    public Stats Stats = new Stats();
    public Skills Skills = new Skills();
    private Unit _rival;
    private Unit _mostRecentRival = null;
    public bool IsStartingCombat = false;
    public bool HasMadeFirstAttack = false;
    public bool InFollowUp = false;

    public Unit(string name)
    {
        Name = name;
        // LoadUnitInfo();
    }

    // private void LoadUnitInfo()
    // {
    //     Dictionary<string, string> unitInfo = UnitsJsonReader.GetUnitInfo(Name);
    //     Weapon = new Weapon(unitInfo["Weapon"]);
    //     Gender = unitInfo["Gender"];
    //     DeathQuote = unitInfo["DeathQuote"];
    //     Hp = new HP(Convert.ToInt32(unitInfo["HP"]));
    //     Stats.GetStat("Atk").BaseStat = Convert.ToInt32(unitInfo["Atk"]);
    //     Stats.GetStat("Spd").BaseStat = Convert.ToInt32(unitInfo["Spd"]);
    //     Stats.GetStat("Def").BaseStat = Convert.ToInt32(unitInfo["Def"]);
    //     Stats.GetStat("Res").BaseStat = Convert.ToInt32(unitInfo["Res"]);
    // }
    
    public void ResetRoundActions()
    {
        IsStartingCombat = false;
        HasMadeFirstAttack = false;
        InFollowUp = false;
        Stats.ClearEffectsForEveryStat();
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
}
    
    
    
    