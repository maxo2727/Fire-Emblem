using Fire_Emblem_View;

// using System.Linq;

namespace Fire_Emblem.ResponseHandler;

public class ResponseHandler
{
    private View _view;

    public ResponseHandler(View view)
    {
        _view = view;
    }

    public virtual void ShowArrayOfOptions<Thing>(IEnumerable<Thing> options){}

    // No es tan buena idea dejarlo como IList...
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
            string? userInput = _view.ReadLine();
            wasParsePossible = int.TryParse(userInput, out value);
        } while (!wasParsePossible || IsValueOutsideTheValidRange(minValue, value, maxValue));

        return value;
    }
    
    public bool IsValueOutsideTheValidRange(int minValue, int value, int maxValue)
        => value < minValue || value > maxValue;
}