using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class RoundHandler
{
    private FireEmblemView _view;
    private GameInfo _gameInfo;
    private UnitSelector _unitSelector;
    private CombatSequencer _combatSequencer;
    private SkillController _skillController;
    private AdvantageEvaluator _advantageEvaluator;
    

    public RoundHandler(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
        _unitSelector = new UnitSelector(_gameInfo, view);
        _combatSequencer = new CombatSequencer(view, _gameInfo);
        _skillController = new SkillController(_view, _gameInfo);
        _advantageEvaluator = new AdvantageEvaluator(_view, _gameInfo);
    }
    
    public void BeginNewRound()
    {
        SetUpUnits();
        UpdateUnitCombatStatus();
        _advantageEvaluator.CheckAdvantage();
        _skillController.UseSkills();
        _combatSequencer.CombatSequence();
        _view.WriteLine($"{_gameInfo.AttackingUnit.Name} ({_gameInfo.AttackingUnit.GetCurrentHP()}) : {_gameInfo.DefendingUnit.Name} ({_gameInfo.DefendingUnit.GetCurrentHP()})");
    }
    
    //LIMPIAR!! Dividir en funciones mas chicas q seteen otras cosas
    public void SetUpUnits()
    {
        _unitSelector.SelectUnitsForAllPlayers();
        _gameInfo.AttackingUnit.IsStartingCombat = true;
        _gameInfo.AttackingUnit.SetRivalUnit(_gameInfo.DefendingUnit);
        _gameInfo.DefendingUnit.SetRivalUnit(_gameInfo.AttackingUnit);
        _view.WriteLine($"Round {_gameInfo.RoundTurn}: {_gameInfo.AttackingUnit.Name} (Player {_gameInfo.AttackingPlayerNumber}) comienza");
    }

    public void WrapUpForNextRound()
    {
        ChangeTurns();
        UpdateFirstCombatStatusForAllunits();
        _gameInfo.IncreaseRoundNumber();
        _gameInfo.ResetUnitRoundActions();
        _gameInfo.SetMostRecentRivalForThisCombat();
    }
    
    // metodos de GameInfo??
    public void ChangeTurns()
    {
        if (_gameInfo.AttackingPlayerNumber == 1)
            _gameInfo.SetPlayerTurns(2,1);
        else
            _gameInfo.SetPlayerTurns(1,2);
    }

    // gameInfo??
    public void UpdateUnitCombatStatus()
    {
        _gameInfo.AttackingUnit.UpdateAttackingCombatStatus();
        _gameInfo.DefendingUnit.UpdateDefendingCombatStatus();
    }
    
    public void UpdateFirstCombatStatusForAllunits()
    {
        _gameInfo.AttackingUnit.UpdateFirstAttackingCombatStatus(); 
        _gameInfo.DefendingUnit.UpdateFirstDefendingCombatStatus();
    }
}