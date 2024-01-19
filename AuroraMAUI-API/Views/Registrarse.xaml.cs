using AuroraMAUI_API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuroraMAUI_API.ViewModels;

namespace AuroraMAUI_API.Views
{

    public partial class Registrarse : ContentPage
    {
        public Registrarse()
        {
            InitializeComponent();
        }
        private void Regresar_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("..");
        }
    }
}