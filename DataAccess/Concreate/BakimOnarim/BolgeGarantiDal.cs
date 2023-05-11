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
    public class BolgeGarantiDal // : IRepository<BolgeGaranti>
    {
        static BolgeGarantiDal bolgeGarantiDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private BolgeGarantiDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static BolgeGarantiDal GetInstance()
        {
            if (bolgeGarantiDal == null)
            {
                bolgeGarantiDal = new BolgeGarantiDal();
            }
            return bolgeGarantiDal;
        }

        public string Add(BolgeGaranti entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeGarantiBilgileriAdd",
                    new SqlParameter("@garantiPaketi", entity.GarantiPaketi),
                    new SqlParameter("@garantiBaslama", entity.GarantiBaslama),
                    new SqlParameter("@garantiBitis", entity.GarantiBitis),
                    new SqlParameter("@toplamGarantiSuresi", entity.ToplamSure),
                    new SqlParameter("@siparisNo", entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisNo)
        {
            try
            {
                sqlServices.Stored("BolgeGarantiBilgileriDelete", new SqlParameter("@siparisNo", siparisNo));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BolgeGaranti Get(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeGarantiBilgileriList",new SqlParameter("@siparisNo", siparisNo));
                BolgeGaranti item = null;
                while (dataReader.Read())
                {
                    item = new BolgeGaranti(
                        dataReader["ID"].ConInt(),
                        dataReader["GARANTI_PAKETI"].ToString(),
                        dataReader["GARANTI_BASLAMA"].ConDate(),
                        dataReader["GARANTI_BITIS"].ConDate(),
                        dataReader["TOPLAM_GARANTI_SURESI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString());
                }

                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<BolgeGaranti> GetList(string siparisNo)
        {
            try
            {
                List<BolgeGaranti> bolgeGarantis = new List<BolgeGaranti>();
                dataReader = sqlServices.StoreReader("BolgeGarantiBilgileriList", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    bolgeGarantis.Add(new BolgeGaranti(
                        dataReader["ID"].ConInt(),
                        dataReader["GARANTI_PAKETI"].ToString(),
                        dataReader["GARANTI_BASLAMA"].ConDate(),
                        dataReader["GARANTI_BITIS"].ConDate(),
                        dataReader["TOPLAM_GARANTI_SURESI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return bolgeGarantis;
            }
            catch (Exception ex)
            {
                return new List<BolgeGaranti>();
            }
        }
        public List<BolgeGaranti> GetListTumu(string siparisNo)
        {
            try
            {
                List<BolgeGaranti> bolgeGarantis = new List<BolgeGaranti>();
                dataReader = sqlServices.StoreReader("BolgeGarantiBilgisi", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    bolgeGarantis.Add(new BolgeGaranti(
                        dataReader["ID"].ConInt(),
                        dataReader["GARANTI_PAKETI"].ToString(),
                        dataReader["GARANTI_BASLAMA"].ConDate(),
                        dataReader["GARANTI_BITIS"].ConDate(),
                        dataReader["TOPLAM_GARANTI_SURESI"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return bolgeGarantis;
            }
            catch (Exception ex)
            {
                return new List<BolgeGaranti>();
            }
        }

        public string Update(BolgeGaranti entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeGarantiBilgileriUpdate",
                    new SqlParameter("@garantiPaketi", entity.GarantiPaketi),
                    new SqlParameter("@garantiBaslama", entity.GarantiBaslama),
                    new SqlParameter("@garantiBitis", entity.GarantiBitis),
                    new SqlParameter("@toplamGarantiSuresi", entity.ToplamSure),
                    new SqlParameter("@id", entity.Id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
