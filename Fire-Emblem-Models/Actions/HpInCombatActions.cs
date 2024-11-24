namespace Fire_Emblem_Models.Actions;

public static class HpInCombatActions
{
    public static readonly Action<Unit, int> HealingBeforeCombat = SetHealingBeforeCombat();
    public static readonly Action<Unit, int> DamageBeforeCombat = SetDamageBeforeCombat();
    public static readonly Action<Unit, int> HealingAfterCombat = SetHealingAfterCombat();
    public static readonly Action<Unit, int> DamageAfterCombat = SetDamageAfterCombat();
    public static readonly Action<Unit, int> DamageAfterCombatIfHasAttacked = SetDamageAfterCombatIfHasAttacked();

    private static Action<Unit, int> SetHealingBeforeCombat()
    {
        return (unit, value) => unit.HealingBeforeCombat = value;
    }

    private static Action<Unit, int> SetDamageBeforeCombat()
    {
        return (unit, value) => unit.DamageBeforeCombat = value;
    }
    
    private static Action<Unit, int> SetHealingAfterCombat()
    {
        return (unit, value) => unit.HealingAfterCombat = value;
    }
    
    private static Action<Unit, int> SetDamageAfterCombat()
    {
        return (unit, value) => unit.DamageAfterCombat = value;
    }

    private static Action<Unit, int> SetDamageAfterCombatIfHasAttacked()
    {
        return (unit, value) => unit.DamageAfterCombatIfHasAttacked = value;
    }
}