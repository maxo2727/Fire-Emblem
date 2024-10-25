namespace Fire_Emblem_Models;

public class Skills
{
    private readonly List<string> _skills = new List<string>();
    
    public void AddSkill(string skill)
    {
        _skills.Add(skill);
    }

    public List<string> GetAllSkills()
    {
        return _skills;
    }
    
    public bool AreSkillsOutsideSizeRange()
    {
        int skillsCount = _skills.Count;
        return 2 < skillsCount;
    }

    public bool AreThereAnyRepeatedSkills()
    {
        HashSet<string> uniqueSkillNames = new HashSet<string>();
        foreach (string skill in _skills)
        {
            if (!uniqueSkillNames.Add(skill))
                return true;
        }
        return false;
    }
}