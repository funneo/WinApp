using Common.Enums;
using Data.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Models
{
    public class DaiLy: Auditable
    {
        #region **** SQL Query****
        public static readonly SqlQuery SQL_Insert = new SqlQuery("DaiLys_Insert", CommandType.StoredProcedure);
        public static readonly SqlQuery SQL_Update = new SqlQuery("DaiLys_Update", CommandType.StoredProcedure);
        public static readonly SqlQuery SQL_Delete = new SqlQuery("DaiLys_Delete", CommandType.StoredProcedure);
        public static readonly SqlQuery SQL_GetAll = new SqlQuery("DaiLys_GetAll", CommandType.StoredProcedure);
        public static readonly SqlQuery SQL_GetbyId = new SqlQuery("DaiLys_GetById", CommandType.StoredProcedure);
        public static readonly SqlQuery SQL_GetPaging = new SqlQuery("DaiLys_GetPaging", CommandType.StoredProcedure);
        #endregion

        public int Id { get; set; }
        public string TenDaiLy { get; set; }
        public string MaDaiLy { get; set; }
        public string DiaChi { get; set; }
        public string WebSite { get; set; }
        public string NguoiDaiDien { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public LoaiDaiLy? LoaiDaiLy { get; set; }
        public string GhiChu { get; set; }
        public int? SoLuongNguoiDung { get; set; }
        public float? ToaDoX { get; set; }
        public float? ToaDoY { get; set; }
        public string MoTa { get; set; }
        public string Logo { get; set; }       
    }
}
