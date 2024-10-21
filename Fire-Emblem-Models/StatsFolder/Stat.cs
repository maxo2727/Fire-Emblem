namespace Fire_Emblem_Models.StatsFolder;

public class Stat
{
    // Dictionary? O organizarlo mejor?
    public int BaseStat;
    public int Bonus = 0;
    public int Penalty = 0;
    public int FirstAttackBonus = 0;
    public int FirstAttackPenalty = 0;
    public int FollowUpBonus = 0;
    public int FollowUpPenalty = 0;
    public bool AreBonusesNeutralized = false;
    public bool ArePenaltiesNeutralized = false;

    public virtual int GetStatWithEffects()
    {
        int statValue = BaseStat;
        if (!AreBonusesNeutralized)
        {
            statValue += Bonus;
        }
        if (!ArePenaltiesNeutralized)
        {
            statValue += Penalty;
        }
        return statValue;
    }
    
    // DamageCalculator?
    protected int CalculateStatWithEffectsWhenCheckingAttacksOf(Unit unit)
    {
        int statValue = BaseStat;
        if (!AreBonusesNeutralized)
        {
            statValue += Bonus;
            if (!unit.HasMadeFirstAttack)
            {
                statValue += FirstAttackBonus;
            }
            if (unit.InFollowUp)
            {
                statValue += FollowUpBonus;
            }
        }
        if (!ArePenaltiesNeutralized)
        {
            statValue += Penalty;
            if (!unit.HasMadeFirstAttack)
            {
                statValue += FirstAttackPenalty;
            }
            if (unit.InFollowUp)
            {
                statValue += FollowUpPenalty;
            }
        }
        return statValue;
    }

    public virtual int GetStatWithEffects(Unit unit)
    {
        return CalculateStatWithEffectsWhenCheckingAttacksOf(unit);
    }

    public void ClearStatEffects()
    {
        Bonus = 0;
        Penalty = 0;
        FirstAttackBonus = 0;
        FirstAttackPenalty = 0;
        FollowUpBonus = 0;
        FollowUpPenalty = 0;
        AreBonusesNeutralized = false;
        ArePenaltiesNeutralized = false;
    }

    public int GetStatWithBaseEffects()
    {
        return BaseStat + Bonus + Penalty;
    }
}