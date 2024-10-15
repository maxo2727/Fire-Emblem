namespace Fire_Emblem_View;

public class View
{
    private readonly AbstractView _view;

    public static View BuildConsoleView()
        => new View(new ConsoleView());
    
    public static View BuildTestingView(string pathTestScript)
        => new View(new TestingView(pathTestScript));

    public static View BuildManualTestingView(string pathTestScript)
        => new View(new ManualTestingView(pathTestScript));

    private View(AbstractView newView)
    {
        _view = newView;
    }

    public string ReadLine() => _view.ReadLine();

    public void WriteLine(string message)
    {
        _view.WriteLine(message);
    }
    
    public string[] GetScript()
        => _view.GetScript();

    public void ShowArrayOfTeams(string[] teamFiles)
    {
        WriteLine("Elige un archivo para cargar los equipos");
        for (int i = 0; i < teamFiles.Length; i++)
        {
            string teamFile = teamFiles[i];
            WriteLine($"{i}: {teamFile}");
        }
    }
}