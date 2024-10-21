namespace Fire_Emblem_Models.EffectsFolder;

public class GuardBearingEffect : Effect
{
    public override void Apply(Unit unit)
    {
        double percentage = 0.3;
        Unit rival = unit.GetRivalUnit();
        if (IsUnitFirstAttackOrDefenseCombat(unit))
        {
            percentage = 0.6;
        }
        rival.DamageEffects.IncreaseBasePercentageDamageReduction(percentage);
    }

    private bool IsUnitFirstAttackOrDefenseCombat(Unit unit)
    {
        return unit.IsAttacking && unit.IsFirstAttackingCombat ||
               unit.IsDefending && unit.IsFirstDefendingCombat;

    }
}