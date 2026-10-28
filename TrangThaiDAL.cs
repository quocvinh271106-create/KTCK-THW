using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Covid19.DAL
{
    public class TrangThaiDAL
    {
        public List<TrangThai> GetAll()
        {
            using var db = new Covid19Context();

            return db.TrangThais
                .AsNoTracking()
                .OrderBy(t => t.MaTT)
                .ToList();
        }
    }
}