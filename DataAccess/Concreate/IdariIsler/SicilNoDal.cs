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
    public class SicilNoDal
    {
        static SicilNoDal sicilNoDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private SicilNoDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SicilNo entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SicilNoOlustur", new SqlParameter("@siparisno", entity.Siparisno));
                dataReader.Close();
                return "";
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

        public SicilNo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SicilNo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(SicilNo entity)
        {
            throw new NotImplementedException();
        }
        public object[] Deneme(string siparisno)
        {
            try
            {
                object[] infos3 = null;
                dataReader = sqlServices.StoreReader("SicilNoGoster", new SqlParameter("@siparisno", siparisno));
                if (dataReader.Read())
                {
                    int satno;
                    satno = dataReader["SICIL_NO"].ConInt();

                    infos3 = new object[] { satno };
                }
                dataReader.Close();
                return infos3;
            }
            catch
            {
                return null;
            }

        }
        public static SicilNoDal GetInstance()
        {
            if (sicilNoDal == null)
            {
                sicilNoDal = new SicilNoDal();
            }
            return sicilNoDal;
        }
    }
}
