using Fire_Emblem_View;

namespace Fire_Emblem.ResponseHandlerFolder;

public class ResponseHandlerTeam:ResponseHandler.ResponseHandler
{
    private FireEmblemView _view;
    
    public ResponseHandlerTeam(FireEmblemView view) : base(view)
    {
        _view = view;
    }
    
    public override void ShowArrayOfOptions<Thing>(IEnumerable<Thing> options)
    {
        string[] teamsFolder = options.Cast<string>().ToArray();
        for (int i = 0; i < teamsFolder.Count(); i++)
        {
            string teamFile = teamsFolder[i].Split('\\')[2];
            _view.WriteLine($"{i}: {teamFile}");
        }
    }
}