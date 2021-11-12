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
    public class SehiriciGorevDal // : IRepository<SehiriciGorev>
    {
        static SehiriciGorevDal sehirici;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SehiriciGorevDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SehiriciGorev entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SehiriciGorev",
                    new SqlParameter("@isakisno", entity.Isakisno),
                    new SqlParameter("@gidilecekyer", entity.Gidilecekyer),
                    new SqlParameter("@gorevinkonusu", entity.Gorevinkonusu),
                    new SqlParameter("@baslamatarihi", entity.Baslamatarihi),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@masrafyerino", entity.Masrafyerno),
                    new SqlParameter("@bolum", entity.Masrafyeri),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@islemadimi", entity.Islemadimi),
                    new SqlParameter("@personelid", entity.Personelid),
                    new SqlParameter("@unvani", entity.Unvani));
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
                dataReader = sqlServices.StoreReader("SehiriciGorevSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SehiriciGorev Get(int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SehiriciGorevList", new SqlParameter("@isakisno", isakisno));
                SehiriciGorev item = null;
                while (dataReader.Read())
                {
                    item = new SehiriciGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConTime(),
                        dataReader["BITIS_TARIHI"].ConTime(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["SAYFA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SehiriciGorev> GetList(int isakisno)
        {
            try
            {
                List<SehiriciGorev> sehiriciGorevs = new List<SehiriciGorev>();
                dataReader = sqlServices.StoreReader("SehiriciGorevList", new SqlParameter("@isakisno", isakisno));
                while (dataReader.Read())
                {
                    sehiriciGorevs.Add(new SehiriciGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConTime(),
                        dataReader["BITIS_TARIHI"].ConTime(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["SAYFA"].ToString()));
                }
                dataReader.Close();
                return sehiriciGorevs;
            }
            catch (Exception)
            {
                return new List<SehiriciGorev>();
            }
        }
        public List<SehiriciGorev> PersonelOnay(string islemadimi, int personelid)
        {
            try
            {
                List<SehiriciGorev> sehiriciGorevs = new List<SehiriciGorev>();
                dataReader = sqlServices.StoreReader("SehirIciGorevPersonelList", new SqlParameter("@islemadimi", islemadimi),
                    new SqlParameter("@personelid", personelid));
                while (dataReader.Read())
                {
                    sehiriciGorevs.Add(new SehiriciGorev(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConTime(),
                        dataReader["BITIS_TARIHI"].ConTime(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["SAYFA"].ToString()));
                }
                dataReader.Close();
                return sehiriciGorevs;
            }
            catch (Exception)
            {
                return new List<SehiriciGorev>();
            }
        }
        public List<SehiriciGorev> AmirOnay(string islemadimi, int loginid)
        {
            try
            {
                List<SehiriciGorev> sehiriciGorevs = new List<SehiriciGorev>();
                dataReader = sqlServices.StoreReader("SehirIciGorevAmirList", new SqlParameter("@islemadimi", islemadimi),
                    new SqlParameter("@loginid", loginid));
                while (dataReader.Read())
                {
                    sehiriciGorevs.Add(new SehiriciGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConTime(),
                        dataReader["BITIS_TARIHI"].ConTime(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["SAYFA"].ToString()));
                }
                dataReader.Close();
                return sehiriciGorevs;
            }
            catch (Exception)
            {
                return new List<SehiriciGorev>();
            }
        }
        public List<SehiriciGorev> DevamEdenler()
        {
            try
            {
                List<SehiriciGorev> sehiriciGorevs = new List<SehiriciGorev>();
                dataReader = sqlServices.StoreReader("SehirIciGorevDevamEdenIzleme");
                while (dataReader.Read())
                {
                    sehiriciGorevs.Add(new SehiriciGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GIDILECEK_YER"].ToString(),
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        dataReader["BASLAMA_TARIHI"].ConTime(),
                        dataReader["BITIS_TARIHI"].ConTime(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["SAYFA"].ToString()));
                }
                dataReader.Close();
                return sehiriciGorevs;
            }
            catch (Exception ex)
            {
                return new List<SehiriciGorev>();
            }
        }

        public string Update(SehiriciGorev entity, int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SehiriciGorevGuncelle",
                    new SqlParameter("@isakisno", isakisno),
                    new SqlParameter("@gidilecekyer", entity.Gidilecekyer),
                    new SqlParameter("@gorevinkonusu", entity.Gorevinkonusu),
                    new SqlParameter("@baslamatarihi", entity.Baslamatarihi),
                    new SqlParameter("@bitistarihi", entity.Bitistarihi),
                    new SqlParameter("@toplamsure", entity.Toplamsure),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@masrafyerino", entity.Masrafyerno),
                    new SqlParameter("@bolum", entity.Masrafyeri),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@islemadimi", entity.Islemadimi),
                    new SqlParameter("@unvani", entity.Unvani));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GorevOnay(SehiriciGorev entity, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SehirIciGorevOnayla",
                    new SqlParameter("@id", id),
                    new SqlParameter("@islemadimi", entity.Islemadimi));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GorevTamamla(SehiriciGorev entity, int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SehirIciGorevTamamla",
                    new SqlParameter("@isakisno", isakisno),
                    new SqlParameter("@bitistarihi", entity.Bitistarihi),
                    new SqlParameter("@toplamsure", entity.Toplamsure));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<SehiriciGorev> DevamDevamsizlik(string toplamsure)
        {
            try
            {
                List<SehiriciGorev> sehiriciGorevs = new List<SehiriciGorev>();
                dataReader = sqlServices.StoreReader("DevamSehirIciGorevList",new SqlParameter("@toplamsure",toplamsure));
                while (dataReader.Read())
                {
                    DateTime startDate = dataReader["BASLAMA_TARIHI"].ConTime();
                    string gecenSure = (DateTime.Now.Subtract(startDate)).ToString();
                    gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.'));

                    sehiriciGorevs.Add(new SehiriciGorev(
                        dataReader["GOREVIN_KONUSU"].ToString(),
                        startDate,
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        gecenSure));
                }
                dataReader.Close();
                return sehiriciGorevs;
            }
            catch (Exception ex)
            {
                return new List<SehiriciGorev>();
            }
        }
        public static SehiriciGorevDal GetInstance()
        {
            if (sehirici == null)
            {
                sehirici = new SehiriciGorevDal();
            }
            return sehirici;
        }
    }
}
