namespace Fire_Emblem_Models.ConditionsFolder;

public interface ICondition
{
    bool IsMet(Unit unit);
}