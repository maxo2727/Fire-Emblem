using Fire_Emblem_Models;
using Fire_Emblem_View;

// using System.Linq;

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

    // Hacer un método para AskUserForString y AskUserForUnit?
    public Thing AskUserForOption<Thing>(IList<Thing> options)
    {
        int minValue = 0;
        int maxValue = options.Count() - 1;
        int selectedOption = AskUserToSelectNumber(minValue, maxValue);
        return options[selectedOption];
    }
    
    public int AskUserToSelectNumber(int minValue, int maxValue)
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