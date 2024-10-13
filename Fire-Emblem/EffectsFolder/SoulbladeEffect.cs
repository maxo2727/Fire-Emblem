using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class SoulbladeEffect : Effect
{
    private Unit _rival;
    public override void Apply(Unit unit)
    {
        _rival = unit.GetRivalUnit();
        int defBaseStat = _rival.Stats["Def"].BaseStat;
        int resBaseStat = _rival.Stats["Res"].BaseStat;
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
            _rival.ModifyBonuses(stat, modification);
        }
        else
        {
            _rival.ModifyPenalties(stat, modification);
        }
    }
}