namespace Fire_Emblem_Models.EffectsFolder;

public class DamageExtraFirstAttackPercentageDifferenceRivalStatEffect : Effect
{
    private string _unitStat;
    private string _rivalStat;
    private double _percentage;

    public DamageExtraFirstAttackPercentageDifferenceRivalStatEffect(string unitStat, string rivalStat, double percentage)
    {
        _unitStat = unitStat;
        _rivalStat = rivalStat;
        _percentage = percentage;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.Rival;
        int unitStatValue = unit.Stats.GetStat(_unitStat).GetStatWithBaseEffects();
        int rivalStatValue = rival.Stats.GetStat(_rivalStat).GetStatWithBaseEffects();
        int difference = Math.Abs(unitStatValue - rivalStatValue);
        double differencePonderated = difference * _percentage;
        double differencePonderatedRounded = Math.Round(differencePonderated, 9);
        int differencePonderatedTruncated = (int)Math.Floor(differencePonderatedRounded);
        unit.DamageEffects.FirstAttackDamageBonus += differencePonderatedTruncated;
    }
}