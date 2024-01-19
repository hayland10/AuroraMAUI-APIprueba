using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;

namespace AuroraMAUI_API.Views;

public partial class ReservasView : ContentPage
{
	public ReservasView()
	{
		InitializeComponent();
	}

    public async void Buscar_clicked(object sender, EventArgs e)
    {
        int num = int.Parse(lblNum.Text);

        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            using (var client = new HttpClient())
            {
                string url = $"https://localhost:7051/api/Reservas/{num}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var reserva = JsonConvert.DeserializeObject<Rootobject>(json);
                    lblNombre.Text = reserva.nombre;
                    lblNumPersonas.Text = reserva.numeroPersonas.ToString();
                    lblHoraLlegada.Text = reserva.horaLlega;
                    lblTelefono.Text= reserva.telefono;


                }
            }
        }
    }
}