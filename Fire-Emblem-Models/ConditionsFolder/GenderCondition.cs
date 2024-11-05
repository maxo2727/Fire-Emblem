namespace Fire_Emblem_Models.ConditionsFolder;

public class GenderCondition : ICondition
{
    private string _gender;

    public GenderCondition(string gender)
    {
        _gender = gender;
    }

    public bool IsMet(Unit unit)
    {
        return unit.Gender == _gender;
    }
}