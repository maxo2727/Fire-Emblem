using Fire_Emblem_Models;
using Fire_Emblem_Models.Exceptions;
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
    private FireEmblemView _view;
    
    public Game(FireEmblemView view, string teamsFolder)
    {
        _view = view;
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
        try
        {
            string teamFile = _teamFileSelector.SelectTeamFileNuevo(_teamsFolder);
            _teamLoader.LoadTeamFromFile(teamFile);
            _teamValidator.CheckTeamsValidity();
            _battleHandler.StartBattle();
        }
        catch (TeamException e)
        {
            _view.PrintExceptionMessage(e.Message);
        }
        
    }
}

// TODO
//  - Limpiar mejor Battle/Round/Combat handlers para utilizar GameInfo y no guardar como atributos a units
//  - Effects and Conditions: Decorate With RivalCondition() and FirstAttack(), FollowUp(), Percentage()?
//  - DamageHandler y DamageEffects
//  - Clases en FireEmblemView?
//  - Separar HP en Handler e Info (objeto y EDD).
//  - GameInfo que guarde followUpUnits?
//  - Tener un HealingManager y un OutsideCombatDamageManager?

// PARA CHEQUEAR:
//  - ta bien unitStatManager? o dividirlo en mas clases