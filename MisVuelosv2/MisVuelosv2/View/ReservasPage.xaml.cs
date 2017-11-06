using MisVuelosv2.ViewModel;
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
    public partial class ReservasPage : ContentPage
    {
        public ReservasPage(int ci = 0 , string reserva = "")
        {
            InitializeComponent();
            BindingContext = new ReservasPageViewModel(ci,reserva);
        }

        private void btn_volver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}