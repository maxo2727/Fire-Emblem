namespace Fire_Emblem_Models.EffectsFolder;

public class  BonusRivalEffect : BonusEffect
{
    public BonusRivalEffect(string stat, int bonus) : base(stat, bonus) {}

    public override void Apply(Unit unit)
    {
        base.Apply(unit.Rival);
    }
}