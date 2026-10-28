
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Covid19.DAL
{
    public class DiaPhuongDAL
    {
        public List<DiaPhuong> GetAll()
        {
            using (var context = new Covid19Context())
            {
                return context.DiaPhuongs
                    .Include(d => d.TrangThai)
                    .AsNoTracking()
                    .ToList();
            }
        }

        public DiaPhuong? GetById(string maDP)
        {
            using (var context = new Covid19Context())
            {
                return context.DiaPhuongs
                    .Include(d => d.TrangThai)
                    .FirstOrDefault(d => d.MaDP == maDP);
            }
        }

        public void Luu(DiaPhuong diaPhuong)
        {
            using (var context = new Covid19Context())
            {
                var diaPhuongCu = context.DiaPhuongs
                    .FirstOrDefault(d => d.MaDP == diaPhuong.MaDP);

                if (diaPhuongCu == null)
                {
                    context.DiaPhuongs.Add(diaPhuong);
                }
                else
                {
                    diaPhuongCu.TenDP = diaPhuong.TenDP;
                    diaPhuongCu.SoCaNhiemMoi = diaPhuong.SoCaNhiemMoi;
                    diaPhuongCu.MaTT = diaPhuong.MaTT;
                }

                context.SaveChanges();
            }
        }

        public bool Xoa(string maDP)
        {
            using (var context = new Covid19Context())
            {
                var diaPhuong = context.DiaPhuongs
                    .FirstOrDefault(d => d.MaDP == maDP);

                if (diaPhuong == null)
                    return false;

                context.DiaPhuongs.Remove(diaPhuong);
                context.SaveChanges();

                return true;
            }
        }
    }
}
