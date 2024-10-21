namespace Fire_Emblem_Models.EffectsFolder;

public class DivineRecreationExtraDamageEffect : Effect
{
    public override void Apply(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        int rivalFirstAttackDifference = rival.DamageEffects.CalculateModifiedFirstAttackDamage(2);
        int damageExtra = rivalFirstAttackDifference * 100;
    }
}