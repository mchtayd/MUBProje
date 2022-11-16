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

        public string Delete(int id)
        {
            try
            {
                sqlServices.Stored("BolgeGarantiBilgileriDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BolgeGaranti Get(int id)
        {
            throw new NotImplementedException();
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
            catch (Exception)
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
