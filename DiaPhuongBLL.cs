
using Covid19.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Covid19.BLL
{
    public class DiaPhuongDong
    {
        public string MaDP { get; set; } = "";
        public string TenDP { get; set; } = "";
        public int SoCaNhiemMoi { get; set; }
        public int MaTT { get; set; }
        public string TenTT { get; set; } = "";
    }

    public class DiaPhuongBLL
    {
        private readonly DiaPhuongDAL dal = new DiaPhuongDAL();

        public List<DiaPhuongDong> GetDanhSachHienThi()
        {
            return dal.GetAll().Select(d => new DiaPhuongDong
            {
                MaDP = d.MaDP,
                TenDP = d.TenDP,
                SoCaNhiemMoi = d.SoCaNhiemMoi,
                MaTT = d.MaTT,
                TenTT = d.TrangThai?.TenTT ?? ""
            }).ToList();
        }

        public List<TrangThai> GetDanhSachTrangThai()
        {
            using var db = new Covid19Context(
                new Microsoft.EntityFrameworkCore.DbContextOptions<Covid19Context>());

            return db.TrangThais.ToList();
        }

        public string CapNhat(
            string maDP,
            string tenDP,
            int soCaNhiemMoi,
            int maTT)
        {
            if (string.IsNullOrWhiteSpace(maDP) ||
                string.IsNullOrWhiteSpace(tenDP))
            {
                return "Vui lòng nhập đầy đủ mã và tên địa phương!";
            }

            maDP = maDP.Trim().ToUpper();
            tenDP = tenDP.Trim();

            if (maDP.Length != 3)
            {
                return "Mã địa phương phải có đúng 3 ký tự!";
            }

            if (soCaNhiemMoi < 0)
            {
                return "Số ca nhiễm mới không được âm!";
            }

            try
            {
                var diaPhuong = new DiaPhuong
                {
                    MaDP = maDP,
                    TenDP = tenDP,
                    SoCaNhiemMoi = soCaNhiemMoi,
                    MaTT = maTT
                };

                dal.Luu(diaPhuong);

                return "Cập nhật dữ liệu thành công!";
            }
            catch (Exception ex)
            {
                return "Không thể cập nhật dữ liệu: " + ex.Message;
            }
        }
    }
}
