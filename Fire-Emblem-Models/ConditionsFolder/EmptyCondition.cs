namespace Fire_Emblem_Models.ConditionsFolder;

public class EmptyCondition: ICondition
{
    public bool IsMet(Unit unit)
    {
        return true;
    }
}