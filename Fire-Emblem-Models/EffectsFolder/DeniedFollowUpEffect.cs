namespace Fire_Emblem_Models.EffectsFolder;

public class DeniedFollowUpEffect : Effect
{
    private int _numberOfDeniedFollowUpsByEffect = 1;
    public override void Apply(Unit unit)
    {
        unit.NumberOfDeniedFollowUps += _numberOfDeniedFollowUpsByEffect;
    }
}