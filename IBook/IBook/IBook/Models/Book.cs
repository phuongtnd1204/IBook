using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBook.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int MaSach { get; set; }
        public string Hinh { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }
    }
}
