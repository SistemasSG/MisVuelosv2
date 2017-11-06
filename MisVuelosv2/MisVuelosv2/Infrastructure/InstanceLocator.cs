using MisVuelosv2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisVuelosv2.Infrastructure
{

    public class InstaceLocator
    {
        public MainPageViewModel MainPage { get; set; }
        public InstaceLocator()
        {
            MainPage = new MainPageViewModel();
        }


    }
}
