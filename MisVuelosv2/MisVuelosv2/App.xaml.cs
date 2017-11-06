using MisVuelosv2.Model;
using MisVuelosv2.View;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace MisVuelosv2
{
    public partial class App : Application
    {
        static MisVuelosDataBase database;
        public static MisVuelosDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MisVuelosDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("MisVuelosv2.db3"));
                }
                return database;
            }
        }

        public Page ReservarPage { get; set; }

        public App()
        {
            InitializeComponent();
            IniciaVuelos.GetIniciaVuelos();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
