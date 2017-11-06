using MisVuelosv2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MisVuelosv2.ViewModel
{
    public class ListaVuelosPageViewModel : ContentPage
    {

        public ListaVuelosPageViewModel(string origen, string destino, int dia, int mes, int año)
        {
            BuscarVuelos(origen, destino, dia, mes, año);
        }

        public ObservableCollection<Vuelos> ListaVuelosDisponibles { get; set; } = new ObservableCollection<Vuelos>();

        private async void BuscarVuelos(string origen, string destino, int dia, int mes, int año)
        {
            try
            {
                ListaVuelosDisponibles = new ObservableCollection<Vuelos>();
                var client = await App.Database.GetVuelosAsync();
                var lista = client.Where
                                (
                                    x => x.origen.Trim() == origen.Trim() &&
                                    x.destino.Trim() == destino.Trim() &&
                                    x.fecha.Value.Day == dia &&
                                    x.fecha.Value.Month == mes &&
                                    x.fecha.Value.Year == año
                                    ).ToList(); // && x.fecha.Value.Date == fecha.Date).ToList();

                foreach (var item in lista)
                {
                    ListaVuelosDisponibles.Add(item);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.InnerException.Message, "Cerrar");
            }
        }


    }
}