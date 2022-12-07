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
    public class GorevlendirmeDal //: IRepository<Gorevlendirme>
    {
        static GorevlendirmeDal gorevlendirmeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private GorevlendirmeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(Gorevlendirme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevlendirmeAdd",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@adSoyad",entity.AdSoyad),
                    new SqlParameter("@unvani",entity.Unvani),
                    new SqlParameter("@tc",entity.Tc),
                    new SqlParameter("@il",entity.Il),
                    new SqlParameter("@ilce",entity.Ilce),
                    new SqlParameter("@tugay",entity.Tugay),
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@gorevlendirmeNedeni",entity.GorevlendirmeNedeni),
                    new SqlParameter("@basTarihi",entity.BasTarihi),
                    new SqlParameter("@bitTarihi",entity.BitTarihi),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu),
                    new SqlParameter("@durum",entity.Durum));

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
                sqlServices.Stored("GorevlendirmeDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Gorevlendirme Get(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevlendirmeList", new SqlParameter("@isAkisNo", isAkisNo));
                Gorevlendirme item = null;
                while (dataReader.Read())
                {
                    
                    TimeSpan gecenSure = dataReader["BIT_TARIHI"].ConDate() - dataReader["BAS_TARIHI"].ConDate();
                    int gun = gecenSure.TotalDays.ConInt();

                    string sure = gun.ToString() + " Gün";

                    item = new Gorevlendirme(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["TUGAY"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["GOREVLENDIRME_NEDENI"].ToString(),
                        dataReader["BAS_TARIHI"].ConDate(),
                        dataReader["BIT_TARIHI"].ConDate(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["DURUM"].ToString(),
                        sure);
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<string> Yillar()
        {
            try
            {
                List<string> yillar = new List<string>();
                dataReader = sqlServices.StoreReader("GorevlendirmeYillar");
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

        public List<Gorevlendirme> GetList(string durum, string yil)
        {
            try
            {
                int yildanfalza;
                if (yil == "1990")
                {
                    yildanfalza = 2022;
                }
                else
                {
                    yildanfalza = yil.ConInt() + 1;
                }

                List<Gorevlendirme> gorevlendirmes = new List<Gorevlendirme>();
                dataReader = sqlServices.StoreReader("GorevlendirmeList", new SqlParameter("@durum", durum), new SqlParameter("@yil", yil), new SqlParameter("@yildanFalza", yildanfalza.ToString()));

                while (dataReader.Read())
                {
                    TimeSpan gecenSure = dataReader["BIT_TARIHI"].ConDate() - dataReader["BAS_TARIHI"].ConDate();
                    int gun = gecenSure.TotalDays.ConInt();
                    string sure = gun.ToString() + " Gün";

                    gorevlendirmes.Add(new Gorevlendirme(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["TUGAY"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["GOREVLENDIRME_NEDENI"].ToString(),
                        dataReader["BAS_TARIHI"].ConDate(),
                        dataReader["BIT_TARIHI"].ConDate(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["DURUM"].ToString(),
                        sure));
                }
                dataReader.Close();
                return gorevlendirmes;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<Gorevlendirme>();
            }
        }

        public string Update(Gorevlendirme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevlendirmeUpdate",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@adSoyad", entity.AdSoyad),
                    new SqlParameter("@unvani", entity.Unvani),
                    new SqlParameter("@tc", entity.Tc),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@tugay", entity.Tugay),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@gorevlendirmeNedeni", entity.GorevlendirmeNedeni),
                    new SqlParameter("@basTarihi", entity.BasTarihi),
                    new SqlParameter("@bitTarihi", entity.BitTarihi),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevlendirmeDal GetInstance()
        {
            if (gorevlendirmeDal == null)
            {
                gorevlendirmeDal = new GorevlendirmeDal();
            }
            return gorevlendirmeDal;
        }
    }
}
