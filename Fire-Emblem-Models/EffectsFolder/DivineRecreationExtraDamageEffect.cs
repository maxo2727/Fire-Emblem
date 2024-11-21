namespace Fire_Emblem_Models.EffectsFolder;

public class DivineRecreationExtraDamageEffect : Effect
{
    public override void Apply(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        int baseDamage = DamageCalculator.GetBaseDamage(rival, unit);
        int reducedDamage = rival.DamageEffects.GetTotalReductionToBaseDamage(baseDamage);
        int bonus = baseDamage - reducedDamage;
        Console.WriteLine($"Para {unit.Name}: {baseDamage} - {reducedDamage} = {bonus}");
        if (unit.IsAttacking)
        {
            unit.DamageEffects.FollowUpDamageBonus += bonus;
        }
        else
        {
            unit.DamageEffects.FirstAttackDamageBonus += bonus;
        }
    }
}