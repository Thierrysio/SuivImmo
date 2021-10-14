using SuivImmo.Models;
using SuivImmo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SuivImmo.ViewModels
{
    class BiensViewModel : BaseViewModel
    {
        #region Constructeurs
        public BiensViewModel()
        {
            CommandeButtonListeBiens = new Command(ActionButtonListeBiens);
        }

        #endregion
        #region Gettesr Setters
        public ICommand CommandeButtonListeBiens { get; }
        #endregion
        #region methodes

        public void ActionButtonListeBiens()
        {
            Application.Current.MainPage = new NavigationPage(new ListeBiensView());
        }
        public async void test()
        {
            Villes v = new Villes();
            v.Nom = "Pleubian";
            v.CodePostal = "22610";

            await App.Database.SaveItemAsync<Villes>( v ,0);
            List<Villes> _maListe= await App.Database.GetItemsAsync<Villes>();
            v = await App.Database.GetItemAsync<Villes>(8);
            //await App.Database.DeleteItemAsync<Villes>(v);
        }
        #endregion

    }
}
