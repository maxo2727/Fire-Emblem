using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.SkillsFolder;

public class SkillEffectsPrinter
{
    private FireEmblemView _view;
    
    public SkillEffectsPrinter(FireEmblemView view)
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
        PrintBaseDamageBonus(unit);
        PrintFirstAttackDamageBonus(unit);
        PrintFollowUpDamageBonus(unit);
        PrintBaseDamagePercentageReductionToRival(unit);
        PrintFirstAttackDamagePercentageReductionToRival(unit);
        PrintFollowUpDamagePercentageReductionToRival(unit);
        PrintBaseDamageReduction(unit);
    }
    
    // Limpiarlas...?
    public void PrintBonuses(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats.GetAllStats())
        {
            if (stat.Bonus != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}+{stat.Bonus}");
            }
        }
    }

    public void PrintFirstAttackBonuses(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats.GetAllStats())
        {
            if (stat.FirstAttackBonus != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}+{stat.FirstAttackBonus} en su primer ataque");
            }
        }
    }

    public void PrintFollowUpBonuses(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats.GetAllStats())
        {
            if (stat.FollowUpBonus != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}+{stat.FollowUpBonus} en su Follow-Up");
            }
        }
    }

    public void PrintPenalties(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats.GetAllStats())
        {
            if (stat.Penalty != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}{stat.Penalty}");
            }
        }
    }

    public void PrintFirstAttackPenalties(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats.GetAllStats())
        {
            if (stat.FirstAttackPenalty != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}{stat.FirstAttackPenalty} en su primer ataque");
            }
        }
    }
    
    public void PrintFollowUpPenalties(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats.GetAllStats())
        {
            if (stat.FollowUpPenalty != 0)
            {
                _view.WriteLine($"{unit.Name} obtiene {statName}{stat.FollowUpPenalty} en su Follow-Up");
            }
        }
    }

    public void PrintBonusNeutralization(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats.GetAllStats())
        {
            if (stat.AreBonusesNeutralized)
            {
                _view.WriteLine($"Los bonus de {statName} de {unit.Name} fueron neutralizados");
            }
        }
    }
    
    public void PrintPenaltyNeutralization(Unit unit)
    {
        foreach (var (statName, stat) in unit.Stats.GetAllStats())
        {
            if (stat.ArePenaltiesNeutralized)
            {
                _view.WriteLine($"Los penalty de {statName} de {unit.Name} fueron neutralizados");
            }
        }
    }

    public void PrintBaseDamageBonus(Unit unit)
    {
        if (unit.DamageEffects.BaseDamageBonus > 0)
        {
            _view.WriteLine($"{unit.Name} realizará +{unit.DamageEffects.BaseDamageBonus} daño extra en cada ataque");
        }
    }

    public void PrintFirstAttackDamageBonus(Unit unit)
    {
        if (unit.DamageEffects.FirstAttackDamageBonus > 0)
        {
            _view.WriteLine($"{unit.Name} realizará +{unit.DamageEffects.FirstAttackDamageBonus} daño extra en su primer ataque");
        }
    }

    public void PrintFollowUpDamageBonus(Unit unit)
    {
        if (unit.DamageEffects.FollowUpDamageBonus > 0)
        {
            _view.WriteLine($"{unit.Name} realizará +{unit.DamageEffects.FollowUpDamageBonus} daño extra en su Follow-Up");
        }
    }

    public void PrintBaseDamagePercentageReductionToRival(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        if (rival.DamageEffects.BasePercentageDamageReduction > 0)
        {
            _view.WriteLine($"{unit.Name} reducirá el daño de los ataques del rival en un {Math.Round(rival.DamageEffects.BasePercentageDamageReduction * 100)}%");
        }
    }

    public void PrintFirstAttackDamagePercentageReductionToRival(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        if (rival.DamageEffects.FirstAttackPercentageDamageReduction > 0)
        {
            _view.WriteLine($"{unit.Name} reducirá el daño del primer ataque del rival en un {Math.Round(rival.DamageEffects.FirstAttackPercentageDamageReduction * 100)}%");
        }
    }
    
    public void PrintFollowUpDamagePercentageReductionToRival(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        if (rival.DamageEffects.FollowUpPercentageDamageReduction > 0)
        {
            _view.WriteLine($"{unit.Name} reducirá el daño del Follow-Up del rival en un {Math.Round(rival.DamageEffects.FollowUpPercentageDamageReduction * 100)}%");
        }
    }

    public void PrintBaseDamageReduction(Unit unit)
    {
        if (unit.DamageEffects.BaseDamageReduction > 0)
        {
            _view.WriteLine($"{unit.Name} recibirá -{unit.DamageEffects.BaseDamageReduction} daño en cada ataque");
        }
    }
}