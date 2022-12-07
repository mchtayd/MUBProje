using DataAccess.Abstract;
using DataAccess.Database;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class ReddedilenMalzemeDal //: IRepository<ReddedilenMalzeme>
    {
        static ReddedilenMalzemeDal reddedilenMalzemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ReddedilenMalzemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(ReddedilenMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatReddedilenMalzemelerEkle",
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim",entity.Birim),
                    new SqlParameter("@siparisno", entity.Siparisno));
                
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        

        public string Delete(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatReddedilenMalzemelerSil", new SqlParameter("@siparisno", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ReddedilenMalzeme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReddedilenMalzeme> GetList(string siparisno)
        {
            try
            {
                List<ReddedilenMalzeme> malzemes = new List<ReddedilenMalzeme>();
                dataReader = sqlServices.StoreReader("SatReddedilenMalzemelerListele", new SqlParameter("@siparisno", siparisno));
                while (dataReader.Read())
                {
                    malzemes.Add(new ReddedilenMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return malzemes;
            }
            catch (Exception)
            {
                return new List<ReddedilenMalzeme>();
            }
        }

        public string Update(ReddedilenMalzeme entity)
        {
            throw new NotImplementedException();
        }
        public static ReddedilenMalzemeDal GetInstance()
        {
            if (reddedilenMalzemeDal == null)
            {
                reddedilenMalzemeDal = new ReddedilenMalzemeDal();
            }
            return reddedilenMalzemeDal;
        }
    }
}
