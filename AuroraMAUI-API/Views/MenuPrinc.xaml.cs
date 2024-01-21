using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;


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

        private void Regresar_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("..");
        }

        public async void Actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "https://localhost:7051/api/Fiestas";
                var response = await client.GetStringAsync(url);

                var fiestas = JsonConvert.DeserializeObject<List<RootFiestin>>(response);

                var ultimasFiestas = fiestas.OrderByDescending(f => f.idFiesta).Take(3).ToList();

                for (int i = 0; i < ultimasFiestas.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Fiesta1.Text = ultimasFiestas[i].nombreFiesta;
                            Casino.Source = ultimasFiestas[i].imagen;
                            break;
                        case 1:
                            Fiesta2.Text = ultimasFiestas[i].nombreFiesta;
                            SAVAGE.Source = ultimasFiestas[i].imagen;
                            break;
                        case 2:
                            Fiesta3.Text = ultimasFiestas[i].nombreFiesta;
                            Zens.Source = ultimasFiestas[i].imagen;
                            break;
                    }
                }

                labelDatos.Text = "Fiestas actualizadas correctamente";
            }
            catch (Exception ex)
            {
                labelDatos.Text = $"Error al actualizar las fiestas: {ex.Message}";
            }
        }
    }
}
