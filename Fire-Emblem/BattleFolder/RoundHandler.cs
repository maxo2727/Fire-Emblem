using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.SkillsFolder;
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
        _view.ShowInitialRoundStatus(_gameInfo);
        _advantageEvaluator.CheckAdvantage();
        _skillController.UseSkills();
        _combatSequencer.CombatSequence();
        _view.ShowFinishedRoundStatus(_gameInfo);
    }

    private void SetUpUnits()
    {
        SelectUnitsForAllPlayers();
        _gameInfo.AttackingUnit.IsStartingCombat = true;
        _gameInfo.AttackingUnit.SetRivalUnit(_gameInfo.DefendingUnit);
        _gameInfo.DefendingUnit.SetRivalUnit(_gameInfo.AttackingUnit);
        UpdateUnitCombatStatus();
    }

    private void SelectUnitsForAllPlayers()
    {
        _unitSelector.SelectUnit(_gameInfo.AttackingPlayerNumber);
        _unitSelector.SelectUnit(_gameInfo.DefendingPlayerNumber);
        _gameInfo.SaveBattleUnitChoice();
    }

    public void WrapUpForNextRound()
    {
        ChangeTurns();
        UpdateFirstCombatStatusForAllunits();
        _gameInfo.IncreaseRoundNumber();
        _gameInfo.ResetUnitRoundActions();
        _gameInfo.SetMostRecentRivalForThisCombat();
    }
    
    private void ChangeTurns()
    {
        if (_gameInfo.AttackingPlayerNumber == 1)
            _gameInfo.SetPlayerTurns(2,1);
        else
            _gameInfo.SetPlayerTurns(1,2);
    }
    
    private void UpdateUnitCombatStatus()
    {
        _gameInfo.AttackingUnit.UpdateAttackingCombatStatus();
        _gameInfo.DefendingUnit.UpdateDefendingCombatStatus();
    }
    
    private void UpdateFirstCombatStatusForAllunits()
    {
        _gameInfo.AttackingUnit.UpdateFirstAttackingCombatStatus(); 
        _gameInfo.DefendingUnit.UpdateFirstDefendingCombatStatus();
    }
}