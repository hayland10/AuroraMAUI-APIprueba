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
        Routing.RegisterRoute(nameof(MenuPrincipal), typeof(MenuPrincipal));
        Routing.RegisterRoute(nameof(IniciarSesion), typeof(IniciarSesion));
        Routing.RegisterRoute(nameof(Registrarse), typeof(Registrarse));

    }
}
