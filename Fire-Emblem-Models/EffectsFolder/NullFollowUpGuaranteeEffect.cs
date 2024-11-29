namespace Fire_Emblem_Models.EffectsFolder;

public class NullFollowUpGuaranteeEffect : Effect
{
    public override void Apply(Unit unit)
    {
        unit.IsFollowUpGuaranteeAnnulled = true;
    }
}