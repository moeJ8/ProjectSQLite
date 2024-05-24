using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.Models
{
    public class UniversityClass
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Major { get; set; }
        public decimal Price { get; set; }
    }
}
