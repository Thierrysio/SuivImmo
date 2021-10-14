using SuivImmo.Services;
using SuivImmo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SuivImmo
{
    public partial class App : Application
    {
        static GestionDatabase database;

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "Shapes_Experimental" });
            MainPage = new GestionPhotosView();
        }

        public static GestionDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GestionDatabase();
                }
                return database;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
