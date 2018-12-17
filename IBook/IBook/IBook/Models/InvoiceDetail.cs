using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBook.Models
{
    public class InvoiceDetail
    {
        [SQLite.PrimaryKey, AutoIncrement]
        public int MaHoaDon { get; set; }

        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
    }
}
