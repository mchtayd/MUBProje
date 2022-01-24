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
    public class PersonelKayitDal
    {
        static PersonelKayitDal kayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private PersonelKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(PersonelKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelEkle", new SqlParameter("@adsoyad", entity.Adsoyad), new SqlParameter("@tc", entity.Tc), new SqlParameter("@heskodu", entity.Heskodu), new SqlParameter("@sigortasicilno", entity.Sigortasicilno),
                    new SqlParameter("@ikametgah", entity.Ikametgah), new SqlParameter("@kangrubu", entity.Kangrubu), new SqlParameter("@esad", entity.Esad), new SqlParameter("@estelefon", entity.Estelefon), new SqlParameter("@dogumtarihi", entity.Dogumtarihi),
                    new SqlParameter("@medenidurumu", entity.Medenidurumu), new SqlParameter("@esisdurumu", entity.Esisdurumu), new SqlParameter("@cocuksayisi", entity.Cocuksayisi), new SqlParameter("@dogumyeri", entity.Dogumyeri),
                    new SqlParameter("@okul", entity.Okul), new SqlParameter("@bolum", entity.Bolum), new SqlParameter("@diplomanotu", entity.Diplomanotu), new SqlParameter("@siparis", entity.Siparis), new SqlParameter("@sat", entity.Sat),
                    new SqlParameter("@butcekodu", entity.Butcekodu), new SqlParameter("@butcekalemi", entity.Butcekalemi), new SqlParameter("@sicil", entity.Sicil), new SqlParameter("@masrafyerino", entity.Masyerino),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri), new SqlParameter("@masrafyerisorumlusu",entity.MasrafYeriSorumlusu),new SqlParameter("@sirketbolum", entity.Sirketbolum), new SqlParameter("@sirketmail", entity.Sirketmail), new SqlParameter("@oficemail", entity.Oficemail), new SqlParameter("@sirketcep", entity.Sirketcep),
                    new SqlParameter("@sirketkisakod", entity.Sirketkisakod), new SqlParameter("@dahilino", entity.Dahilino), new SqlParameter("@isunvani", entity.Isunvani), new SqlParameter("@isegiristarihi", entity.Isegiristarihi),
                    new SqlParameter("@askerlikdurumu", entity.Askerlikdurumu), new SqlParameter("@askerliksinifi", entity.Askerliksinifi), new SqlParameter("@rutbesi", entity.Rubesi), new SqlParameter("@gorevi", entity.Gorevi),
                    new SqlParameter("@askerlikbastarihi", entity.Askerlikbastarihi), new SqlParameter("@askerlikbittarihi", entity.Askerlikbittarihi), new SqlParameter("@gorevyeri", entity.Gorevyeri),
                    new SqlParameter("@tecilbittarihi", entity.Tecilbittarihi), new SqlParameter("@tecilsebebi", entity.Tecilsebebi), new SqlParameter("@muafnedeni", entity.Muafnedeni),
                    new SqlParameter("@siparisno", entity.SiparisNo), new SqlParameter("@dosyayolu",entity.Dosyayolu),new SqlParameter("@fotoyolu",entity.Fotoyolu),new SqlParameter("@projeKodu",entity.ProjeKodu),new SqlParameter("@kgbNo",entity.KgbNo),new SqlParameter("@kgbTarihi",entity.KgbTarih));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string YetkiliEkle(int personelId, int yetkiliId)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YetkiliEkle",new SqlParameter("@personelId",personelId),new SqlParameter("@yetkiliId",yetkiliId));
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
            throw new NotImplementedException();
        }

        public PersonelKayit Get(int id,string personelAd)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelCek", new SqlParameter("@id", id),new SqlParameter("@personelAdi",personelAd));
                PersonelKayit item = null;
                while (dataReader.Read())
                {
                    item = new PersonelKayit(dataReader["ID"].ConInt(), dataReader["AD_SOYAD"].ToString(), dataReader["TC"].ToString(), dataReader["HES_KODU"].ToString(),
                        dataReader["SIGORTA_SICIL_NO"].ToString(), dataReader["IKEMATGAH"].ToString(), dataReader["KAN_GRUBU"].ToString(), dataReader["ES_AD"].ToString(),
                        dataReader["ES_TELEFON"].ToString(), dataReader["DOGUM_TARIHI"].ConTime(), dataReader["MEDENI_DURUMU"].ToString(), dataReader["ES_IS_DURUMU"].ToString(),
                        dataReader["COCUK_SAYISI"].ToString(), dataReader["DOGUM_YERI"].ToString(), dataReader["OKUL"].ToString(), dataReader["BOLUM"].ToString(), dataReader["DIPLOMA_NOTU"].ToString(),
                        dataReader["SIPARIS"].ToString(), dataReader["SAT"].ToString(), dataReader["BUTCE_KODU"].ToString(), dataReader["BUTCE_KALEMİ"].ToString(), dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(), dataReader["MASRAF_YERI"].ToString(), dataReader["MASRAF_YERI_SORUMLUSU"].ToString(),dataReader["SIRKET_BOLUM"].ToString(), dataReader["SIRKET_MAIL"].ToString(),
                        dataReader["OFICE_MAIL"].ToString(), dataReader["SIRKETCEP"].ToString(), dataReader["SIRKET_KISAKOD"].ToString(), dataReader["DAHİLİ_NO"].ToString(), dataReader["IS_UNVANI"].ToString(),
                        dataReader["ISE_GIRIS_TARIHI"].ConTime(), dataReader["ASKERLIK_DURUMU"].ToString(), dataReader["ASKERLIK_SINIF"].ToString(), dataReader["RUTBESI"].ToString(), dataReader["GOREVI"].ToString(),
                        dataReader["ASKERLIK_BAS_TARIHI"].ToString(), dataReader["ASKERLIK_BIT_TARIHI"].ToString(), dataReader["GOREV_YERI"].ToString(), dataReader["TECIL_BITIS_TARIHI"].ToString(), dataReader["TECIL_SEBEBI"].ToString(),
                        dataReader["MUAF_NEDENI"].ToString(),dataReader["SiparisNo"].ToString(),dataReader["DosyaYolu"].ToString(),
                        dataReader["FotoYolu"].ToString(),dataReader["PROJE_KODU"].ToString(),
                        dataReader["KGB_NO"].ToString(),
                        dataReader["KGB_TARIH"].ConTime());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<PersonelKayit> GetList(string siparisno)
        {
            try
            {
                List<PersonelKayit> sicilNos = new List<PersonelKayit>();
                dataReader = sqlServices.StoreReader("PersonelleriGoster", new SqlParameter("@siparisNo", siparisno));
                while (dataReader.Read())
                {
                    sicilNos.Add(new PersonelKayit(dataReader["ID"].ConInt(), dataReader["AD_SOYAD"].ToString(), dataReader["TC"].ToString(), dataReader["HES_KODU"].ToString(),
                        dataReader["SIGORTA_SICIL_NO"].ToString(), dataReader["IKEMATGAH"].ToString(), dataReader["KAN_GRUBU"].ToString(), dataReader["ES_AD"].ToString(),
                        dataReader["ES_TELEFON"].ToString(), dataReader["DOGUM_TARIHI"].ConTime(), dataReader["MEDENI_DURUMU"].ToString(), dataReader["ES_IS_DURUMU"].ToString(),
                        dataReader["COCUK_SAYISI"].ToString(), dataReader["DOGUM_YERI"].ToString(), dataReader["OKUL"].ToString(), dataReader["BOLUM"].ToString(), dataReader["DIPLOMA_NOTU"].ToString(),
                        dataReader["SIPARIS"].ToString(), dataReader["SAT"].ToString(), dataReader["BUTCE_KODU"].ToString(), dataReader["BUTCE_KALEMİ"].ToString(), dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(), dataReader["MASRAF_YERI"].ToString(), dataReader["MASRAF_YERI_SORUMLUSU"].ToString(), dataReader["SIRKET_BOLUM"].ToString(), dataReader["SIRKET_MAIL"].ToString(),
                        dataReader["OFICE_MAIL"].ToString(), dataReader["SIRKETCEP"].ToString(), dataReader["SIRKET_KISAKOD"].ToString(), dataReader["DAHİLİ_NO"].ToString(), dataReader["IS_UNVANI"].ToString(),
                        dataReader["ISE_GIRIS_TARIHI"].ConTime(), dataReader["ASKERLIK_DURUMU"].ToString(), dataReader["ASKERLIK_SINIF"].ToString(), dataReader["RUTBESI"].ToString(), dataReader["GOREVI"].ToString(),
                        dataReader["ASKERLIK_BAS_TARIHI"].ToString(), dataReader["ASKERLIK_BIT_TARIHI"].ToString(), dataReader["GOREV_YERI"].ToString(), dataReader["TECIL_BITIS_TARIHI"].ToString(), dataReader["TECIL_SEBEBI"].ToString(),
                        dataReader["MUAF_NEDENI"].ToString(), dataReader["SiparisNo"].ToString(),dataReader["DosyaYolu"].ToString(),
                        dataReader["FotoYolu"].ToString(), dataReader["PROJE_KODU"].ToString(), dataReader["KGB_NO"].ToString(),
                        dataReader["KGB_TARIH"].ConTime()));
                }
                dataReader.Close();
                return sicilNos;
            }
            catch
            {
                return new List<PersonelKayit>();
            }
        }
        public List<PersonelKayit> PersonelSiparis(string siparisno)
        {
            try
            {
                List<PersonelKayit> sicilNos = new List<PersonelKayit>();
                dataReader = sqlServices.StoreReader("SiparisPersoneller", new SqlParameter("@siparis", siparisno));
                while (dataReader.Read())
                {
                    sicilNos.Add(new PersonelKayit(
                        dataReader["ID"].ConInt(), dataReader["AD_SOYAD"].ToString(), dataReader["TC"].ToString(), dataReader["HES_KODU"].ToString(),
                        dataReader["SIGORTA_SICIL_NO"].ToString(), dataReader["IKEMATGAH"].ToString(), dataReader["KAN_GRUBU"].ToString(), dataReader["ES_AD"].ToString(),
                        dataReader["ES_TELEFON"].ToString(), dataReader["DOGUM_TARIHI"].ConTime(), dataReader["MEDENI_DURUMU"].ToString(), dataReader["ES_IS_DURUMU"].ToString(),
                        dataReader["COCUK_SAYISI"].ToString(), dataReader["DOGUM_YERI"].ToString(), dataReader["OKUL"].ToString(), dataReader["BOLUM"].ToString(), dataReader["DIPLOMA_NOTU"].ToString(),
                        dataReader["SIPARIS"].ToString(), dataReader["SAT"].ToString(), dataReader["BUTCE_KODU"].ToString(), dataReader["BUTCE_KALEMİ"].ToString(), dataReader["SICIL"].ToString(),
                        dataReader["MASRAF_YERI_NO"].ToString(), dataReader["MASRAF_YERI"].ToString(), dataReader["MASRAF_YERI_SORUMLUSU"].ToString(), dataReader["SIRKET_BOLUM"].ToString(), dataReader["SIRKET_MAIL"].ToString(),
                        dataReader["OFICE_MAIL"].ToString(), dataReader["SIRKETCEP"].ToString(), dataReader["SIRKET_KISAKOD"].ToString(), dataReader["DAHİLİ_NO"].ToString(), dataReader["IS_UNVANI"].ToString(),
                        dataReader["ISE_GIRIS_TARIHI"].ConTime(), dataReader["ASKERLIK_DURUMU"].ToString(), dataReader["ASKERLIK_SINIF"].ToString(), dataReader["RUTBESI"].ToString(), dataReader["GOREVI"].ToString(),
                        dataReader["ASKERLIK_BAS_TARIHI"].ToString(), dataReader["ASKERLIK_BIT_TARIHI"].ToString(), dataReader["GOREV_YERI"].ToString(), dataReader["TECIL_BITIS_TARIHI"].ToString(), dataReader["TECIL_SEBEBI"].ToString(),
                        dataReader["MUAF_NEDENI"].ToString(), dataReader["SiparisNo"].ToString(), dataReader["DosyaYolu"].ToString(),
                        dataReader["FotoYolu"].ToString(), dataReader["PROJE_KODU"].ToString(),
                        dataReader["KGB_NO"].ToString(),
                        dataReader["KGB_TARIH"].ConTime()));
                }
                dataReader.Close();
                return sicilNos;
            }
            catch(Exception ex)
            {
                return new List<PersonelKayit>();
            }
        }
        public string MevcutKadroArttir(string siparisno)
        {
            try
            {
                sqlServices.Stored("MevcutKadroArttir",new SqlParameter("@benzersiz",siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string MevcutKadroEksilt(string siparisno)
        {
            try
            {
                sqlServices.Stored("MevcutKadroEksilt", new SqlParameter("@benzersiz", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(PersonelKayit entity)
        {
            try
            {
                sqlServices.Stored("PersonelGuncelle", new SqlParameter("@adsoyad", entity.Adsoyad), new SqlParameter("@tc", entity.Tc), new SqlParameter("@heskodu", entity.Heskodu), new SqlParameter("@sigortasicilno", entity.Sigortasicilno),
                    new SqlParameter("@ikametgah", entity.Ikametgah), new SqlParameter("@kangrubu", entity.Kangrubu), new SqlParameter("@esad", entity.Esad), new SqlParameter("@estelefon", entity.Estelefon), new SqlParameter("@dogumtarihi", entity.Dogumtarihi),
                    new SqlParameter("@medenidurumu", entity.Medenidurumu), new SqlParameter("@esisdurumu", entity.Esisdurumu), new SqlParameter("@cocuksayisi", entity.Cocuksayisi), new SqlParameter("@dogumyeri", entity.Dogumyeri),
                    new SqlParameter("@okul", entity.Okul), new SqlParameter("@bolum", entity.Bolum), new SqlParameter("@diplomanotu", entity.Diplomanotu), new SqlParameter("@siparis", entity.Siparis), new SqlParameter("@sat", entity.Sat),
                    new SqlParameter("@butcekodu", entity.Butcekodu), new SqlParameter("@butcekalemi", entity.Butcekalemi), new SqlParameter("@sicil", entity.Sicil), new SqlParameter("@masrafyerino", entity.Masyerino),
                    new SqlParameter("@masrafyeri", entity.Masrafyeri), new SqlParameter("@masrafyerisorumlusu",entity.MasrafYeriSorumlusu),new SqlParameter("@sirketbolum", entity.Sirketbolum), new SqlParameter("@sirketmail", entity.Sirketmail), new SqlParameter("@oficemail", entity.Oficemail), new SqlParameter("@sirketcep", entity.Sirketcep),
                    new SqlParameter("@sirketkisakod", entity.Sirketkisakod), new SqlParameter("@dahilino", entity.Dahilino), new SqlParameter("@isunvani", entity.Isunvani), new SqlParameter("@isegiristarihi", entity.Isegiristarihi),
                    new SqlParameter("@askerlikdurumu", entity.Askerlikdurumu), new SqlParameter("@askerliksinifi", entity.Askerliksinifi), new SqlParameter("@rutbesi", entity.Rubesi), new SqlParameter("@gorevi", entity.Gorevi),
                    new SqlParameter("@askerlikbastarihi", entity.Askerlikbastarihi), new SqlParameter("@askerlikbittarihi", entity.Askerlikbittarihi), new SqlParameter("@gorevyeri", entity.Gorevyeri),
                    new SqlParameter("@tecilbittarihi", entity.Tecilbittarihi), new SqlParameter("@tecilsebebi", entity.Tecilsebebi), new SqlParameter("@muafnedeni", entity.Muafnedeni),new SqlParameter("@projeKodu",entity.ProjeKodu), new SqlParameter("@kgbNo", entity.KgbNo), new SqlParameter("@kgbTarihi", entity.KgbTarih));
                
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static PersonelKayitDal GetInstance()
        {
            if (kayitDal == null)
            {
                kayitDal = new PersonelKayitDal();
            }
            return kayitDal;
        }
        public object[] GuncellenecekPers(string AdSoyad)
        {
            try
            {
                object[] infoss = null;
                dataReader = sqlServices.StoreReader("PersonelGunList", new SqlParameter("@adsoyad", AdSoyad));
                if (dataReader.Read())
                {
                    int id; string isim, tc, heskodu, sigortasicilno, ikametgah, kan, esad, estelefon, medenidurumu, esisdurumu, cocuksayisi, dogumyeri, okul, bolum, dipnotu, siparis, sat,
                        butcekodu, butcekalemi, sicil, masrafyerino, masrafyeri, sirketbolum, sirketmail, oficemail, sirketcep, sirketkısakod, dahilino, isunvani, askerlikdurumu,
                        askerliksinifi, rutbesi, gorevi, gorevyeri, tecilsebebi, muafnedeni, siparisnumarasi;
                    DateTime dogumtarihi, isegiristarihi, askerlikbastarihi, askerlikbittarihi, tecilbittarihi;

                    id = dataReader["ID"].ConInt();
                    isim = dataReader["AD_SOYAD"].ToString();
                    tc = dataReader["TC"].ToString();
                    heskodu = dataReader["HES_KODU"].ToString();
                    sigortasicilno = dataReader["SIGORTA_SICIL_NO"].ToString();
                    ikametgah = dataReader["IKEMATGAH"].ToString();
                    kan = dataReader["KAN_GRUBU"].ToString();
                    esad = dataReader["ES_AD"].ToString();
                    estelefon = dataReader["ES_TELEFON"].ToString();
                    dogumtarihi = dataReader["DOGUM_TARIHI"].ConTime();
                    medenidurumu = dataReader["MEDENI_DURUMU"].ToString();
                    esisdurumu = dataReader["ES_IS_DURUMU"].ToString();
                    cocuksayisi = dataReader["COCUK_SAYISI"].ToString();
                    dogumyeri = dataReader["DOGUM_YERI"].ToString();
                    okul = dataReader["OKUL"].ToString();
                    bolum = dataReader["BOLUM"].ToString();
                    dipnotu = dataReader["DIPLOMA_NOTU"].ToString();
                    siparis = dataReader["SIPARIS"].ToString();
                    sat = dataReader["SAT"].ToString();
                    butcekodu = dataReader["BUTCE_KODU"].ToString();
                    butcekalemi = dataReader["BUTCE_KALEMİ"].ToString();
                    sicil = dataReader["SICIL"].ToString();
                    masrafyerino = dataReader["MASRAF_YERI_NO"].ToString();
                    masrafyeri = dataReader["MASRAF_YERI"].ToString();
                    sirketbolum = dataReader["SIRKET_BOLUM"].ToString();
                    sirketmail = dataReader["SIRKET_MAIL"].ToString();
                    oficemail = dataReader["OFICE_MAIL"].ToString();
                    sirketcep = dataReader["SIRKETCEP"].ToString();
                    sirketkısakod = dataReader["SIRKET_KISAKOD"].ToString();
                    dahilino = dataReader["DAHİLİ_NO"].ToString();
                    isunvani = dataReader["IS_UNVANI"].ToString();
                    isegiristarihi = dataReader["ISE_GIRIS_TARIHI"].ConTime();
                    askerlikdurumu = dataReader["ASKERLIK_DURUMU"].ToString();
                    askerliksinifi = dataReader["ASKERLIK_SINIF"].ToString();
                    rutbesi = dataReader["RUTBESI"].ToString();
                    gorevi = dataReader["GOREVI"].ToString();
                    askerlikbastarihi = dataReader["ASKERLIK_BAS_TARIHI"].ConTime();
                    askerlikbittarihi = dataReader["ASKERLIK_BIT_TARIHI"].ConTime();
                    gorevyeri = dataReader["GOREV_YERI"].ToString();
                    tecilbittarihi = dataReader["TECIL_BITIS_TARIHI"].ConTime();
                    tecilsebebi = dataReader["TECIL_SEBEBI"].ToString();
                    muafnedeni = dataReader["MUAF_NEDENI"].ToString();
                    siparisnumarasi = dataReader["SiparisNo"].ToString();


                    infoss = new object[] { id, isim, tc, heskodu, sigortasicilno, ikametgah, kan, esad, estelefon, dogumtarihi,medenidurumu,esisdurumu,cocuksayisi,dogumyeri,okul,bolum,dipnotu,siparis,sat,butcekodu,butcekalemi,sicil,masrafyerino,masrafyeri,sirketbolum,sirketmail,oficemail,sirketcep,sirketkısakod,dahilino,isunvani,askerlikbastarihi,askerlikbittarihi,gorevyeri, tecilbittarihi,tecilsebebi,muafnedeni,siparisnumarasi};
                }
                dataReader.Close();
                return infoss;
            }
            catch
            {
                return null;
            }
        }
        public PersonelKayit PersonelAmir(string adsoyad)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelMail", new SqlParameter("@isim", adsoyad));
                PersonelKayit item = null;
                while (dataReader.Read())
                {
                    item = new PersonelKayit(dataReader["OFICE_MAIL"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PersonelKayit PersonelProjeKodu(string adsoyad)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ProjeKoduCek", new SqlParameter("@adSoyad", adsoyad));
                PersonelKayit item = null;
                while (dataReader.Read())
                {
                    item = new PersonelKayit(dataReader["AD_SOYAD"].ToString(),dataReader["SIRKET_BOLUM"].ToString(),dataReader["PROJE_KODU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string PersonelSorumluDegistir(int personelId, int yetkiliId)
        {
            try
            {
                sqlServices.Stored("PersonelSorumlusuDegistir", new SqlParameter("@personelId", personelId), new SqlParameter("@yetkiliId", yetkiliId));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<PersonelKayit> PersonelAdSoyad()
        {
            try
            {
                List<PersonelKayit> personels = new List<PersonelKayit>();
                dataReader = sqlServices.StoreReader("PersonelAdSoyad");
                while (dataReader.Read())
                {
                    personels.Add(new PersonelKayit(dataReader["ID"].ConInt(), dataReader["AD_SOYAD"].ToString()));
                }
                dataReader.Close();
                return personels;
            }
            catch (Exception ex)
            {
                return new List<PersonelKayit>();
            }
        }
    }

}
