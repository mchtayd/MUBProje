using DataAccess.Abstract;
using DataAccess.Concreate.STS;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class FiyatTeklifiAlManager //: IRepository<FiyatTeklifiAl>
    {
        static FiyatTeklifiAlManager fiyatTeklifiAlManager;
        FiyatTeklifiAlDal fiyatTeklifiAlDal;
        string controlText;

        private FiyatTeklifiAlManager()
        {
            fiyatTeklifiAlDal = FiyatTeklifiAlDal.GetInstance();
        }

        public string Add(FiyatTeklifiAl entity)
        {
            try
            {
                controlText = IsFiyatTeklifiComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return fiyatTeklifiAlDal.Add(entity);

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

        public FiyatTeklifiAl Get(string siparisNo, string stokNo)
        {
            try
            {
                return fiyatTeklifiAlDal.Get(siparisNo, stokNo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<FiyatTeklifiAl> GetList(string durum, string siparisNo = "")
        {
            try
            {
                return fiyatTeklifiAlDal.GetList(durum, siparisNo);
            }
            catch (Exception)
            {
                return new List<FiyatTeklifiAl>();
            }
        }
        public string UpdateTekifDurum(string siparisno)
        {
            try
            {
                return fiyatTeklifiAlDal.UpdateTekifDurum(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(FiyatTeklifiAl entity,int onayliTeklif)
        {
            try
            {
                return fiyatTeklifiAlDal.Update(entity, onayliTeklif);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DevamEdenFiyateklifiGuncelle(FiyatTeklifiAl entity)
        {
            try
            {
                return fiyatTeklifiAlDal.DevamEdenFiyateklifiGuncelle(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string IsFiyatTeklifiComplete(FiyatTeklifiAl fiyatTeklifi)
        {
            if (string.IsNullOrEmpty(fiyatTeklifi.Firma1))
            {
                return "Lütfen Birinci Firma Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(fiyatTeklifi.Firma2))
            {
                return "Lütfen İkinci Firma Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(fiyatTeklifi.Firma3))
            {
                return "Lütfen Üçüncü Firma Bilgisini Giriniz.";
            }
            return "";
        }
        public static FiyatTeklifiAlManager GetInstance()
        {
            if (fiyatTeklifiAlManager == null)
            {
                fiyatTeklifiAlManager = new FiyatTeklifiAlManager();
            }
            return fiyatTeklifiAlManager;
        }
        public void DurumGuncelle(int id)
        {
            try
            {
                fiyatTeklifiAlDal.DurumGuncelle(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
