using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarimAtolye;
using Entity.BakimOnarimAtolye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarimAtolye
{
    public class AtolyeManager // : IRepository<Atolye>
    {
        static AtolyeManager atolyeManager;
        AtolyeDal atolyeDal;

        private AtolyeManager()
        {
            atolyeDal = AtolyeDal.GetInstance();
        }

        public string Add(Atolye entity)
        {
            try
            {
                return atolyeDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string IslemGuncelle(string siparisNo,string islemAdimi)
        {
            try
            {
                return atolyeDal.IslemGuncelle(siparisNo,islemAdimi);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id, string siparisNo="")
        {
            try
            {
                return atolyeDal.Delete(id, siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Atolye Get(string siparisNo)
        {
            try
            {
                return atolyeDal.Get(siparisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Atolye ArizaGetir(int abfNo)
        {
            try
            {
                return atolyeDal.ArizaGetir(abfNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Atolye ArizaGetirDTS(int abfNo)
        {
            try
            {
                return atolyeDal.ArizaGetirDTS(abfNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Atolye> GetList(int durum)
        {
            try
            {
                return atolyeDal.GetList(durum);
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }
        public List<Atolye> GetListVeriMalzeme()
        {
            try
            {
                return atolyeDal.GetListVeriMalzeme();
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }
        public List<Atolye> AtolyeIcSiparis(int id)
        {
            try
            {
                return atolyeDal.AtolyeIcSiparis(id);
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }
        public List<Atolye> AtolyeAbf(string abfNo)
        {
            try
            {
                return atolyeDal.AtolyeAbf(abfNo);
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }
        public List<Atolye> AtolyeKategori()
        {
            try
            {
                return atolyeDal.AtolyeKategori();
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }
        public List<Atolye> AtolyeKategoriAdet(string kategoriAd)
        {
            try
            {
                return atolyeDal.AtolyeKategoriAdet(kategoriAd);
            }
            catch (Exception)
            {
                return new List<Atolye>();
            }
        }

        public string IslemAdimiGuncelle(string islemAdimi,int id)
        {
            try
            {
                return atolyeDal.IslemAdimiGuncelle(islemAdimi, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AtolyeVeriDuzelt(string siparisNo)
        {
            try
            {
                return atolyeDal.AtolyeVeriDuzelt(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ArizaKapat(int id, int durum, DateTime tamamlanmaTarihi)
        {
            try
            {
                return atolyeDal.ArizaKapat(id, durum, tamamlanmaTarihi);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AtolyeManager GetInstance()
        {
            if (atolyeManager == null)
            {
                atolyeManager = new AtolyeManager();
            }
            return atolyeManager;
        }
    }
}
