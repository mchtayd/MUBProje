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
    public class BolgeNotDal //: IRepository<BolgeNot>
    {
        static BolgeNotDal bolgeNotDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private BolgeNotDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static BolgeNotDal GetInstance()
        {
            if (bolgeNotDal == null)
            {
                bolgeNotDal = new BolgeNotDal();
            }
            return bolgeNotDal;
        }

        public string Add(BolgeNot entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeNotlarAdd",
                    new SqlParameter("@benzersizId", entity.BenzerisizId),
                    new SqlParameter("@kayitYapan", entity.KayitYapan),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@notlar", entity.Not));
                
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int benzersizId)
        {
            try
            {
                sqlServices.Stored("BolgeNotlarDelete", new SqlParameter("@benzersizId", benzersizId));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BolgeNot Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BolgeNot> GetList(int benzersizId)
        {
            try
            {
                List<BolgeNot> list = new List<BolgeNot>();
                dataReader = sqlServices.StoreReader("BolgeNotlarList", new SqlParameter("@benzersizId", benzersizId));
                while (dataReader.Read())
                {
                    list.Add(new BolgeNot(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["NOTLAR"].ToString()));
                }
                dataReader.Close();
                return list;
            }
            catch (Exception)
            {
                return new List<BolgeNot>();
            }
        }

        public string Update(BolgeNot entity)
        {
            throw new NotImplementedException();
        }
    }
}
