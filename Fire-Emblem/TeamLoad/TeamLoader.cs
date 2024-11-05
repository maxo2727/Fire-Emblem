using Fire_Emblem.UnitsFolder;
using Fire_Emblem_Models;
using Fire_Emblem_Models.StatsFolder;
using Fire_Emblem.SkillsFolder;

namespace Fire_Emblem.TeamLoad;

public class TeamLoader
{
    private GameInfo _gameInfo;
    private int _playerNumber;
    private UnitLoader _unitLoader = new UnitLoader();
    
    public TeamLoader(GameInfo gameInfo)
    {
        _gameInfo = gameInfo;
    }

    public void LoadTeamFromFile(string teamFile)
    {
        StreamReader reader = new StreamReader(teamFile);
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
        Unit newUnit = _unitLoader.LoadUnit(unitName);
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
}