namespace Fire_Emblem_Models.EffectsFolder;

public class NullFollowUpDenialEffect : Effect
{
    public override void Apply(Unit unit)
    {
        unit.IsFollowUpDenialAnnulled = true;
    }
}