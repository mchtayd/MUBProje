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
    public class IstenAyrilisDal
    {
        static IstenAyrilisDal istenAyrilisDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IstenAyrilisDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(IstenAyrilis entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IstenAyrilis",new SqlParameter("@adsoyad",entity.Adsoyad),new SqlParameter("@siparis",entity.Siparis),new SqlParameter("@sat",entity.Sat),new SqlParameter("@butcekodu",entity.Butcekodu),
                    new SqlParameter("@butcekalemi",entity.Butcekalemi),new SqlParameter("@sicil",entity.Sicil), new SqlParameter("@masrafyerino",entity.Masyerino),new SqlParameter("@masrafyeri",entity.Masrafyeri),
                    new SqlParameter("@sirketbolum",entity.Sirketbolum),
                    new SqlParameter("@sirketmail",entity.Sirketmail),new SqlParameter("@oficemail",entity.Oficemail),new SqlParameter("@sirketcep",entity.Sirketcep),new SqlParameter("@sirketkisakod",entity.Sirketkisakod),
                    new SqlParameter("@dahilino",entity.Dahilino),new SqlParameter("@isunvani",entity.Isunvani),new SqlParameter("@isegiristarihi",entity.Isegiristarihi),new SqlParameter("@istenayrilistarihi",entity.Istenayrilistarihi),
                    new SqlParameter("@istenayrilisnedeni",entity.Ayrilisnedeni),new SqlParameter("@istenayrilisaciklama",entity.Istenayrilisaciklama),new SqlParameter("@dosyayolu",entity.Dosyayolu),
                    new SqlParameter("@tc",entity.Tc),new SqlParameter("@hes",entity.Hes),new SqlParameter("@sigortasicilno",entity.Sigortasicilno),new SqlParameter("@ikametgah",entity.Ikametgah),new SqlParameter("@kan",entity.Kan),
                    new SqlParameter("@esad",entity.Esad),new SqlParameter("@estelefon",entity.Estelefon),new SqlParameter("@dogumtarihi",entity.Dogumtarihi),new SqlParameter("@medenidurumu",entity.Medenidurumu),
                    new SqlParameter("@esisdurumu",entity.Esisdurumu),new SqlParameter("@cocuksayisi",entity.Cocuksayisi),new SqlParameter("@dogumyeri",entity.Dogumyeri),new SqlParameter("@askerlikdurumu",entity.Askerlikdurumu),
                    new SqlParameter("@askerliksinifi",entity.Askerliksinifi),new SqlParameter("@rutbesi",entity.Rutbesi),new SqlParameter("@gorevi",entity.Gorevi),new SqlParameter("@gorevyeri",entity.Gorevyeri),new SqlParameter("@askerlikbastarihi",entity.Askerlikbastarihi),
                    new SqlParameter("@askerlikbittarihi",entity.Askerlikbittarihi),new SqlParameter("@tecilbittarihi",entity.Tecilbittarihi),new SqlParameter("@tecilsebebi",entity.Tecilsebebi),new SqlParameter("@muafnedeni",entity.Muafnedeni),
                    new SqlParameter("@okul",entity.Okul),new SqlParameter("@okulbolum",entity.Okulbolum),new SqlParameter("@dipnotu",entity.Dipnotu), new SqlParameter("@siparisno",entity.Siparisno));

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
            try
            {
                sqlServices.StoreReader("IstenAyrilisSil",new SqlParameter("@id",id));
                return "İşten Çıkarma İşlemi Başarıyla Gerçekleşmiştir";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IstenAyrilis Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IstenAyrilis> GetList(string tc)
        {
            try
            {
                List<IstenAyrilis> istenAyrilis = new List<IstenAyrilis>();
                dataReader = sqlServices.StoreReader("IstenAyrilisListele",new SqlParameter("@tc",tc));
                while (dataReader.Read())
                {
                    istenAyrilis.Add(new IstenAyrilis(dataReader["ID"].ConInt(),dataReader["AD_SOYAD"].ToString(), dataReader["SIPARIS"].ToString(), dataReader["SAT"].ToString(), dataReader["BUTCE_KODU"].ToString(),
                        dataReader["BUTCE_KALEMI"].ToString(), dataReader["SICIL"].ToString(), dataReader["MASRAF_YERI_NO"].ToString(), dataReader["MASRAF_YERI"].ToString(), dataReader["SIRKET_BOLUM"].ToString(),
                        dataReader["SIRKET_MAIL"].ToString(), dataReader["OFICE_MAIL"].ToString(), dataReader["SIRKETCEP"].ToString(), dataReader["SIRKET_KISAKOD"].ToString(), dataReader["DAHILI_NO"].ToString(), dataReader["IS_UNVANI"].ToString(),
                        dataReader["ISE_GIRIS_TARIHI"].ConTime(), dataReader["ISTEN_AYRILIS_TARIHI"].ConTime(), dataReader["ISTEN_AYRILIS_NEDENI"].ToString(), dataReader["ISTEN_AYRILIS_ACIKLAMA"].ToString(), dataReader["DosyaYolu"].ToString(),
                        dataReader["TC"].ToString(), dataReader["HES"].ToString(), dataReader["SIGORTA_SICIL_NO"].ToString(), dataReader["IKAMETGAH"].ToString(), dataReader["KAN"].ToString(), dataReader["ES_AD"].ToString(),
                        dataReader["ES_TELEFON"].ToString(), dataReader["DOGUM_TARIHI"].ConTime(), dataReader["MEDENI_DURUMU"].ToString(), dataReader["ES_IS_DURUMU"].ToString(), dataReader["COCUK_SAYISI"].ToString(), dataReader["DOGUM_YERI"].ToString(),
                        dataReader["ASKERLIK_DURUMU"].ToString(), dataReader["ASKERLIK_SINIFI"].ToString(), dataReader["RUTBESI"].ToString(), dataReader["GOREVI"].ToString(), dataReader["GOREV_YERI"].ToString(),dataReader["ASKERLIK_BAS_TARIHI"].ToString(), 
                        dataReader["ASKERLIK_BIT_TARIHI"].ToString(), dataReader["TECIL_BIT_TARIHI"].ToString(), dataReader["TECIL_SEBEBI"].ToString(), dataReader["MUAF_NEDENI"].ToString(), dataReader["OKUL"].ToString(), dataReader["OKUL_BOLUM"].ToString(),
                        dataReader["DIP_NOTU"].ToString(),dataReader["SiparisNo"].ToString()));
                }
                dataReader.Close();
                return istenAyrilis;
            }
            catch
            {
                return new List<IstenAyrilis>();
            }
        }

        public string Update(IstenAyrilis entity)
        {
            throw new NotImplementedException();
        }
        public static IstenAyrilisDal GetInstance()
        {
            if (istenAyrilisDal == null)
            {
                istenAyrilisDal = new IstenAyrilisDal();
            }
            return istenAyrilisDal;
        }
    }
}
