using Fire_Emblem_Models;

namespace Fire_Emblem_View;

public class SkillEffectsPrinter
{
    private View _view;
    private Unit _unit;
    
    public SkillEffectsPrinter(View view)
    {
        _view = view;
    }

    public void PrintSkillEffectsByUnit(Unit unit)
    {
        // SEPARAR ESTO XDD
        _unit = unit;
        PrintBonuses();
        PrintFirstAttackBonuses();
        PrintFollowUpBonuses();
        PrintPenalties();
        PrintFirstAttackPenalties();
        PrintFollowUpPenalties();
        PrintBonusNeutralization();
        PrintPenaltyNeutralization();
        PrintBaseDamageBonus();
        PrintFirstAttackDamageBonus();
        PrintFollowUpDamageBonus();
        PrintBaseDamagePercentageReductionToRival();
        PrintFirstAttackDamagePercentageReductionToRival();
        PrintFollowUpDamagePercentageReductionToRival();
        PrintBaseDamageReduction();
        PrintHealBonusAfterAttacks();
    }
    
    public void PrintBonuses()
    {
        foreach (var (statName, stat) in _unit.Stats.GetAllStats())
        {
            if (stat.Bonus != 0)
            {
                _view.WriteLine($"{_unit.Name} obtiene {statName}+{stat.Bonus}");
            }
        }
    }

    public void PrintFirstAttackBonuses()
    {
        foreach (var (statName, stat) in _unit.Stats.GetAllStats())
        {
            if (stat.FirstAttackBonus != 0)
            {
                _view.WriteLine($"{_unit.Name} obtiene {statName}+{stat.FirstAttackBonus} en su primer ataque");
            }
        }
    }

    public void PrintFollowUpBonuses()
    {
        foreach (var (statName, stat) in _unit.Stats.GetAllStats())
        {
            if (stat.FollowUpBonus != 0)
            {
                _view.WriteLine($"{_unit.Name} obtiene {statName}+{stat.FollowUpBonus} en su Follow-Up");
            }
        }
    }

    public void PrintPenalties()
    {
        foreach (var (statName, stat) in _unit.Stats.GetAllStats())
        {
            if (stat.Penalty != 0)
            {
                _view.WriteLine($"{_unit.Name} obtiene {statName}{stat.Penalty}");
            }
        }
    }

    public void PrintFirstAttackPenalties()
    {
        foreach (var (statName, stat) in _unit.Stats.GetAllStats())
        {
            if (stat.FirstAttackPenalty != 0)
            {
                _view.WriteLine($"{_unit.Name} obtiene {statName}{stat.FirstAttackPenalty} en su primer ataque");
            }
        }
    }
    
    public void PrintFollowUpPenalties()
    {
        foreach (var (statName, stat) in _unit.Stats.GetAllStats())
        {
            if (stat.FollowUpPenalty != 0)
            {
                _view.WriteLine($"{_unit.Name} obtiene {statName}{stat.FollowUpPenalty} en su Follow-Up");
            }
        }
    }

    public void PrintBonusNeutralization()
    {
        foreach (var (statName, stat) in _unit.Stats.GetAllStats())
        {
            if (stat.AreBonusesNeutralized)
            {
                _view.WriteLine($"Los bonus de {statName} de {_unit.Name} fueron neutralizados");
            }
        }
    }
    
    public void PrintPenaltyNeutralization()
    {
        foreach (var (statName, stat) in _unit.Stats.GetAllStats())
        {
            if (stat.ArePenaltiesNeutralized)
            {
                _view.WriteLine($"Los penalty de {statName} de {_unit.Name} fueron neutralizados");
            }
        }
    }

    public void PrintBaseDamageBonus()
    {
        if (_unit.DamageEffects.BaseDamageBonus > 0)
        {
            _view.WriteLine($"{_unit.Name} realizará +{_unit.DamageEffects.BaseDamageBonus} daño extra en cada ataque");
        }
    }

    public void PrintFirstAttackDamageBonus()
    {
        if (_unit.DamageEffects.FirstAttackDamageBonus > 0)
        {
            _view.WriteLine($"{_unit.Name} realizará +{_unit.DamageEffects.FirstAttackDamageBonus} daño extra en su primer ataque");
        }
    }

    public void PrintFollowUpDamageBonus()
    {
        if (_unit.DamageEffects.FollowUpDamageBonus > 0)
        {
            _view.WriteLine($"{_unit.Name} realizará +{_unit.DamageEffects.FollowUpDamageBonus} daño extra en su Follow-Up");
        }
    }

    public void PrintBaseDamagePercentageReductionToRival()
    {
        Unit rival = _unit.Rival;
        if (rival.DamageEffects.BasePercentageDamageReduction > 0)
        {
            _view.WriteLine($"{_unit.Name} reducirá el daño de los ataques del rival en un {Math.Round(rival.DamageEffects.BasePercentageDamageReduction * 100)}%");
        }
    }

    public void PrintFirstAttackDamagePercentageReductionToRival()
    {
        Unit rival = _unit.Rival;
        if (rival.DamageEffects.FirstAttackPercentageDamageReduction > 0)
        {
            _view.WriteLine($"{_unit.Name} reducirá el daño del primer ataque del rival en un {Math.Round(rival.DamageEffects.FirstAttackPercentageDamageReduction * 100)}%");
        }
    }
    
    public void PrintFollowUpDamagePercentageReductionToRival()
    {
        Unit rival = _unit.Rival;
        if (rival.DamageEffects.FollowUpPercentageDamageReduction > 0)
        {
            _view.WriteLine($"{_unit.Name} reducirá el daño del Follow-Up del rival en un {Math.Round(rival.DamageEffects.FollowUpPercentageDamageReduction * 100)}%");
        }
    }

    public void PrintBaseDamageReduction()
    {
        Unit rival = _unit.Rival;
        if (rival.DamageEffects.BaseDamageReduction > 0)
        {
            _view.WriteLine($"{_unit.Name} recibirá -{rival.DamageEffects.BaseDamageReduction} daño en cada ataque");
        }
    }

    public void PrintHealBonusAfterAttacks()
    {
        // ¿pasar lógica a modelo?
        int healBonus = (int)(_unit.HealingPercentageAfterAttack * 100);
        if (_unit.HealingPercentageAfterAttack > 0)
        {
            _view.WriteLine($"{_unit.Name} recuperará HP igual al {healBonus}% del daño realizado en cada ataque");
        }
    }
}