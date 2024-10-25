using Fire_Emblem.UnitsFolder;
using Fire_Emblem_Models;
using Fire_Emblem_Models.StatsFolder;
using Fire_Emblem.SkillsFolder;

namespace Fire_Emblem.TeamLoad;

public class TeamLoader
{
    private GameInfo _gameInfo;
    private int _playerNumber;
    
    public TeamLoader(GameInfo gameInfo)
    {
        _gameInfo = gameInfo;
    }

    public void LoadTeamFromFile(string teamFile)
    {
        StreamReader reader = new StreamReader(teamFile);
        _playerNumber = 1;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (line.StartsWith("Player"))
                SetPlayerNumber(line);
            else
                ReadUnitInfoFromLine(line);
        }
        reader.Close();
    }

    private void SetPlayerNumber(string line)
    {
        _playerNumber = int.Parse(line.Split(" ")[1]);
    }
    
    private void ReadUnitInfoFromLine(string line)
    {
        string[] splittedUnitLine = line.Split(" ", 2);
        string unitName = splittedUnitLine[0];
        Unit newUnit = new Unit(unitName);
        LoadUnitInfo(newUnit);
        if (splittedUnitLine.Length > 1)
        {
            AddSkillsToUnit(splittedUnitLine[1], newUnit);
        }

        Player player = _gameInfo.Players.GetPlayerById(_playerNumber);
        player.Team.AddUnit(newUnit);
    }
    
    private void AddSkillsToUnit(string skillsLine, Unit newUnit)
    {
        string[] unitSkills = skillsLine.Replace("(","").Replace(")","").Split(",");
        foreach (string skill in unitSkills)
        {
            newUnit.Skills.AddSkill(skill);
        }
    }
    
    private void LoadUnitInfo(Unit unit)
    {
        Dictionary<string, string> unitInfo = UnitsJsonReader.GetUnitInfo(unit.Name);
        LoadUnitWeaponInfo(unit, unitInfo["Weapon"]);
        unit.Gender = unitInfo["Gender"];
        unit.DeathQuote = unitInfo["DeathQuote"];
        unit.Hp = new HP(Convert.ToInt32(unitInfo["HP"]));
        unit.Stats.GetStat("Atk").BaseStat = Convert.ToInt32(unitInfo["Atk"]);
        unit.Stats.GetStat("Spd").BaseStat = Convert.ToInt32(unitInfo["Spd"]);
        unit.Stats.GetStat("Def").BaseStat = Convert.ToInt32(unitInfo["Def"]);
        unit.Stats.GetStat("Res").BaseStat = Convert.ToInt32(unitInfo["Res"]);
    }

    private void LoadUnitWeaponInfo(Unit unit, string weapon)
    {
        unit.Weapon = new Weapon(weapon);
        unit.Weapon.Type = WeaponTypeSetter.SetWeaponType(weapon);
    }
}