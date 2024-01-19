using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuroraMAUI_API.Views
{
    public partial class MenuPrinc : ContentPage
    {
        public MenuPrinc()
        {
            InitializeComponent();

        }

        private void Reservar_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ReservaPage));

        }

        private void VerReservas_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ReservasView));
        }
    }
}
