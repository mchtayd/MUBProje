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
    public class UcakOtobusDal // : IRepository<UcakOtobus>
    {
        static UcakOtobusDal ucakOtobusDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private UcakOtobusDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(UcakOtobus entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("UcakOtobusEkle",
                    new SqlParameter("@isakisno",entity.Isakisno),
                    new SqlParameter("@talepturu", entity.Talepturu),
                    new SqlParameter("@gorevformno", entity.Gorevformno),
                    new SqlParameter("@izinformno", entity.Izinformno),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri),
                    new SqlParameter("@gorevi", entity.Gorevi),
                    new SqlParameter("@tc", entity.Tc),
                    new SqlParameter("@hes", entity.Hes),
                    new SqlParameter("@email", entity.Email),
                    new SqlParameter("@kisakod", entity.Kisakod),
                    new SqlParameter("@biletturu", entity.Biletturu),
                    new SqlParameter("@gidisfirma", entity.Gidisfirma),
                    new SqlParameter("@gidistarih", entity.Gidistarihi),
                    new SqlParameter("@gidisnerden", entity.Gidisnereden),
                    new SqlParameter("@gidisnereye", entity.Gidisnereye),
                    new SqlParameter("@donusfirma", entity.Donusfirma),
                    new SqlParameter("@donustarihi", entity.Donustarihi),
                    new SqlParameter("@donusnereden", entity.Donusnereden),
                    new SqlParameter("@donusnereye", entity.Donusnereye),
                    new SqlParameter("@islemadimi", entity.Islemadimi),
                    new SqlParameter("@dosyayolu",entity.Dosyayolu),
                    new SqlParameter("@butcekodu",entity.Butcekodu),
                    new SqlParameter("@toplamMaliyet",entity.ToplamMaliyet),
                    new SqlParameter("@biletSayisi",entity.BiletSayisi),
                    new SqlParameter("@satNo",entity.SatNo));

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
                dataReader = sqlServices.StoreReader("UcakOtobusSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public UcakOtobus Get(int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("UcakOtobusList", new SqlParameter("@isakisno", isakisno));
                UcakOtobus item = null;
                while (dataReader.Read())
                {
                    item = new UcakOtobus(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["TALEP_TURU"].ToString(),
                        dataReader["GOREV_FORM_NO"].ToString(),
                        dataReader["IZIN_FORM_NO"].ToString(),
                        dataReader["BUTCE_KODU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["GOREVI"].ToString(),
                        dataReader["TC_NO"].ToString(),
                        dataReader["HES_KODU"].ToString(),
                        dataReader["E_MAIL"].ToString(),
                        dataReader["KISAKOD"].ToString(),
                        dataReader["BILET_TURU"].ToString(),
                        dataReader["GIDIS_FIRMA"].ToString(),
                        dataReader["GIDIS_TARIHI_SAATI"].ConDate(),
                        dataReader["GIDIS_NEREDEN"].ToString(),
                        dataReader["GIDIS_NEREYE"].ToString(),
                        dataReader["DONUS_FIRMA"].ToString(),
                        dataReader["DONUS_TARIHI_SAATI"].ConDate(),
                        dataReader["DONUS_NEREDEN"].ToString(),
                        dataReader["DONUS_NEREYE"].ToString(),
                        dataReader["TOPLAM_MALIYET"].ConDouble(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["BILET_SAYISI"].ConInt(),
                        dataReader["SAT_NO"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("UcakOtobusDuzenle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@isAkisNo", isAkisNo),
                    new SqlParameter("@dosyaYolu", dosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<UcakOtobus> GetList(int isakisno)
        {
            try
            {
                List<UcakOtobus> ucakOtobus = new List<UcakOtobus>();
                dataReader = sqlServices.StoreReader("UcakOtobusList", new SqlParameter("@isakisno", isakisno));
                while (dataReader.Read())
                {
                    ucakOtobus.Add(new UcakOtobus(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["TALEP_TURU"].ToString(),
                        dataReader["GOREV_FORM_NO"].ToString(),
                        dataReader["IZIN_FORM_NO"].ToString(),
                        dataReader["BUTCE_KODU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["GOREVI"].ToString(),
                        dataReader["TC_NO"].ToString(),
                        dataReader["HES_KODU"].ToString(),
                        dataReader["E_MAIL"].ToString(),
                        dataReader["KISAKOD"].ToString(),
                        dataReader["BILET_TURU"].ToString(),
                        dataReader["GIDIS_FIRMA"].ToString(),
                        dataReader["GIDIS_TARIHI_SAATI"].ConDate(),
                        dataReader["GIDIS_NEREDEN"].ToString(),
                        dataReader["GIDIS_NEREYE"].ToString(),
                        dataReader["DONUS_FIRMA"].ToString(),
                        dataReader["DONUS_TARIHI_SAATI"].ConDate(),
                        dataReader["DONUS_NEREDEN"].ToString(),
                        dataReader["DONUS_NEREYE"].ToString(),
                        dataReader["TOPLAM_MALIYET"].ConDouble(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["BILET_SAYISI"].ConInt(),
                        dataReader["SAT_NO"].ConInt()));
                }
                dataReader.Close();
                return ucakOtobus;
            }
            catch (Exception)
            {
                return new List<UcakOtobus>();
            }
        }
        public List<UcakOtobus> OnayList(string islemadimi)
        {
            try
            {
                List<UcakOtobus> ucakOtobus = new List<UcakOtobus>();
                dataReader = sqlServices.StoreReader("UcakOtobusOnayList",new SqlParameter("@islemadimi",islemadimi));
                while (dataReader.Read())
                {
                    ucakOtobus.Add(new UcakOtobus(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["TALEP_TURU"].ToString(),
                        dataReader["GOREV_FORM_NO"].ToString(),
                        dataReader["IZIN_FORM_NO"].ToString(),
                        dataReader["BUTCE_KODU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["GOREVI"].ToString(),
                        dataReader["TC_NO"].ToString(),
                        dataReader["HES_KODU"].ToString(),
                        dataReader["E_MAIL"].ToString(),
                        dataReader["KISAKOD"].ToString(),
                        dataReader["BILET_TURU"].ToString(),
                        dataReader["GIDIS_FIRMA"].ToString(),
                        dataReader["GIDIS_TARIHI_SAATI"].ConDate(),
                        dataReader["GIDIS_NEREDEN"].ToString(),
                        dataReader["GIDIS_NEREYE"].ToString(),
                        dataReader["DONUS_FIRMA"].ToString(),
                        dataReader["DONUS_TARIHI_SAATI"].ConDate(),
                        dataReader["DONUS_NEREDEN"].ToString(),
                        dataReader["DONUS_NEREYE"].ToString(),
                        dataReader["TOPLAM_MALIYET"].ConDouble(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["BILET_SAYISI"].ConInt(),
                        dataReader["SAT_NO"].ConInt()));
                }
                dataReader.Close();
                return ucakOtobus;
            }
            catch (Exception)
            {
                return new List<UcakOtobus>();
            }
        }
        public string OnayGuncelle(UcakOtobus entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("UcakOtobusOnay", 
                    new SqlParameter("@id",id),
                    new SqlParameter("@islemadimi",entity.Islemadimi));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(UcakOtobus entity, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("UcakOtobusGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@talepturu", entity.Talepturu),
                    new SqlParameter("@gorevformno", entity.Gorevformno),
                    new SqlParameter("@izinformno", entity.Izinformno),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@adsoyad", entity.Adsoyad),
                    new SqlParameter("@masrafyerino", entity.Masrafyerino),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri),
                    new SqlParameter("@gorevi", entity.Gorevi),
                    new SqlParameter("@tc", entity.Tc),
                    new SqlParameter("@hes", entity.Hes),
                    new SqlParameter("@email", entity.Email),
                    new SqlParameter("@kisakod", entity.Kisakod),
                    new SqlParameter("@biletturu", entity.Biletturu),
                    new SqlParameter("@gidisfirma", entity.Gidisfirma),
                    new SqlParameter("@gidistarih", entity.Gidistarihi),
                    new SqlParameter("@gidisnerden", entity.Gidisnereden),
                    new SqlParameter("@gidisnereye", entity.Gidisnereye),
                    new SqlParameter("@donusfirma", entity.Donusfirma),
                    new SqlParameter("@donustarihi", entity.Donustarihi),
                    new SqlParameter("@donusnereden", entity.Donusnereden),
                    new SqlParameter("@donusnereye", entity.Donusnereye),
                    new SqlParameter("@islemadimi", entity.Islemadimi),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu),
                    new SqlParameter("@butcekodu", entity.Butcekodu),
                    new SqlParameter("@toplamMaliyet", entity.ToplamMaliyet),
                    new SqlParameter("@biletSayisi",entity.BiletSayisi),
                    new SqlParameter("@satNo",entity.SatNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static UcakOtobusDal GetInstance()
        {
            if (ucakOtobusDal == null)
            {
                ucakOtobusDal = new UcakOtobusDal();
            }
            return ucakOtobusDal;
        }
    }
}
