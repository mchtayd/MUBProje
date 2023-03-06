using DataAccess.Abstract;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class IdariIslerLogDal //: IRepository<IdariIslerLog>
    {
        static IdariIslerLogDal logDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IdariIslerLogDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IdariIslerLog entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IdarIslerLogKayit",
                    new SqlParameter("@sayfa",entity.Sayfa),
                    new SqlParameter("@benzersiz",entity.Benzersizid),
                    new SqlParameter("@islem",entity.Islem),
                    new SqlParameter("@islemyapan",entity.Islemyapan),
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

        public IdariIslerLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IdariIslerLog> GetList(string sayfa, int benzersizid)
        {
            try
            {
                List<IdariIslerLog> logs = new List<IdariIslerLog>();
                dataReader = sqlServices.StoreReader("IdarIslerLogList",new SqlParameter("@sayfa",sayfa),new SqlParameter("@benzersiz",benzersizid));
                while (dataReader.Read())
                {
                    logs.Add(new IdariIslerLog(
                        dataReader["ID"].ConInt(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["BENZERSIZ"].ConInt(),
                        dataReader["ISLEM"].ToString(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["TARIH"].ConDate()));
                }
                dataReader.Close();
                return logs;
            }
            catch (Exception)
            {
                return new List<IdariIslerLog>();
            }
        }

        public string Update(IdariIslerLog entity)
        {
            throw new NotImplementedException();
        }
        public static IdariIslerLogDal GetInstance()
        {
            if (logDal == null)
            {
                logDal = new IdariIslerLogDal();
            }
            return logDal;
        }
    }
}
