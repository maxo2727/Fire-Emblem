using Fire_Emblem_View;
using Fire_Emblem.PlayersFolder;
using Fire_Emblem.SkillsFolder;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.TeamLoad;

public class TeamValidator
{
    private View _view;
    private Players _players;

    public TeamValidator(View view, Players players)
    {
        _players = players;
        _view = view;
    }

    public bool CheckTeamsValidity()
    {
        if (AreTeamsValid())
        {
            return true;
        }
        else
        {
            _view.WriteLine("Archivo de equipos no válido");
            return false;
        }
    }

    public bool AreTeamsValid()
    {
        // usar try catch
        // ojo con mucho codigo dentro del if
        foreach (Player player in _players.PlayersDict.Values)
        {
            if (IsTeamOutsideSizeRange(player.Team) || AreThereAnyRepeatedUnits(player.Team))
                return false;
            foreach (Unit unit in player.Team)
            {
                if (unit.Skills.AreSkillsOutsideSizeRange() || unit.Skills.AreThereAnyRepeatedSkills())
                    return false;
            }
        }
        return true;
    }

    public bool IsTeamOutsideSizeRange(List<Unit> team)
    {
        int teamLength = team.Count;
        return teamLength < 1 || 3 < teamLength;
    }

    public bool AreThereAnyRepeatedUnits(List<Unit> team)
    {
        HashSet<string> uniqueUnitNames = new HashSet<string>();
        foreach (Unit unit in team)
        {
            if (!uniqueUnitNames.Add(unit.Name))
                return true;
        }
        return false;
    }
    
    // public bool AreSkillsOutsideSizeRange(List<Skill> skills)
    // {
    //     int skillsCount = skills.Count;
    //     return 2 < skillsCount;
    // }
    //
    // public bool AreThereAnyRepeatedSkills(List<Skill> skills)
    // {
    //     HashSet<string> uniqueSkillNames = new HashSet<string>();
    //     foreach (Skill skill in skills)
    //     {
    //         if (!uniqueSkillNames.Add(skill.Name))
    //             return true;
    //     }
    //     return false;
    // }
}