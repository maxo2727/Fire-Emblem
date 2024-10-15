using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.SkillsFolder;

public class Skills
{
    private readonly List<Skill> _skills = new List<Skill>();
    
    public void AddSkill(string skillName)
    {
        Skill skill = SkillFactory.CreateSkill(skillName);
        _skills.Add(skill);
    }
    
    public void CheckIfUnitCanUseSkills(Unit unit)
    {
        foreach (Skill skill in _skills)
        {
            skill.UseSkill(unit);
        }
    }
    
    public bool AreSkillsOutsideSizeRange()
    {
        int skillsCount = _skills.Count;
        return 2 < skillsCount;
    }

    public bool AreThereAnyRepeatedSkills()
    {
        HashSet<string> uniqueSkillNames = new HashSet<string>();
        foreach (Skill skill in _skills)
        {
            if (!uniqueSkillNames.Add(skill.Name))
                return true;
        }
        return false;
    }
}