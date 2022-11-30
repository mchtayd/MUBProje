using DataAccess.Abstract;
using DataAccess.Database;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.AnaSayfa
{
    public class DuyuruDal //: IRepository<Duyuru>
    {
        static DuyuruDal duyuruDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DuyuruDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Duyuru entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DuyuruAdd",
                    new SqlParameter("@konu", entity.Konu),
                    new SqlParameter("@duyuruMesaj", entity.DuyuruMesaj),
                    new SqlParameter("@tarihBaslangic", entity.BaslangicTarih),
                    new SqlParameter("@tarihBitis", entity.BitisTarih),
                    new SqlParameter("@durum", entity.Durum));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                sqlServices.Stored("DuyuruDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Duyuru Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Duyuru> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(Duyuru entity)
        {
            throw new NotImplementedException();
        }
        public static DuyuruDal GetInstance()
        {
            if (duyuruDal == null)
            {
                duyuruDal = new DuyuruDal();
            }
            return duyuruDal;
        }
    }
}
