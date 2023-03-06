using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class BakimOnarimLogDal // : IRepository<BakimOnarimLog>
    {
        static BakimOnarimLogDal bakimOnarimLogDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private BakimOnarimLogDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(BakimOnarimLog entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimLogEkle",
                    new SqlParameter("@sayfa",entity.Sayfa),
                    new SqlParameter("@benzersiz",entity.Benzersiz),
                    new SqlParameter("@islem",entity.Islem),
                    new SqlParameter("@islemYapan",entity.IslemYapan),
                    new SqlParameter("@tarih",entity.Tarih));

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
            throw new NotImplementedException();
        }

        public BakimOnarimLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BakimOnarimLog> GetList(string sayfa,int benzersiz)
        {
            try
            {
                List<BakimOnarimLog> bakimOnarims = new List<BakimOnarimLog>();
                dataReader = sqlServices.StoreReader("BakimOnarimLogList",
                    new SqlParameter("@sayfa",sayfa),
                    new SqlParameter("@benzersiz",benzersiz));
                while (dataReader.Read())
                {
                    bakimOnarims.Add(new BakimOnarimLog(
                        dataReader["ID"].ConInt(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["BENZERSIZ"].ConInt(),
                        dataReader["ISLEM"].ToString(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["TARIH"].ConDate()));
                }
                dataReader.Close();
                return bakimOnarims;
            }
            catch (Exception)
            {
                return new List<BakimOnarimLog>();
            }
        }

        public string Update(BakimOnarimLog entity)
        {
            throw new NotImplementedException();
        }
        public static BakimOnarimLogDal GetInstance()
        {
            if (bakimOnarimLogDal == null)
            {
                bakimOnarimLogDal = new BakimOnarimLogDal();
            }
            return bakimOnarimLogDal;
        }
    }
}
