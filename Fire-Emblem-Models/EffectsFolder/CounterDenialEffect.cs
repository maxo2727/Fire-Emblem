namespace Fire_Emblem_Models.EffectsFolder;

public class CounterDenialEffect : Effect
{
    public override void Apply(Unit unit)
    {
        unit.IsCounterDenied = true;
    }
}