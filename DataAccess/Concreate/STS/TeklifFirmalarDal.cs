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
    public class TeklifFirmalarDal
    {
        static TeklifFirmalarDal teklifFirmalarDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private TeklifFirmalarDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(TeklifFirmalar entity, string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTopFirEkle", new SqlParameter("@t1", entity.T1), new SqlParameter("@t2", entity.T2),
                    new SqlParameter("@t3", entity.T3), new SqlParameter("@fa1", entity.Fa1), new SqlParameter("@fa2", entity.Fa2), new SqlParameter("@fa3", entity.Fa3),
                    new SqlParameter("@fi1", entity.Fi1), new SqlParameter("@fi2", entity.Fi2), new SqlParameter("@fi3", entity.Fi3), new SqlParameter("@fn1", entity.Fn1),
                    new SqlParameter("@fn2", entity.Fn2), new SqlParameter("@fn3", entity.Fn3), new SqlParameter("@siparisno", siparisNo));

                dataReader.Close();
                return "Bilgiler Başarıyla Kaydedildi.";
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

        public TeklifFirmalar Get(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Kullanma
        /// </summary>
        /// <param name="siparisNo">Sipariş No Bilgisi</param>
        /// <returns>Teklif Firma Listesi</returns>
        public List<TeklifFirmalar> GetList(string siparisNo)
        {
            try
            {
                List<TeklifFirmalar> teklifFirmalars = new List<TeklifFirmalar>();
                dataReader = sqlServices.StoreReader("SatTopFirListele", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    teklifFirmalars.Add(new TeklifFirmalar(dataReader["ID"].ConInt(), dataReader["T1"].ConInt(), dataReader["T2"].ConInt(),
                         dataReader["T3"].ConInt(), dataReader["FA1"].ToString(), dataReader["FA2"].ToString(), dataReader["FA3"].ToString(),
                         dataReader["FI1"].ToString(), dataReader["FI2"].ToString(), dataReader["FI3"].ToString(), dataReader["FN1"].ToString(),
                         dataReader["FN2"].ToString(), dataReader["FN3"].ToString(), dataReader["SiparisNo"].ToString()));
                }
                dataReader.Close();
                return teklifFirmalars;
            }
            catch
            {
                return new List<TeklifFirmalar>();
            }
        }

        public string Update(TeklifFirmalar entity)
        {
            throw new NotImplementedException();
        }
        public static TeklifFirmalarDal GetInstance()
        {
            if (teklifFirmalarDal == null)
            {
                teklifFirmalarDal = new TeklifFirmalarDal();
            }
            return teklifFirmalarDal;
        }
        public List<TeklifFirmalar> TedarikciFirmalar(bool isExistAll)
        {
            try
            {
                bool control = true;
                List<TeklifFirmalar> firmalars = new List<TeklifFirmalar>();
                dataReader = sqlServices.StoreReader("FirmaName");
                while (dataReader.Read())
                {
                    if (!isExistAll && control)
                    {
                        if (dataReader["FIRMA_AD"].ToString() == "HEPSİ")
                        {
                            control = false;
                            continue;
                        }
                    }
                    firmalars.Add(new TeklifFirmalar(dataReader["FIRMA_AD"].ToString()));
                }
                dataReader.Close();
                return firmalars;
            }
            catch (Exception)
            {
                return new List<TeklifFirmalar>();
            }
        }
    }
}
