using Fire_Emblem.UnitsFolder;
using Fire_Emblem_Models;
using Fire_Emblem_Models.StatsFolder;
using Fire_Emblem.SkillsFolder;

namespace Fire_Emblem.TeamLoad;

public class TeamLoader
{
    private Players _players;
    
    public TeamLoader(Players players)
    {
        _players = players;
    }

    public void LoadTeamFromFile(string teamFile)
    {
        StreamReader reader = new StreamReader(teamFile);
        int playerNumber = 1;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (line.StartsWith("Player"))
                playerNumber = int.Parse(line.Split(" ")[1]);
            else
                ReadUnitInfoFromLine(line, playerNumber);
        }
        reader.Close();
    }

    public void ReadUnitInfoFromLine(string line, int playerNumber)
    {
        string[] splittedUnitLine = line.Split(" ", 2);
        string unitName = splittedUnitLine[0];
        Unit newUnit = new Unit(unitName);
        LoadUnitInfo(newUnit);
        if (splittedUnitLine.Length > 1)
        {
            AddSkillsToUnit(splittedUnitLine[1], newUnit);
        }
        _players.PlayersDict[playerNumber].Team.AddUnit(newUnit);
    }
    
    // Debería ser Parse unit y dsp metodo agregar... LIMPIAR
    public void AddSkillsToUnit(string skillsLine, Unit newUnit)
    {
        string[] unitSkills = skillsLine.Replace("(","").Replace(")","").Split(",");
        foreach (string skillName in unitSkills)
        {
            Skill skill = SkillFactory.CreateSkill(skillName);
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