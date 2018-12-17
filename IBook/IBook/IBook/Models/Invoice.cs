using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBook.Models
{
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int MaHoaDon { get; set; }

        public int MaNguoiDung { get; set; }
        public int NgayHoaDon { get; set; }
        public int TongTien { get; set; }
        public string DiaChi { get; set; }
    }
}
