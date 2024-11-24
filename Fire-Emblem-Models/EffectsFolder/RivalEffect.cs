namespace Fire_Emblem_Models.EffectsFolder;

public class RivalEffect : Effect
{
    private Effect _baseEffect;

    public RivalEffect(Effect baseEffect)
    {
        _baseEffect = baseEffect;
    }

    public override void Apply(Unit unit)
    {
        Unit rival = unit.Rival;
        _baseEffect.Apply(rival);
    }
}