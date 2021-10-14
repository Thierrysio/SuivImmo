using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuivImmo.Models
{
    public class EvolutionPrix
    {
        #region Attributs
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Prix { get; set; }
        public DateTime DatePrix { get; set; }

        [ForeignKey(typeof(Biens))] 
        public int BiensId { get; set; }
        #endregion
    }
}
