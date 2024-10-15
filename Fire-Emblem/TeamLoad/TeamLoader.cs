using Fire_Emblem.PlayersFolder;
using Fire_Emblem.UnitsFolder;

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
        if (splittedUnitLine.Length > 1)
        {
            AddSkillsToUnit(splittedUnitLine[1], newUnit);
        }
        _players.PlayersDict[playerNumber].Team.AddUnit(newUnit);
    }
    
    // Debería ser Parse unit y dsp metodo agregar
    public void AddSkillsToUnit(string skillsLine, Unit newUnit)
    {
        string[] unitSkills = skillsLine.Replace("(","").Replace(")","").Split(",");
        foreach (string skill in unitSkills)
            newUnit.Skills.AddSkill(skill);
    }
}