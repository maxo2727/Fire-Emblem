using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.BattleFolder;
using Fire_Emblem.TeamLoad;

namespace Fire_Emblem;

public class Game
{
    private string _teamsFolder;
    private TeamFileSelector _teamFileSelector;
    private TeamLoader _teamLoader;
    private TeamValidator _teamValidator;
    private BattleHandler _battleHandler;
    
    public Game(FireEmblemView view, string teamsFolder)
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
        // string teamFile = _teamFileSelector.SelectTeamFileNuevo(_teamsFolder);
        string[] teams = _teamFileSelector.GetAvailableTeamsInOrder(_teamsFolder);
        string teamFile = _teamFileSelector.SelectTeamFile(_teamsFolder);
        _teamLoader.LoadTeamFromFile(teamFile);
        if (_teamValidator.CheckTeamsValidity())
            _battleHandler.StartBattle();
    }
}

// TODO:
// - Select and Verify Team with MVC
//   - Get Input in View?
//   - Response View no inheritance?
//   - Try Catch in Happy Path and Throw Exceptions
//
// - GameStats
//   - Store Players, roundNumber, bools, etc
//
// View usa Modelos, Controlador usa view y modelos!!!!!
// GameStat: clase editable que guarda info, quizas limpieza

// Prioridad:
//  - Crear GameStats

// DUDAS:
//  - Encapsulation Dictionary ta bien devolver todos los (key, value)?
//    R: NO!! Solo debería devolver los values.