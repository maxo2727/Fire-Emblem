using Fire_Emblem_Models;
using Fire_Emblem_Models.StatsFolder;

namespace Fire_Emblem.UnitsFolder;

public class UnitLoader
{
    private Unit _newUnit;
    private Dictionary<string, string> _unitInfo;

    public Unit LoadUnit(string name)
    {
        _newUnit = new Unit(name);
        GetUnitInfo(name);
        LoadGender();
        LoadDeathQuote();
        LoadHP();
        LoadStats();
        LoadWeapon();
        return _newUnit;
    }

    private void GetUnitInfo(string name)
    {
        _unitInfo = UnitsJsonReader.GetUnitInfo(name);
    }

    private void LoadGender()
    {
        _newUnit.Gender = _unitInfo["Gender"];
    }

    private void LoadDeathQuote()
    {
        _newUnit.DeathQuote = _unitInfo["DeathQuote"];
    }

    private void LoadHP()
    {
        _newUnit.Hp = new HP(Convert.ToInt32(_unitInfo["HP"]));
    }

    private void LoadStats()
    {
        _newUnit.Stats.GetStat("Atk").BaseStat = Convert.ToInt32(_unitInfo["Atk"]);
        _newUnit.Stats.GetStat("Spd").BaseStat = Convert.ToInt32(_unitInfo["Spd"]);
        _newUnit.Stats.GetStat("Def").BaseStat = Convert.ToInt32(_unitInfo["Def"]);
        _newUnit.Stats.GetStat("Res").BaseStat = Convert.ToInt32(_unitInfo["Res"]);
    }

    private void LoadWeapon()
    {
        string weapon = _unitInfo["Weapon"];
        _newUnit.Weapon = new Weapon(weapon);
        _newUnit.Weapon.Type = WeaponTypeSetter.SetWeaponType(weapon);
    }
}