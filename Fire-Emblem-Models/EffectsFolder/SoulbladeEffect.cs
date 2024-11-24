namespace Fire_Emblem_Models.EffectsFolder;

public class SoulbladeEffect : Effect
{
    private Unit _rival;
    public override void Apply(Unit unit)
    {
        _rival = unit.Rival;
        int defBaseStat = _rival.Stats.GetStat("Def").BaseStat;
        int resBaseStat = _rival.Stats.GetStat("Res").BaseStat;
        int promedioDefRes = (defBaseStat + resBaseStat) / 2;
        int defModification = promedioDefRes - defBaseStat;
        int resModification = promedioDefRes - resBaseStat;
        AddSoulbladeModification("Def", defModification);
        AddSoulbladeModification("Res", resModification);
    }

    public void AddSoulbladeModification(string stat, int modification)
    {
        if (modification > 0)
        {
            _rival.Stats.ModifyBonuses(stat, modification);
        }
        else
        {
            _rival.Stats.ModifyPenalties(stat, -modification);
        }
    }
}