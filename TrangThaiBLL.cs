using System.Collections.Generic;
using Covid19.DAL;

namespace Covid19.BLL
{
    public class TrangThaiBLL
    {
        private readonly TrangThaiDAL dal = new TrangThaiDAL();

        public List<TrangThai> GetAll()
        {
            return dal.GetAll();
        }
    }
}