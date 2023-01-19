using DataAccess.Abstract;
using DataAccess.Concreate;
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
    public class OtsPerfDal //: IRepository<OtsPerf>
    {
        static OtsPerfDal otsPerfDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private OtsPerfDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(OtsPerf entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OtsPerf Get(int id)
        {
            throw new NotImplementedException();
        }
        public string PersonelSicil(string sicil)
        {
            try
            {
                string adSoyad = "";
                dataReader = sqlServices.StoreReader("BolgeSorumlusuAdList", new SqlParameter("@sicil", sicil));
                while (dataReader.Read())
                {
                    adSoyad = dataReader["AD_SOYAD"].ToString();
                }
                dataReader.Close();
                return adSoyad;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<OtsPerf> GetList(string yil)
        {
            try
            {
                int yildanfalza;
                if (yil == "1990")
                {
                    yildanfalza = 2023;
                }
                else
                {
                    yildanfalza = yil.ConInt() + 1;
                }
                List<OtsPerf> otsPerves = new List<OtsPerf>();
                dataReader = sqlServices.StoreReader("OtsPerformans", new SqlParameter("@yil", yil), new SqlParameter("@yildanFalza", yildanfalza.ToString()));

                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["MUDEHALE_TARIH"].ConDate();
                    TimeSpan gecenSure = dataReader["ONARIM_TAMAM_TARIHI"].ConDate() - startDate;
                    int gun = gecenSure.TotalDays.ConInt();

                    string sure = gun.ToString() + " Gün";

                    otsPerves.Add(new OtsPerf(
                        dataReader["FORM_NO"].ConInt(),
                        dataReader["BILDIRIM_NO"].ToString(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["MUDEHALE_TARIH"].ConDate(),
                        dataReader["ONARIM_TAMAM_TARIHI"].ConDate(),
                        sure,
                        dataReader["BOLGE_ILCE"].ToString(),
                        dataReader["BOLGE_SORUMLU_SICIL"].ToString(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["PROJE"].ToString()));
                }

                dataReader.Close();
                return otsPerves;

            }
            catch (Exception ex)
            {
                return new List<OtsPerf>();
            }
        }
        //public List<string> 
        public List<OtsPerf> GetListAdimlar(string abfNo)
        {
            try
            {
                List<OtsPerf> otsPerves = new List<OtsPerf>();
                dataReader = sqlServices.StoreReader("OtsPerformansRapor", new SqlParameter("@abfNo", abfNo));

                while (dataReader.Read())
                {
                    int gecenSureDk = dataReader["gecen_sure"].ConInt();
                    int gecenSureGun = gecenSureDk / 1440;

                    otsPerves.Add(new OtsPerf(
                        dataReader["FORM_NO"].ConInt(),
                        dataReader["islem_adimi"].ToString(),
                        gecenSureGun));
                }

                dataReader.Close();
                return otsPerves;

            }
            catch (Exception ex)
            {
                return new List<OtsPerf>();
            }
        }
        public List<string> Yillar()
        {
            try
            {
                List<string> yillar = new List<string>();
                dataReader = sqlServices.StoreReader("OtsArizaTarihler");
                while (dataReader.Read())
                {
                    yillar.Add(dataReader[0].ToString());
                }
                dataReader.Close();
                return yillar;

            }
            catch (Exception)
            {
                return new List<string>();
            }
        }


        public string Update(OtsPerf entity)
        {
            throw new NotImplementedException();
        }
        public static OtsPerfDal GetInstance()
        {
            if (otsPerfDal == null)
            {
                otsPerfDal = new OtsPerfDal();
            }
            return otsPerfDal;
        }
    }
}
