using System.Text.Json;

namespace Fire_Emblem.UnitsFolder;

public class UnitsJsonReader
{
    public static Dictionary<string, string> GetUnitInfo(string unitObjective)
    {
        List<Dictionary<string, string>> unitsList = GetListOfUnits("characters.json"); // VAR GLOBAL?
        return GetUnitInfoFromList(unitsList, unitObjective);
    }
    
    private static List<Dictionary<string, string>> GetListOfUnits(string unitsJsonFilePath)
    {
        string unitsJsonString = File.ReadAllText(unitsJsonFilePath);
        List<Dictionary<string, string>> unitsList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(unitsJsonString);
        return unitsList;
    }

    private static Dictionary<string, string> GetUnitInfoFromList(List<Dictionary<string, string>> unitsList, string unitObjective)
    {
        Dictionary<string, string> unitInfo = new Dictionary<string, string>();
        foreach (Dictionary<string, string> unit in unitsList)
        {
            if (unit["Name"] == unitObjective)
            {
                unitInfo = unit;
                break;
            }
        }
        return unitInfo;
    }
}