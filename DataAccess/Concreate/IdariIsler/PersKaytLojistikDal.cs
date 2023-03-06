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
    public class PersKaytLojistikDal
    {
        static PersKaytLojistikDal persKaytLojistikDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private PersKaytLojistikDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(PersKaytLojistik entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PersKaytLojistik Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersKaytLojistik> GetList(int indis)
        {
            try
            {
                List<PersKaytLojistik> persKayts = new List<PersKaytLojistik>();
                dataReader = sqlServices.StoreReader("PersKaytLojistikKirilim", new SqlParameter("@indis", indis));
                while (dataReader.Read())
                {
                    persKayts.Add(new PersKaytLojistik(dataReader["ID"].ConInt(), dataReader["BOLUM_3"].ToString(),
                        dataReader["BOLUM_ID"].ConInt()));
                }
                dataReader.Close();
                return persKayts;
            }
            catch(Exception)
            {
                return new List<PersKaytLojistik>();
            }
        }

        public string Update(PersKaytLojistik entity)
        {
            throw new NotImplementedException();
        }
        public static PersKaytLojistikDal GetInstance()
        {
            if (persKaytLojistikDal == null)
            {
                persKaytLojistikDal = new PersKaytLojistikDal();
            }
            return persKaytLojistikDal;
        }
    }
}
