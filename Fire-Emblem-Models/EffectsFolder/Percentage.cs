namespace Fire_Emblem_Models.EffectsFolder;

public class Percentage : Effect
{
    private Effect _effect;

    public Percentage(Effect effect)
    {
        _effect = effect;
    }

    public override void Apply(Unit unit)
    {
        _effect.Apply(unit);
    }
}