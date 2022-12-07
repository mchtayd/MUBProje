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
    public class LogDal //: IRepository<Log>
    {
        static LogDal logDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private LogDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static LogDal GetInstance()
        {
            if (logDal == null)
            {
                logDal = new LogDal();
            }
            return logDal;
        }

        public string Add(Log entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("LogAdd",
                    new SqlParameter("@baslik", entity.Baslik),
                    new SqlParameter("@icerik", entity.Icerik),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@kullanici", entity.Kullainici),
                    new SqlParameter("@sorumluId", entity.SorumluId));

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

        public Log Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Log> GetList(string kullaniciId)
        {
            try
            {
                List<Log> logs = new List<Log>();
                kullaniciId = "%" + kullaniciId + "%";
                dataReader = sqlServices.StoreReader("LogList", new SqlParameter("@kullaniciId", kullaniciId));
                while (dataReader.Read())
                {
                    logs.Add(new Log(
                        dataReader["ID"].ConInt(),
                        dataReader["BASLIK"].ToString(),
                        dataReader["ICERIK"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["KULLANICI"].ToString(),
                        dataReader["SORUMLU_ID"].ToString()));
                }
                dataReader.Close();
                return logs;
            }
            catch (Exception)
            {
                return new List<Log>();
            }
        }

        public string Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
