using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuroraMAUI_API.Views
{
    public partial class IniciarSesion : ContentPage
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            // Mostramos un indicador de carga durante el inicio de sesión
            activityIndicator.IsRunning = true;

            bool resultadoInicioSesion = await RealizarInicioSesionAsync();

            // Ocultamos el indicador de carga después del inicio de sesión
            activityIndicator.IsRunning = false;

            if (resultadoInicioSesion)
            {
                await Shell.Current.GoToAsync(nameof(MenuPrinc));
            }
            else
            {
                await DisplayAlert("Error", "Inicio de sesión fallido", "OK");
            }
        }

        private async Task<bool> RealizarInicioSesionAsync()
        {
            await Task.Delay(3000);
            return true;
        }

        private async void Regresar_Clicked(object sender, EventArgs e)
        {
            // Mostramos un indicador de carga durante el regreso
            activityIndicator.IsRunning = true;
            await Shell.Current.GoToAsync("..");
            activityIndicator.IsRunning = false;
        }
    }
}

