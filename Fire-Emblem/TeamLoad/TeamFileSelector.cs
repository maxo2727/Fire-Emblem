using Fire_Emblem_View;
using Fire_Emblem.ResponseHandlerFolder;

namespace Fire_Emblem.TeamLoad;

public class TeamFileSelector
{
    private View _view;
    private ResponseHandler.ResponseHandler _responseHandler;

    public TeamFileSelector(View view)
    {
        _view = view;
        _responseHandler = new ResponseHandlerTeam(_view);
    }

    public string SelectTeamFileNuevo(string teamsFolder)
    {
        // Agrupar
        string[] teamPaths = GetAvailableTeamsInOrder(teamsFolder);
        string[] teamFiles = ParseTeamPathsIntoTeamFileNames(teamPaths);
        _view.ShowArrayOfTeams(teamFiles);
        string teamFile = GetUserSelectedOption(teamFiles);
        return teamFile;
    }

    public string GetUserSelectedOption(string[] options)
    {
        return _responseHandler.AskUserForOption(options);
    }
    
    public string SelectTeamFile(string teamsFolder)
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] teamPaths = GetAvailableTeamsInOrder(teamsFolder);
        _responseHandler.ShowArrayOfOptions(teamPaths);
        string teamFile = _responseHandler.AskUserForOption(teamPaths);
        return teamFile;
    }
    
    public string[] GetAvailableTeamsInOrder(string teamsFolder)
    {
        string[] teams = Directory.GetFiles(teamsFolder, "*.txt");
        return teams;
    }

    public string[] ParseTeamPathsIntoTeamFileNames(string[] teamPaths)
    {
        List<string> teamFiles = new List<string>();
        for (int i = 0; i < teamPaths.Count(); i++)
        {
            teamFiles.Add(teamPaths[i].Split('\\')[2]);
        }
        return teamFiles.ToArray();
    }
}