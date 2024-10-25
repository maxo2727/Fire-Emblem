using Fire_Emblem_View;
using Fire_Emblem.ResponseHandlerFolder;

namespace Fire_Emblem.TeamLoad;

public class TeamFileSelector
{
    private FireEmblemView _view;
    private ResponseHandler _responseHandler;
    private string[] _teamPaths;
    private string[] _teamFiles;

    public TeamFileSelector(FireEmblemView view)
    {
        _view = view;
        _responseHandler = new ResponseHandler(_view);
    }

    public string SelectTeamFileNuevo(string teamsFolder)
    {
        GetAvailableTeamsInOrder(teamsFolder);
        ShowAvailableTeamsInOrder();
        return GetUserSelectedTeamFile();
    }
    
    private void GetAvailableTeamsInOrder(string teamsFolder)
    {
        _teamPaths = Directory.GetFiles(teamsFolder, "*.txt");
    }

    private void ShowAvailableTeamsInOrder()
    {
        ParseTeamPathsIntoTeamFileNames();
        _view.ShowArrayOfTeams(_teamFiles);
    }
    
    private void ParseTeamPathsIntoTeamFileNames()
    {
        List<string> teamFiles = new List<string>();
        for (int i = 0; i < _teamPaths.Count(); i++)
        {
            teamFiles.Add(_teamPaths[i].Split('\\')[2]);
        }
        _teamFiles = teamFiles.ToArray();
    }
    
    private string GetUserSelectedTeamFile()
    {
        return _responseHandler.AskUserForTeamFile(_teamPaths);
    }
}