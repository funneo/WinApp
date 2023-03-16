using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class NhanVien:Auditable
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string ThongTinLienHe { get; set; }
        public string NgaySinh { get; set; }
        public int? IdChiNhanh { get; set; }
        public int? IdDaiLy { get; set; }      
        public byte? GioiTinh { get; set; }
        public string NgayThuViec { get; set; }
        public string NgayChinhThuc { get; set; }
        public string GhiChu { get; set; }
    }
}
