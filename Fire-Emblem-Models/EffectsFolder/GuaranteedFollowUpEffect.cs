namespace Fire_Emblem_Models.EffectsFolder;

public class GuaranteedFollowUpEffect : Effect
{
    private int _numberOfGuaranteedFollowUpsByEffect = 1;

    public override void Apply(Unit unit)
    {
        unit.NumberOfGuaranteedFollowUps += _numberOfGuaranteedFollowUpsByEffect;
    }
}