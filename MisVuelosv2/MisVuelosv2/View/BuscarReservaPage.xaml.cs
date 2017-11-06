using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MisVuelosv2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarReservaPage : ContentPage
    {
        public BuscarReservaPage()
        {
            InitializeComponent();
            documento.Focus();
        }

        private void btn_buscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var r = App.Database.GetReservacionByReservaAsync(documento.Text.Trim()).Result.ToList().Count;
                if (r > 0) //Es un codigo de reserva
                {
                    Navigation.PushAsync(new ReservasPage(0,documento.Text.Trim()));
                }
                else
                {
                    var c = App.Database.GetClientesAsync().Result.Where(x => x.Cedula == Convert.ToInt32(documento.Text.Trim())).ToList().Count;
                    if (c > 0)
                    {
                        Navigation.PushAsync(new ReservasPage(Convert.ToInt32(documento.Text.Trim()),""));
                    }
                    else
                    {
                        DisplayAlert("Error", "Cedula o Codigo de reserva invalido", "OK");
                    }
                }
                
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
            
        }
    }
}