using Terynum.Pages;

namespace Terynum;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(SelectPlayersPage), typeof(SelectPlayersPage));
    }
}
