using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Butce
{
    public class KasaDal //: IRepository<Kasa>
    {
        static KasaDal kasaDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private KasaDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Kasa entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("VadesizHesapEkle",
                    new SqlParameter("@hesapSahibi",entity.HesapSahibi),
                    new SqlParameter("@musteriNumarasi",entity.MusteriNumarasi),
                    new SqlParameter("@dovizCinsi",entity.DovizCinsi),
                    new SqlParameter("@subeAdi",entity.SubeAdi),
                    new SqlParameter("@hesapNumarasi",entity.HesapNumarasi),
                    new SqlParameter("@iban",entity.Iban));

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
                sqlServices.Stored("VadesizHesapSil",new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Kasa Get(string hesapSahibi)
        {
            try
            {
                dataReader = sqlServices.StoreReader("VadesizHesapListele",new SqlParameter("@hesapSahibi",hesapSahibi));
                Kasa item = null;
                while (dataReader.Read())
                {
                    item = new Kasa(
                        dataReader["ID"].ConInt(),
                        dataReader["HESAP_SAHIBI"].ToString(),
                        dataReader["MUSTERI_NUMARASI"].ToString(),
                        dataReader["DOVIZ_CINSI"].ToString(),
                        dataReader["SUBE_ADI"].ToString(),
                        dataReader["HESAP_NUMARASI"].ToString(),
                        dataReader["IBAN"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Kasa> GetList()
        {
            try
            {
                List<Kasa> kasas = new List<Kasa>();
                dataReader = sqlServices.StoreReader("VadesizHesapListele");
                while (dataReader.Read())
                {
                    kasas.Add(new Kasa(dataReader["ID"].ConInt(),
                        dataReader["HESAP_SAHIBI"].ToString(),
                        dataReader["MUSTERI_NUMARASI"].ToString(),
                        dataReader["DOVIZ_CINSI"].ToString(),
                        dataReader["SUBE_ADI"].ToString(),
                        dataReader["HESAP_NUMARASI"].ToString(),
                        dataReader["IBAN"].ToString()));
                }
                dataReader.Close();
                return kasas;
            }
            catch (Exception)
            {
                return new List<Kasa>();
            }
        }

        public string Update(Kasa entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("VadesizHesapGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@hesapSahibi", entity.HesapSahibi),
                    new SqlParameter("@musteriNumarasi", entity.MusteriNumarasi),
                    new SqlParameter("@dovizCinsi", entity.DovizCinsi),
                    new SqlParameter("@subeAdi", entity.SubeAdi),
                    new SqlParameter("@hesapNumarasi", entity.HesapNumarasi),
                    new SqlParameter("@iban", entity.Iban));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static KasaDal GetInstance()
        {
            if (kasaDal == null)
            {
                kasaDal = new KasaDal();
            }
            return kasaDal;
        }
    }
}
