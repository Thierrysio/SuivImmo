using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuivImmo.Models
{
    public class Biens
    {
        #region Attributs
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Proprietaire { get; set; }
        public string Adresse { get; set; }
        public string Description { get; set; }
        public string Avis { get; set; }
        public bool Vendu { get; set; }
        
        [OneToMany] 
        public List<EvolutionPrix> LesPrix { get; set; }
        
        [OneToMany]
        public List<Photos> LesPhotos { get; set; }

        [ForeignKey(typeof(Villes))]
        public int VillesId { get; set; }
        #endregion
        #region methodes
        
        #endregion
    }
}
