using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuivImmo.Models
{
    public class Villes
    {
        #region Attributs
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nom { get; set; }
        public string CodePostal { get; set; }
        
        [OneToMany]
        public List<Biens> LesBiens { get; set; }
        #endregion
        #region methodes
        #endregion
    }
}
