using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class PersonelKayitManager //: IRepository<PersonelKayit>
    {
        static PersonelKayitManager personelKayitManager;
        PersonelKayitDal personelKayitDal;
        string controlText;
        private PersonelKayitManager()
        {
            personelKayitDal = PersonelKayitDal.GetInstance();
        }

        public string Add(PersonelKayit entity)
        {
            try
            {
                controlText = IsPersonelKayitComplete(entity);
                if (controlText!="")
                {
                    return controlText;
                }
                return personelKayitDal.Add(entity);
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
                return personelKayitDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public PersonelKayit Get(int id=0, string personeAd="")
        {
            try
            {
                return personelKayitDal.Get(id, personeAd);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<PersonelKayit> GetMasrafYeriSorumlusuPer(string personeAd)
        {
            try
            {
                return personelKayitDal.GetMasrafYeriSorumlusuPer(personeAd);
            }
            catch
            {
                return new List<PersonelKayit>();
            }
        }

        public List<PersonelKayit> GetList(string siparisNo = "")
        {
            try
            {
                return personelKayitDal.GetList(siparisNo);
            }
            catch
            {
                return new List<PersonelKayit>();
            }
        }
        public List<PersonelKayit> SiparisPersonel(string siparis)
        {
            try
            {
                return personelKayitDal.SiparisPersonel(siparis);
            }
            catch
            {
                return new List<PersonelKayit>();
            }
        }
        public string YetkiliEkle(int personelId, int yetkiliId)
        {
            try
            {
                return personelKayitDal.YetkiliEkle(personelId, yetkiliId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<PersonelKayit> PersonelSiparis(string siparis)
        {
            try
            {
                return personelKayitDal.PersonelSiparis(siparis);
            }
            catch
            {
                return new List<PersonelKayit>();
            }
        }
        public string MevcutKadroArttir(string siparisno)
        {
            try
            {
                return personelKayitDal.MevcutKadroArttir(siparisno);
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
                return personelKayitDal.MevcutKadroEksilt(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<string> SirketBolumList()
        {
            try
            {
                return personelKayitDal.SirketBolumList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
        public string Update(PersonelKayit entity)
        {
            try
            {
                if (entity.Id<1)
                {
                    return "Lütfen Geçerli Bir Personel Giriniz.";
                }
                controlText = IsPersonelGuncelleComplete(entity);
                if (controlText!="")
                {
                    return controlText;
                }
                return personelKayitDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static PersonelKayitManager GetInstance()
        {
            if (personelKayitManager == null)
            {
                personelKayitManager = new PersonelKayitManager();
            }
            return personelKayitManager;
        }
        public object[] GuncellenecekPers(string AdSoyad)
        {
            try
            {
                return personelKayitDal.GuncellenecekPers(AdSoyad.Trim());
            }
            catch
            {
                return null;
            }
        }
        public PersonelKayit PersonelMail(string adsoyad)
        {
            try
            {
                return personelKayitDal.PersonelAmir(adsoyad);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<PersonelKayit> PersonelBilgiList(string sirketBolum)
        {
            try
            {
                return personelKayitDal.PersonelBilgiList(sirketBolum);
            }
            catch (Exception)
            {

                return new List<PersonelKayit>();
            }
        }
        public PersonelKayit PersonelMailWeb(string adsoyad)
        {
            try
            {
                return personelKayitDal.PersonelMailWeb(adsoyad);
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
                return personelKayitDal.PersonelProjeKodu(adsoyad);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<PersonelKayit> PersonelAdSoyad(string sorumluPersonel="")
        {
            try
            {
                return personelKayitDal.PersonelAdSoyad(sorumluPersonel);
            }
            catch (Exception)
            {
                return new List<PersonelKayit>();
            }
        }

        public string PersonelSorumluDegistir(int personelId,int yetkiliId)
        {
            try
            {
                
                return personelKayitDal.PersonelSorumluDegistir(personelId, yetkiliId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SiparisGuncelle(string adSoyad, string siparis)
        {
            try
            {

                return personelKayitDal.SiparisGuncelle(adSoyad, siparis);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string IsPersonelKayitComplete(PersonelKayit personelKayit)
        {
            if (string.IsNullOrEmpty(personelKayit.Adsoyad))
            {
                return "Lütfen Personelin Ad ve Soyadını Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Tc.ToString()))
            {
                return "Lütfen Personelin TC Numarasını Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Heskodu))
            {
                return "Lütfen Personelin HES KODUNU Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sigortasicilno))
            {
                return "Lütfen Personelin SİGORTA SİCİL NUMARASINI Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Ikametgah))
            {
                return "Lütfen Personelin İKAMETGAH ADRESSİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Kangrubu))
            {
                return "Lütfen Personelin KAN GRUBUNU Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Medenidurumu))
            {
                return "Lütfen Personelin MEDENİ DURUMUNU Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Dogumyeri))
            {
                return "Lütfen Personelin DOĞUM YERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Okul))
            {
                return "Lütfen Personelin OKUL BİLGİSİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Bolum))
            {
                return "Lütfen Personelin BOLUM BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Diplomanotu))
            {
                return "Lütfen Personelin DİPLOMA NOTU BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Siparis))
            {
                return "Lütfen Personelin SİPARİŞ BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sat))
            {
                return "Lütfen Personelin SAT BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Butcekodu))
            {
                return "Lütfen Personelin BÜTÇE KODU BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Butcekalemi))
            {
                return "Lütfen Personelin BÜTÇE KALEMİ BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sicil))
            {
                return "Lütfen Personelin SİCİL BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Masyerino))
            {
                return "Lütfen Personelin MASRAF YERİ NO BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sirketmail))
            {
                return "Lütfen Personelin ŞİRKET MAİLİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Masrafyeri))
            {
                return "Lütfen Personelin MASRAF YERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Oficemail))
            {
                return "Lütfen Personelin OFİS MAİLİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Isunvani))
            {
                return "Lütfen Personelin İŞ UNVANI BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Askerlikdurumu))
            {
                return "Lütfen Personelin ASKERLİK BİLGİLERİNİ Giriniz.";
            }
            /*if (string.IsNullOrEmpty(personelKayit.Maas.ToString()))
            {
                return "Lütfen Personelin MAAŞ BİLGİLERİNİ Giriniz.";
            }*/
            if (string.IsNullOrEmpty(personelKayit.Sirketbolum))
            {
                return "Lütfen Personelin ŞİRKET BÖLÜMÜ BİLGİLERİNİ Giriniz.";
            }
            return "";
        }
        string IsPersonelGuncelleComplete(PersonelKayit personelKayit)
        {
            if (string.IsNullOrEmpty(personelKayit.Adsoyad))
            {
                return "Lütfen Personelin Ad ve Soyadını Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Tc.ToString()))
            {
                return "Lütfen Personelin TC Numarasını Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Heskodu))
            {
                return "Lütfen Personelin HES KODUNU Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sigortasicilno))
            {
                return "Lütfen Personelin SİGORTA SİCİL NUMARASINI Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Ikametgah))
            {
                return "Lütfen Personelin İKAMETGAH ADRESSİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Kangrubu))
            {
                return "Lütfen Personelin KAN GRUBUNU Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Medenidurumu))
            {
                return "Lütfen Personelin MEDENİ DURUMUNU Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Dogumyeri))
            {
                return "Lütfen Personelin DOĞUM YERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Okul))
            {
                return "Lütfen Personelin OKUL BİLGİSİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Bolum))
            {
                return "Lütfen Personelin BOLUM BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Diplomanotu))
            {
                return "Lütfen Personelin DİPLOMA NOTU BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Siparis))
            {
                return "Lütfen Personelin SİPARİŞ BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sat))
            {
                return "Lütfen Personelin SAT BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Butcekodu))
            {
                return "Lütfen Personelin BÜTÇE KODU BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Butcekalemi))
            {
                return "Lütfen Personelin BÜTÇE KALEMİ BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sicil))
            {
                return "Lütfen Personelin SİCİL BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Masyerino))
            {
                return "Lütfen Personelin MASRAF YERİ NO BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sirketmail))
            {
                return "Lütfen Personelin ŞİRKET MAİLİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Masrafyeri))
            {
                return "Lütfen Personelin MASRAF YERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Oficemail))
            {
                return "Lütfen Personelin OFİS MAİLİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Isunvani))
            {
                return "Lütfen Personelin İŞ UNVANI BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Askerlikdurumu))
            {
                return "Lütfen Personelin ASKERLİK BİLGİLERİNİ Giriniz.";
            }
            if (string.IsNullOrEmpty(personelKayit.Sirketbolum))
            {
                return "Lütfen Personelin ŞİRKET BÖLÜMÜ BİLGİLERİNİ Giriniz.";
            }
            return "";
        }
    }
}
