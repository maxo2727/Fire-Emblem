namespace Fire_Emblem_Models.ConditionsFolder;

public class GenderRivalCondition: ICondition
{
    private string _gender;

    public GenderRivalCondition(string gender)
    {
        _gender = gender;
    }

    public bool IsMet(Unit unit)
    {
        Unit rival = unit.GetRivalUnit();
        return rival.Gender == _gender;
    }
}