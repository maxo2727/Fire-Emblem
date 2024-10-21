using Fire_Emblem_Models;

namespace Fire_Emblem_View;

public class FireEmblemView
{
    private readonly View _view;

    public FireEmblemView(View view)
    {
        _view = view;
    }

    public void WriteLine(string message)
    {
        _view.WriteLine(message);
    }
    
    public void ShowArrayOfTeams(string[] teamFiles)
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        for (int i = 0; i < teamFiles.Length; i++)
        {
            string teamFile = teamFiles[i];
            _view.WriteLine($"{i}: {teamFile}");
        }
    }

    public void ShowListOfUnits(int playerNumber, List<Unit> units)
    {
        _view.WriteLine($"Player {playerNumber} selecciona una opción");
        for (int i = 0; i < units.Count(); i++)
        {
            Unit unit = units[i];
            _view.WriteLine($"{i}: {unit.Name}");
        }
    }

    public string GetOptionNumber()
    {
        return _view.ReadLine();
    }
}