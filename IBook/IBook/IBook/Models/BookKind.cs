using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBook.Models
{
    public class BookKind
    {
        [PrimaryKey, AutoIncrement]
        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
    }
}
