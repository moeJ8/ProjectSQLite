using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite
{
    public static class sharedPrice
    {
        [PrimaryKey, AutoIncrement]
        public static int ID { get; set; }
        public static int SelectedPrice { get; set; }

    }
}
