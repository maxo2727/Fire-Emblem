using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.SkillsFolder;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.TeamLoad;

public class TeamValidator
{
    private FireEmblemView _view;
    private GameInfo _gameInfo;

    public TeamValidator(FireEmblemView view, GameInfo gameInfo)
    {
        _gameInfo = gameInfo;
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
        List<Player> players = _gameInfo.Players.GetAllPlayers();
        foreach (Player player in players)
        {
            if (player.Team.IsTeamOutsideSizeRange() || player.Team.AreThereAnyRepeatedUnits())
                return false;
            foreach (Unit unit in player.Team.GetAllUnits())
            {
                if (unit.Skills.AreSkillsOutsideSizeRange() || unit.Skills.AreThereAnyRepeatedSkills())
                    return false;
            }
        }
        return true;
    }
}