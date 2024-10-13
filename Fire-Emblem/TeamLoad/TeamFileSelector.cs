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
    
    public string SelectTeamFile(string teamsFolder)
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] teamPaths = GetAvailableTeamsInOrder(teamsFolder);
        _responseHandler.ShowArrayOfOptions(teamPaths);
        string teamFile = _responseHandler.AskUserForOption(teamPaths);
        return teamFile;
    }
    private string[] GetAvailableTeamsInOrder(string teamsFolder)
    {
        string[] teams = Directory.GetFiles(teamsFolder, "*.txt");
        return teams;
    }
}

// si tengo dos metodos separados pero uno llama a otro, usando todos los atributos, es cohesivo?
// GetAvailableTeamsInOrder debe ir en nueva clase (estática)? O como es tan pequeña y tampoco se aleja tanto su responsabilidad no es necesario...