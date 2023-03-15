using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class OkfManager //: IRepository<Okf>
    {
        static OkfManager okfManager;
        OkfDal okfDal;
        string controlText;

        private OkfManager()
        {
            okfDal = OkfDal.GetInstance();
        }

        public string Add(Okf entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return okfDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string YapilacakIslemlerAdd(Okf entity)
        {
            try
            {
                return okfDal.YapilacakIslemlerAdd(entity);
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
                return okfDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public int OkfSonId()
        {
            try
            {
                return okfDal.OkfSonId();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public Okf Get(int id)
        {
            try
            {
                return okfDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Okf> GetList()
        {
            try
            {
                return okfDal.GetList();
            }
            catch (Exception)
            {
                return new List<Okf>();
            }
        }
        public List<Okf> YapilacakIslemlerGetList(int benzersizId)
        {
            try
            {
                return okfDal.YapilacakIslemlerGetList(benzersizId);
            }
            catch (Exception)
            {
                return new List<Okf>();
            }
        }
        public string YapilacakIslemlerDelete(int benzersizId)
        {
            try
            {
                return okfDal.YapilacakIslemlerDelete(benzersizId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(Okf entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return okfDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Okf OkfArizaBilgileri(int abfNo)
        {
            try
            {
                return okfDal.OkfArizaBilgileri(abfNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Okf OkfArizaBilgileriDTS(int abfNo)
        {
            try
            {
                return okfDal.OkfArizaBilgileriDTS(abfNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static OkfManager GetInstance()
        {
            if (okfManager == null)
            {
                okfManager = new OkfManager();
            }
            return okfManager;
        }
        string Complete(Okf okf)
        {
            if (string.IsNullOrEmpty(okf.AbfNo))
            {
                return "Lütfen ABF NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.UsBolgesi))
            {
                return "Lütfen ÜS BÖLGESİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.ProjeKodu))
            {
                return "Lütfen PROJE KODU Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.UbKomutani))
            {
                return "Lütfen ÜS BÖLGESİ KOMUTANI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.KomutanTel))
            {
                return "Lütfen ÜS BÖLGESİ TELEFON NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.UstStok))
            {
                return "Lütfen ÜST TAKIM STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.UstTanim))
            {
                return "Lütfen ÜST TAKIM TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.UstSeriNo))
            {
                return "Lütfen ÜST TAKIM SERİ NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.BildirilenAriza))
            {
                return "Lütfen BİLDİRİLEN ARIZA Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.ArizaNedeni))
            {
                return "Lütfen ARIZA NEDENİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.GenelOneriler))
            {
                return "Lütfen GENEL ÖNERİLER Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(okf.BirlikAdresi))
            {
                return "Lütfen BİRLİK ADRESİ Bilgisini doldurunuz.";
            }
            return "";
        }
    }
}
