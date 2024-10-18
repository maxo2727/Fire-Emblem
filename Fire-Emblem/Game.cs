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
        GameInfo gameInfo = new GameInfo(players);
        _teamFileSelector = new TeamFileSelector(view);
        _teamLoader = new TeamLoader(gameInfo);
        _teamValidator = new TeamValidator(view, gameInfo);
        _battleHandler = new BattleHandler(view, gameInfo);
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
// Efectos de Daño:
//  - Guardar todos los daños extra en cada atributo distinto de Unit? Quizas dsp encapsular
//  - Entonces, no es necesario chequear cuando se aplica el efecto, porque se reinicia el daño extra cada ronda...
//  
// Prioridad Efectos:
//    1.- Efectos a Stats
//    2.- Daño Extra
//    3.- Reducción Daño porcentual (combinación multiplicativa)
//    4.- Reducción Daño Absoluto
// Unit y Skills Builder

// DUDAS:
//  - Encapsulation Dictionary ta bien devolver todos los (key, value)?
//    R: NO!! Solo debería devolver los values.