using Fire_Emblem_Models;

namespace Fire_Emblem_View;

public class FireEmblemView
{
    private readonly View _view;
    private SkillEffectsPrinter _skillEffectsPrinter;

    public FireEmblemView(View view)
    {
        _view = view;
        _skillEffectsPrinter = new SkillEffectsPrinter(_view);
    }

    public SkillEffectsPrinter GetSkillEffectsPrinter()
    {
        return _skillEffectsPrinter;
    }

    public void PrintExceptionMessage(string message)
    {
        _view.WriteLine(message);
    }
    
    public void ShowArrayOfTeams(string[] teamFiles)
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        for (int i = 0; i < teamFiles.Length; i++)
        {
            string teamFile = teamFiles[i];
            _view.WriteLine($"{i}: {teamFile}");
        }
    }

    public void ShowListOfUnits(int playerNumber, List<Unit> units)
    {
        _view.WriteLine($"Player {playerNumber} selecciona una opción");
        for (int i = 0; i < units.Count(); i++)
        {
            Unit unit = units[i];
            _view.WriteLine($"{i}: {unit.Name}");
        }
    }

    public string GetOptionNumber()
    {
        return _view.ReadLine();
    }

    public void ShowWinner(int winner)
    {
        _view.WriteLine($"Player {winner} ganó");
    }

    public void PrintCombatEvent(string attacker, string defender, int damage)
    {
        _view.WriteLine($"{attacker} ataca a {defender} con {damage} de daño");
    }
    
    public void PrintNoFollowUp()
    {
        _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }

    public void PrintNoAdvantage()
    {
        _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
    }

    public void PrintAdvantage(Unit unitWithAdvantage, Unit unitWithDisadvantage)
    {
        _view.WriteLine($"{unitWithAdvantage.Name} ({unitWithAdvantage.Weapon.Name}) tiene ventaja con respecto a {unitWithDisadvantage.Name} ({unitWithDisadvantage.Weapon.Name})");
    }
    
    public void ShowInitialRoundStatus(GameInfo gameInfo)
    {
        _view.WriteLine($"Round {gameInfo.RoundTurn}: {gameInfo.AttackingUnit.Name} (Player {gameInfo.AttackingPlayerNumber}) comienza");
    }

    public void ShowFinishedRoundStatus(GameInfo gameInfo)
    {
        _view.WriteLine($"{gameInfo.AttackingUnit.Name} ({gameInfo.AttackingUnit.GetCurrentHP()}) : {gameInfo.DefendingUnit.Name} ({gameInfo.DefendingUnit.GetCurrentHP()})");
    }
}