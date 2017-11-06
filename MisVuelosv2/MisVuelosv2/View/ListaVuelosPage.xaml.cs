using MisVuelosv2.Model;
using MisVuelosv2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MisVuelosv2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaVuelosPage : ContentPage
    {
        public ListaVuelosPage()
        {
            InitializeComponent();
        }

        public ListaVuelosPage(string origen, string destino, int dia, int mes, int año)
        {
            InitializeComponent();
            BindingContext = new ListaVuelosPageViewModel(origen,destino,dia,mes,año);
        }

        private void ListaVuelos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (((ListView)sender).SelectedItem != null)
            {
                var Id_vuelo = (ListaVuelos.SelectedItem as Vuelos).ID;
                Navigation.PushAsync(new ReservarPage(Id_vuelo));
            }
        }
    }
}