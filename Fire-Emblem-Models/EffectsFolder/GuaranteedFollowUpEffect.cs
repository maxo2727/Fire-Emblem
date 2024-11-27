namespace Fire_Emblem_Models.EffectsFolder;

public class GuaranteedFollowUpEffect : Effect
{
    private int _numberOfGuaranteedFollowUps = 1;

    public override void Apply(Unit unit)
    {
        unit.NumberOfGuaranteedFollowUps += _numberOfGuaranteedFollowUps;
    }
}