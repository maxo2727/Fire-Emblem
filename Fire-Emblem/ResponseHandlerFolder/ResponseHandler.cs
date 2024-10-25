using Fire_Emblem_Models;
using Fire_Emblem_View;

namespace Fire_Emblem.ResponseHandlerFolder;

public class ResponseHandler
{
    private FireEmblemView _view;

    public ResponseHandler(FireEmblemView view)
    {
        _view = view;
    }

    public Unit AskUserForUnit(List<Unit> units)
    {
        int minValue = 0;
        int maxValue = units.Count() - 1;
        int selectedOption = AskUserToSelectNumber(minValue, maxValue);
        return units[selectedOption];
    }
    
    public string AskUserForTeamFile(string[] teamFiles)
    {
        int minValue = 0;
        int maxValue = teamFiles.Count() - 1;
        int selectedOption = AskUserToSelectNumber(minValue, maxValue);
        return teamFiles[selectedOption];
    }
    
    private int AskUserToSelectNumber(int minValue, int maxValue)
    {
        int value;
        bool wasParsePossible;
        do
        {
            string? userInput = _view.GetOptionNumber();
            wasParsePossible = int.TryParse(userInput, out value);
        } while (!wasParsePossible || IsValueOutsideTheValidRange(minValue, value, maxValue));

        return value;
    }
    
    public bool IsValueOutsideTheValidRange(int minValue, int value, int maxValue)
        => value < minValue || value > maxValue;
}