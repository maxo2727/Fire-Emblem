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
        string teamFile = _teamFileSelector.SelectTeamFileNuevo(_teamsFolder);
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
// Unit y Skills Builder

// DUDAS:
//  - Encapsulation Dictionary ta bien devolver todos los (key, value)?
//    R: NO!! Solo debería devolver los values.
//  - Como usar TrueTruncator?
//  - Como componer y decorar condiciones con otras similares? QUIZAS, PARA CADA TIPO DE ATAQUE, PASARLE EL UNIT.BONUS.FIRSTATTACK, Y DE AHI DARLE EL BONUS??

// Cosas a Limpiar
//  - Funciones Show de vista
//  - Flujo cargar equipo
//  - GameInfo con Battle/Round/Combat, guardar units?
//  - Try/Catch en Validation
//  - Responses
//  - Effects and Conditions: Decorate With RivalCondition() and FirstAttack(), FollowUp()
//  - Sign in Penalties to Always positive, and then substract it.
//  - DamageHandler y DamageEffects