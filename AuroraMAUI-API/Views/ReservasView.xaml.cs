using AuroraMAUI_API.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace AuroraMAUI_API.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservasView : ContentPage
    {
        private VerReservaViewModel _viewModel;

        public ReservasView()
        {
            InitializeComponent();
            _viewModel = new VerReservaViewModel();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadReservasAsync();
        }
    }
}



