﻿using Fire_Emblem_View;
using Fire_Emblem.BattleFolder;
using Fire_Emblem.TeamLoad;
using Fire_Emblem.PlayersFolder;

namespace Fire_Emblem;

public class Game
{
    private View _view;
    private string _teamsFolder;
    private TeamFileSelector _teamFileSelector;
    private TeamLoader _teamLoader;
    private TeamValidator _teamValidator;
    private BattleHandler _battleHandler;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
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
//   - Request Handler necessary?
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
//  - Boundaries
//  - Separar Modelos en Proyecto
//  - Crear GameStats

// DUDAS:
//  - Encapsulation Dictionary ta bien devolver todos los (key, value)?