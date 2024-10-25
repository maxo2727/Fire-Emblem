using Fire_Emblem_Models;
using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.BattleFolder;

public class DamageCalculator
{
    private FireEmblemView _view;
    private GameInfo _gameInfo;
    private AdvantageEvaluator _advantageEvaluator;

    public DamageCalculator(FireEmblemView view, GameInfo gameInfo)
    {
        _view = view;
        _gameInfo = gameInfo;
        _advantageEvaluator = new AdvantageEvaluator(view, gameInfo);
    }
    
    public int CalculateDamage(Unit attacker, Unit defender)
    {
        double WTB = _advantageEvaluator.GetAdvantageWTB(attacker, defender);
        int attack = attacker.Stats.GetStat("Atk").GetStatWithEffects(attacker);
        string defenseType = WeaponDefenseGetter.GetDefenseFromWeaponType(attacker.Weapon);
        int defense = defender.Stats.GetStat(defenseType).GetStatWithEffects(defender);
        int damage = (int)Math.Truncate(attack * WTB - defense);

        int modifiedDamage; 
        if (!attacker.HasMadeFirstAttack)
        {
            modifiedDamage = attacker.DamageEffects.CalculateModifiedFirstAttackDamage(damage);
        }
        else if (attacker.InFollowUp)
        {
            modifiedDamage = attacker.DamageEffects.CalculateModifiedFollowUpDamage(damage);
        }
        else
        {
            modifiedDamage = attacker.DamageEffects.CalculateModifiedBaseDamage(damage);
        }
        
        if (modifiedDamage < 0)
            modifiedDamage = 0;
        
        if (!attacker.HasMadeFirstAttack)
        {
            attacker.HasMadeFirstAttack = true;
        }
        _view.PrintCombatEvent(attacker.Name, defender.Name, modifiedDamage);
        return modifiedDamage;
    }
}