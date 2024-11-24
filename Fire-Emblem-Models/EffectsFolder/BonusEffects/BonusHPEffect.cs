namespace Fire_Emblem_Models.EffectsFolder.BonusEffects;

public class BonusHPEffect : Effect
{
    private int _bonus;

    public BonusHPEffect(int bonus)
    {
        _bonus = bonus;
    }
    public override void Apply(Unit unit)
    {
        unit.Hp.AddBonusMaxHP(_bonus);
    }
}