using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBook.Models
{
    public class Author
    {
        [PrimaryKey, AutoIncrement]
        public int MaTacGia { get; set; }
        public string TenTacGia { get; set; }
    }
}
