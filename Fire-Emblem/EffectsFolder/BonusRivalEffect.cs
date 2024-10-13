using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class BonusRivalEffect : BonusEffect
{
    public BonusRivalEffect(string stat, int bonus) : base(stat, bonus) {}

    public override void Apply(Unit unit)
    {
        base.Apply(unit.GetRivalUnit());
    }
}