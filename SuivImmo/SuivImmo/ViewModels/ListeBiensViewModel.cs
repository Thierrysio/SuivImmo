using SuivImmo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuivImmo.ViewModels
{
    class ListeBiensViewModel : BaseViewModel
    {
        #region Attributs
        private List<Villes> _maListe;
        #endregion
        #region Constructeurs
        public ListeBiensViewModel()
        {
            Affichage();
        }
        #endregion
        #region Getters Setters
        public List<Villes> MaListe
        {
            get
            {

                return _maListe;
            }

            set
            {
                SetProperty(ref _maListe, value);
            }
        }
        #endregion
        #region methodes
        public async void Affichage()
        {
            MaListe = await App.Database.GetItemsAsync<Villes>();
        }
        #endregion
    }
}
