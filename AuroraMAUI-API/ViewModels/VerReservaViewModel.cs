﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Input;

namespace AuroraMAUI_API.ViewModels
{
    public class VerReservaViewModel : BaseViewModel
    {
        private ObservableCollection<Class1> _reservas;

        public ObservableCollection<Class1> Reservas
        {
            get => _reservas;
            set => SetProperty(ref _reservas, value);
        }

        public VerReservaViewModel()
        {
            LoadReservasAsync(); // Llama automáticamente al cargar el ViewModel
        }

        public async Task LoadReservasAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7051/api/Reservas";

                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonContent = await response.Content.ReadAsStringAsync();
                        var reservasList = JsonConvert.DeserializeObject<List<Class1>>(jsonContent);

                        foreach (var reserva in reservasList)
                        {
                            // Asignar un Command a cada reserva
                            reserva.EliminarCommand = new Command(async () => await EliminarReservaAsync(reserva.idReserva));
                        }

                        Reservas = new ObservableCollection<Class1>(reservasList);
                    }
                    else
                    {
                        Console.WriteLine("Error al obtener las reservas. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private async Task EliminarReservaAsync(int idReserva)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"https://localhost:7051/api/Reservas/{idReserva}";

                    var response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Recargar las reservas después de la eliminación
                        await LoadReservasAsync();
                    }
                    else
                    {
                        Console.WriteLine("Error al eliminar la reserva. Código de estado: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la reserva: " + ex.Message);
            }
        }
    }
}

