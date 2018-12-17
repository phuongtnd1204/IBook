using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBook.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int MaNguoiDung { get; set; }
        public bool IsAdmin { get; set; }
        public string TenNguoiDung { get; set; }
        public string SoDienThoai { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }
}
