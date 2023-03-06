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
    public class OtelDal //: IRepository<Otel>
    {
        static OtelDal otelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private OtelDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Otel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("OtelEkle",
                    new SqlParameter("@il",entity.Il),
                    new SqlParameter("@otel",entity.Oteladi));
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

        public Otel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Otel> GetList(string il)
        {
            try
            {
                List<Otel> otels = new List<Otel>();
                dataReader = sqlServices.StoreReader("OtelList", new SqlParameter("@il",il));
                while (dataReader.Read())
                {
                    otels.Add(new Otel(
                        dataReader["ID"].ConInt(),
                        dataReader["IL"].ToString(),
                        dataReader["OTEL"].ToString()));
                }
                dataReader.Close();
                return otels;
            }
            catch (Exception)
            {
                return new List<Otel>();
            }
        }

        public string Update(Otel entity)
        {
            throw new NotImplementedException();
        }
        public static OtelDal GetInstance()
        {
            if (otelDal == null)
            {
                otelDal = new OtelDal();
            }
            return otelDal;
        }
    }
}
