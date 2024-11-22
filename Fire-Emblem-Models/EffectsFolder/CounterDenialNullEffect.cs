namespace Fire_Emblem_Models.EffectsFolder;

public class CounterDenialNullEffect : Effect
{
    public override void Apply(Unit unit)
    {
        unit.IsCounterDenialAnnulled = true;
    }
}