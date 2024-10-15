namespace Fire_Emblem_View;

public class FireEmblemView
{
    private readonly View _view;

    public FireEmblemView(View view)
    {
        _view = view;
    }
    
    public string ReadLine() => _view.ReadLine();

    public void WriteLine(string message)
    {
        _view.WriteLine(message);
    }

    public void Hola()
    {
        _view.WriteLine("Hola!!");
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
}