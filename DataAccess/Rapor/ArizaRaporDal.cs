using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Rapor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Rapor
{
    public class ArizaRaporDal //: IRepository<ArizaRapor>
    {
        static ArizaRaporDal arizaRaporDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ArizaRaporDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(ArizaRapor entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArizaRapor Get(string bildirimNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArizaRaporFormNoCek", new SqlParameter("@bildirimNo", bildirimNo));
                ArizaRapor item = null;
                while (dataReader.Read())
                {
                    item = new ArizaRapor(dataReader["FORM_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ArizaRapor> GetList()
        {
            try
            {
                List<ArizaRapor> arizaRapors = new List<ArizaRapor>();
                dataReader = sqlServices.StoreReader("ArizaRapor");
                while (dataReader.Read())
                {
                    arizaRapors.Add(new ArizaRapor(dataReader["BILDIRIM_TURU"].ToString(), dataReader["BILDIRIM_NO"].ToString(), "", dataReader["PROJE"].ToString(),
                        dataReader["STOK_NO_GIREN"].ToString(), dataReader["TANIM"].ToString(), dataReader["BILDIRIM_TARIH"].ToString(),
                        dataReader["MUDEHALE_TARIH"].ToString(),
                        dataReader["ONARIM_TAMAM_TARIHI"].ToString(), dataReader["BOLGE_ADI"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MIKTAR"].ToString()));             
                }
                dataReader.Close();
                return arizaRapors;

            }
            catch (Exception)
            {

                return new List<ArizaRapor>();
            }
        }

        public string Update(ArizaRapor entity)
        {
            throw new NotImplementedException();
        }
        public static ArizaRaporDal GetInstance()
        {
            if (arizaRaporDal == null)
            {
                arizaRaporDal = new ArizaRaporDal();
            }
            return arizaRaporDal;
        }
    }
}
