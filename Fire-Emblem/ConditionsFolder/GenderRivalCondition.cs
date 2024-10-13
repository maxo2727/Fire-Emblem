using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

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