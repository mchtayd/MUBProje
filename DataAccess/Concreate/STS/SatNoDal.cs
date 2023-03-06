using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class SatNoDal
    {
        static SatNoDal satNoDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SatNoDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public int Add(SatNo entity)
        {
            try
            {
                int satNo = 0;
                dataReader = sqlServices.StoreReader("SatNoOlustur", new SqlParameter("@siparisno", entity.Siparisno));
                if (dataReader.Read())
                {
                    satNo = dataReader["SatNo"].ConInt();
                }
                dataReader.Close();
                return satNo;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatNo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatNo> GetList(string siparisno)
        {
            try
            {
                List<SatNo> satNos = new List<SatNo>();
                dataReader = sqlServices.StoreReader("SatNoGöster", new SqlParameter("@siparisno", siparisno));
                while (dataReader.Read())
                {
                    satNos.Add(new SatNo(dataReader["SAT_NO"].ConInt(), dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return satNos;
            }
            catch
            {
                return new List<SatNo>();
            }
        }

        public string Update(SatNo entity)
        {
            throw new NotImplementedException();
        }

        public static SatNoDal GetInstance()
        {
            if (satNoDal == null)
            {
                satNoDal = new SatNoDal();
            }
            return satNoDal;
        }
        public object[] Deneme(string siparisno)
        {
            try
            {
                object[] infos2 = null;
                dataReader = sqlServices.StoreReader("SatNoGöster", new SqlParameter("@siparisno", siparisno));
                if (dataReader.Read())
                {
                    int satno;
                    satno = dataReader["SAT_NO"].ConInt();

                    infos2 = new object[] { satno };
                }
                dataReader.Close();
                return infos2;
            }
            catch
            {
                return null;
            }
        }

    }
}
