using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.Models
{
    public class Applications
    {
        [PrimaryKey, AutoIncrement]
        public int ApplicationID { get; set; }
        public int StudentID { get; set; }
        public int UniversityID { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string UniversityName { get; set; }
        public string Major { get; set; }

    }
}
