using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuivImmo.Models
{
    public class Photos
    {
        #region Attributs
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Url { get; set; }

        [ForeignKey(typeof(Biens))]
        public int BiensId { get; set; }
        #endregion
    }
}
