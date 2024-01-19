using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuroraMAUI_API.Views
{
    public partial class ReservaPage : ContentPage
    {
        public ReservaPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Obtén los datos de la interfaz de usuario
            string nombre = entrynombre.Text;
            string telefono = entryTelefono.Text;
            int numeroPersonas = int.Parse(numPersona.Text);
            DateTime fecha = Fechita.Date;
            string tiempo = horaLlegada.Text;

            // Crea un objeto Reserva con los datos
            Rootobject reserva = new Rootobject
            {
                nombre = nombre,
                telefono = telefono,
                numeroPersonas = numeroPersonas,
                fecha = fecha,
                horaLlega = tiempo
            };

            // Convierte el objeto Reserva a formato JSON
            string jsonReserva = JsonConvert.SerializeObject(reserva);

            // Realiza la solicitud POST a la API
            string apiUrl = "https://localhost:7051/api/Reservas"; // Reemplaza con la URL correcta de tu API
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(jsonReserva, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

            // Maneja la respuesta de la API
            if (response.IsSuccessStatusCode)
            {
                // La reserva se creó exitosamente
                // Puedes manejar el resultado como desees (por ejemplo, mostrar un mensaje de éxito)
                await DisplayAlert("Éxito", "Reserva creada exitosamente", "Aceptar");
            }
            else
            {
                // Hubo un error al realizar la reserva
                // Puedes manejar el error como desees (por ejemplo, mostrar un mensaje de error)
                await DisplayAlert("Error", "Hubo un error al realizar la reserva", "Aceptar");
            }
        }
    }
}










