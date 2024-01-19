using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace AuroraMAUI_API.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservasView : ContentPage
    {
        public ReservasView()
        {
            InitializeComponent();
            LoadReservasAsync();
        }

        private async void LoadReservasAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cambia la URL a la direcci�n de tu API y la ruta del m�todo GET
                    string apiUrl = "https://localhost:7051/api/Reservas";

                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonContent = await response.Content.ReadAsStringAsync();

                        // Deserializa el JSON a una lista de reservas
                        List<Class1> reservasList = JsonConvert.DeserializeObject<List<Class1>>(jsonContent);

                        // Establecer el origen de datos del ListView
                        ReservasListView.ItemsSource = reservasList;
                    }
                    else
                    {
                        // Manejar errores si es necesario
                        Console.WriteLine("Error al obtener las reservas. C�digo de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones si es necesario
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}


