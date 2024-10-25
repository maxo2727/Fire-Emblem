using Fire_Emblem_Models;
using Fire_Emblem_Models.Exceptions;
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

    public void CheckTeamsValidity()
    {
        List<Player> players = _gameInfo.Players.GetAllPlayers();
        foreach (Player player in players)
        {
            CheckTeamSize(player);
            CheckTeamUnitRepetition(player);

            foreach (Unit unit in player.Team.GetAllUnits())
            {
                CheckSkillsSize(unit);
                CheckSkillRepetition(unit);
            }
        }
    }

    private void CheckTeamSize(Player player)
    {
        if (player.Team.IsTeamOutsideSizeRange())
        {
            throw new InvalidTeamException();
        }
    }

    private void CheckTeamUnitRepetition(Player player)
    {
        if (player.Team.AreThereAnyRepeatedUnits())
        {
            throw new InvalidTeamException();
        }
    }

    private void CheckSkillsSize(Unit unit)
    {
        if (unit.Skills.AreSkillsOutsideSizeRange())
        {
            throw new InvalidTeamException();
        }
    }

    private void CheckSkillRepetition(Unit unit)
    {
        if (unit.Skills.AreThereAnyRepeatedSkills())
        {
            throw new InvalidTeamException();
        }
    }
}