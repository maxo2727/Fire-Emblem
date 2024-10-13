using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.SkillsFolder;

public class SkillEffectsPrinter
{
    private View _view;
    
    public SkillEffectsPrinter(View view)
    {
        _view = view;
    }

    public void PrintSkillEffectsByUnit(Unit unit)
    {
        PrintBonuses(unit);
        PrintFirstAttackBonuses(unit);
        PrintFollowUpBonuses(unit);
        PrintPenalties(unit);
        PrintFirstAttackPenalties(unit);
        PrintFollowUpPenalties(unit);
        PrintBonusNeutralization(unit);
        PrintPenaltyNeutralization(unit);
    }
    
    // Limpiarlas...?
    public void PrintBonuses(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats)
        {
            if (stat.Bonus != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}+{stat.Bonus}");
            }
        }
    }

    public void PrintFirstAttackBonuses(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats)
        {
            if (stat.FirstAttackBonus != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}+{stat.FirstAttackBonus} en su primer ataque");
            }
        }
    }

    public void PrintFollowUpBonuses(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats)
        {
            if (stat.FollowUpBonus != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}+{stat.FollowUpBonus} en su Follow-Up");
            }
        }
    }

    public void PrintPenalties(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats)
        {
            if (stat.Penalty != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}{stat.Penalty}");
            }
        }
    }

    public void PrintFirstAttackPenalties(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats)
        {
            if (stat.FirstAttackPenalty != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}{stat.FirstAttackPenalty} en su primer ataque");
            }
        }
    }
    
    public void PrintFollowUpPenalties(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats)
        {
            if (stat.FollowUpPenalty != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}{stat.FollowUpPenalty} en su Follow-Up");
            }
        }
    }

    public void PrintBonusNeutralization(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats)
        {
            if (stat.AreBonusesNeutralized)
            {
                _view.WriteLine($"Los bonus de {statName} de {unit.Name} fueron neutralizados");
            }
        }
    }
    
    public void PrintPenaltyNeutralization(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats)
        {
            if (stat.ArePenaltiesNeutralized)
            {
                _view.WriteLine($"Los penalty de {statName} de {unit.Name} fueron neutralizados");
            }
        }
    }
}