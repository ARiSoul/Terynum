using Terynum.Pages;

namespace Terynum;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ConfigNewGamePage), typeof(ConfigNewGamePage));
        Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
    }
}
