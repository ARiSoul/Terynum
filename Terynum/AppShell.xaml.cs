using Terynum.Pages;

namespace Terynum;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ConfigNewMatchPage), typeof(ConfigNewMatchPage));
        Routing.RegisterRoute(nameof(MatchPage), typeof(MatchPage));
    }
}
