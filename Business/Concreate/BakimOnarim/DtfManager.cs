using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class DtfManager //: IRepository<Dtf>
    {
        static DtfManager dtfManager;
        DtfDal dtfDal;
        string controlText;

        private DtfManager()
        {
            dtfDal = DtfDal.GetInstance();
        }
        public string Add(Dtf entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return dtfDal.Add(entity);
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
                return dtfDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DtfKayitDurum(int id, string firma)
        {
            try
            {
                return dtfDal.DtfKayitDurum(id, firma);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Dtf Get(int isAkisNo)
        {
            try
            {
                return dtfDal.Get(isAkisNo);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Dtf> GetList(string durum)
        {
            try
            {
                return dtfDal.GetList(durum);
            }
            catch (Exception)
            {
                return new List<Dtf>();
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {

                return dtfDal.IsAkisNoDuzelt(id, isAkisNo, dosyaYolu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Dtf> DtfKayitList(int isAkisNo)
        {
            try
            {
                return dtfDal.DtfKayitList(isAkisNo);
            }
            catch (Exception)
            {
                return new List<Dtf>();
            }
        }
        public Dtf DtfArizaBilgileri(int abfNo)
        {
            try
            {
                return dtfDal.DtfArizaBilgileri(abfNo);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Dtf DtfArizaBilgileriDTS(int abfNo)
        {
            try
            {
                return dtfDal.DtfArizaBilgileriDTS(abfNo);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string Update(Dtf entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return dtfDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string KontrolOnayGuncelle(Dtf entity)
        {
            try
            {
                return dtfDal.KontrolOnayGuncelle(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(Dtf dtf)
        {
            if (string.IsNullOrEmpty(dtf.Donem))
            {
                return "Lütfen DÖNEM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.ButceKodu))
            {
                return "Lütfen HARCAMA KODU KALEMİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.UsBolgesi))
            {
                return "Lütfen ÜS BÖLGESİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.ProjeKodu))
            {
                return "Lütfen PROJE KODU Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.GarantiDurumu))
            {
                return "Lütfen GARANTİ DURUMU Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.IsKategorisi))
            {
                return "Lütfen İŞ KATEGORİSİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.IsTanimi))
            {
                return "Lütfen İŞİN TANIMI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.StokNo))
            {
                return "Lütfen STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.Tanim))
            {
                return "Lütfen TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.SeriNo))
            {
                return "Lütfen SERİ NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.OnarimYeri))
            {
                return "Lütfen ONARIM YERİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(dtf.AltYukleniciFirma))
            {
                return "Lütfen ALT YÜKLENİCİ FİRMA Bilgisini doldurunuz.";
            }
            return "";
        }
        public static DtfManager GetInstance()
        {
            if (dtfManager == null)
            {
                dtfManager = new DtfManager();
            }
            return dtfManager;
        }
    }
}
