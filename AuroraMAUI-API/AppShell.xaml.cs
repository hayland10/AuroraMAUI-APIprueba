using AuroraMAUI_API.Views;

namespace AuroraMAUI_API;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MenuPrinc), typeof(MenuPrinc));
        Routing.RegisterRoute(nameof(ReservaPage), typeof(ReservaPage));
        Routing.RegisterRoute(nameof(ReservasView), typeof(ReservasView));
    }
}
