using Fire_Emblem_View;
using Fire_Emblem.UnitsFolder;

namespace Fire_Emblem.ResponseHandlerFolder;

public class ResponseHandlerUnit:ResponseHandler.ResponseHandler
{
    private View _view;

    public ResponseHandlerUnit(View view) : base(view)
    {
        _view = view;
    }

    public override void ShowArrayOfOptions<Thing>(IEnumerable<Thing> options)
    {
        List<Unit> aliveUnits = options.Cast<Unit>().ToList();
        for (int i = 0; i < aliveUnits.Count(); i++)
        {
            Unit unit = aliveUnits[i];
            _view.WriteLine($"{i}: {unit.Name}");
        }
    }
}