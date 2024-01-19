using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuroraMAUI_API.ViewModels;

namespace AuroraMAUI_API.Views
{
    public partial class ReservaPage : ContentPage
    {
        private ReservaViewModel viewModel;

        public ReservaPage()
        {
            InitializeComponent();
            viewModel = new ReservaViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string nombre = entrynombre.Text;
            string telefono = entryTelefono.Text;
            int numeroPersonas = int.Parse(numPersona.Text);
            DateTime fecha = Fechita.Date;
            string tiempo = horaLlegada.Text;

            bool reservaExitosa = await viewModel.CrearReserva(nombre, telefono, numeroPersonas, fecha, tiempo);

            if (reservaExitosa)
            {
                await DisplayAlert("Éxito", "Reserva creada exitosamente", "Aceptar");
            }
            else
            {
                await DisplayAlert("Error", "Hubo un error al realizar la reserva", "Aceptar");
            }
        }
    }
}










