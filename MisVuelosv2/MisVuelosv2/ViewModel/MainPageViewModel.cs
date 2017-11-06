using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MisVuelosv2.ViewModel
{

    public class MainPageViewModel : ContentPage
    {
        public MainPageViewModel()
        {
            CargarBusquedas();
        }

        public List<Model.Aerolineas> ListaAerolineas
        {
            get;
            set;
        }

        public List<Model.Ciudades> ListaCiudades
        {
            get;
            set;
        }

        private void CargarBusquedas()
        {
            try
            {
                ListaAerolineas = App.Database.GetAerolineas().ToList();
                ListaCiudades = App.Database.GetCiudades().ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
