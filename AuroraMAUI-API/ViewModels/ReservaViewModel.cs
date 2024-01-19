// ReservaViewModel.cs
using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuroraMAUI_API.ViewModels
{
    public class ReservaViewModel
    {
        public async Task<bool> CrearReserva(string nombre, string telefono, int numeroPersonas, DateTime fecha, string tiempo)
        {
            Rootobject reserva = new Rootobject
            {
                nombre = nombre,
                telefono = telefono,
                numeroPersonas = numeroPersonas,
                fecha = fecha,
                horaLlega = tiempo
            };

            string jsonReserva = JsonConvert.SerializeObject(reserva);

            string apiUrl = "https://localhost:7051/api/Reservas";
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(jsonReserva, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

            return response.IsSuccessStatusCode;
        }
    }
}
