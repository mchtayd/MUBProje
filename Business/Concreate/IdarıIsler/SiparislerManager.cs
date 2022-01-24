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
    public class SiparislerManager
    {
        static SiparislerManager siparislerManager;
        SiparislerDal siparislerDal;
        string controlText;

        private SiparislerManager()
        {
            siparislerDal = SiparislerDal.GetInstance();
        }

        public string Add(Siparisler entity)
        {
            try
            {
                controlText = IsSiparislerComplete(entity);
                if (controlText!= "")
                {
                    return controlText;
                }
                return siparislerDal.Add(entity);
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
                if (id<1)
                {
                    return "Lütfen geçerli bir Sipariş Seçiniz.";
                }
                return siparislerDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Siparisler Get(int id)
        {
            try
            {
                return siparislerDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Siparisler AracMevcutKadroKontrol(string siparisNo)
        {
            try
            {
                return siparislerDal.AracMevcutKadroKontrol(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Siparisler YillikSiparisCek(string yil)
        {
            try
            {
                return siparislerDal.YiilkSiparisCek(yil);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Siparisler> GetList(string benzersiz="")
        {
            try
            {
                return siparislerDal.GetList(benzersiz);
            }
            catch
            {
                return new List<Siparisler>();
            }
        }

        public string Update(Siparisler entity)
        {
            try
            {
                controlText = IsSiparislerComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return siparislerDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AracSiparisArttir(string siparisNo)
        {
            try
            {
                return siparislerDal.AracSiparisArttir(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AracSiparisAzalt(string siparisNo)
        {
            try
            {
                return siparislerDal.AracSiparisAzalt(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SiparislerManager GetInstance()
        {
            if (siparislerManager == null)
            {
                siparislerManager = new SiparislerManager();
            }
            return siparislerManager;
        }
        string IsSiparislerComplete(Siparisler siparisler)
        {
            if (string.IsNullOrEmpty(siparisler.Proje))
            {
                return "Lütfen PROJE Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(siparisler.Sat))
            {
                return "Lütfen SAT Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(siparisler.Donemyil))
            {
                return "Lütfen DÖNEM/YIL Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(siparisler.Satkategori))
            {
                return "Lütfen SAT KATEGORİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(siparisler.Personelsayisi.ToString()))
            {
                return "Lütfen PERSONEL SAYISI Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(siparisler.Yoneticiarac.ToString()))
            {
                return "Lütfen YÖNETİCİ ARAÇ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(siparisler.Araziarac.ToString()))
            {
                return "Lütfen ARAZİ ARAÇ Bilgisini Giriniz.";
            }
            return "";
        }
        public int ToplamPers()
        {
            try
            {
                return siparislerDal.ToplamPers();
            }
            catch
            {
                return -1;
            }
        }
        public int ToplamArac()
        {
            try
            {
                return siparislerDal.ToplamArac();
            }
            catch
            {
                return -1;
            }
        }
        public int KontejanKontrol(string siparisno)
        {
            try
            {
                return siparislerDal.KontejanKontrol(siparisno);
            }
            catch
            {
                return -1;
            }
        }
        public int KontejanKontrolMevcut(string siparisno)
        {
            try
            {
                return siparislerDal.KontejanKontrolMevcut(siparisno);
            }
            catch
            {
                return -1;
            }
        }
        public string KontejanMevcutGuncelle(string siparisno,int mevcut)
        {
            try
            {
                return siparislerDal.KontejanMevcutGuncelle(siparisno, mevcut);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string KontejanMevcutAzalt(string siparisno, int mevcut)
        {
            try
            {
                return siparislerDal.KontejanMevcutAzalt(siparisno, mevcut);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
