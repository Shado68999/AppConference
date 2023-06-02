namespace AppConference;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    internal static void UseMauiAppLaunching(Action<object> value)
    {
        throw new NotImplementedException();
    }
}
