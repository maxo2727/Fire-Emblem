using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.EffectsFolder;

public class ForeachHPLostBonusEffect : Effect
{
    private string _stat;
    private int _multiplicator; // MULT OR FRACT???

    public ForeachHPLostBonusEffect(string stat, int multiplicator)
    {
        _stat = stat;
        _multiplicator = multiplicator;
    }

    public override void Apply(Unit unit)
    {
        // ta bien el tren unit.Hp.GetMaxHp? o lo manejo como metodo dentro de unit?
        int lostHP = unit.Hp.GetMaxHP() - unit.Hp.GetCurrentHP();
        int bonus = lostHP * _multiplicator;
        if (bonus > 30)
            bonus = 30;
        unit.ModifyBonuses(_stat, bonus);
    }
}