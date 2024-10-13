using Fire_Emblem_View;
using Fire_Emblem.BattleFolder;
using Fire_Emblem.TeamLoad;
using Fire_Emblem.PlayersFolder;

namespace Fire_Emblem;

public class Game
{
    private string _teamsFolder;
    private TeamFileSelector _teamFileSelector;
    private TeamLoader _teamLoader;
    private TeamValidator _teamValidator;
    private BattleHandler _battleHandler;
    
    public Game(View view, string teamsFolder)
    {
        _teamsFolder = teamsFolder;
        Players players = new Players();
        _teamFileSelector = new TeamFileSelector(view);
        _teamLoader = new TeamLoader(players);
        _teamValidator = new TeamValidator(view, players);
        _battleHandler = new BattleHandler(view, players);
    }

    public void Play()
    {
        string teamFile = _teamFileSelector.SelectTeamFile(_teamsFolder);
        _teamLoader.LoadTeamFromFile(teamFile);
        if (_teamValidator.CheckTeamsValidity())
            _battleHandler.StartBattle();
    }
}

// Dejar trainwrecks de estructuras de datos y sacar metodos
// Archivos ignorados?
// probando