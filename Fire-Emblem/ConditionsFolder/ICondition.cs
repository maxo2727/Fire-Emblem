using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem;

public interface ICondition
{
    // virtual bool IsMet();
    bool IsMet(Unit unit);
}