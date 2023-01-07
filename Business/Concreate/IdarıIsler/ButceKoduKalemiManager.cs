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
    public class ButceKoduKalemiManager //: IRepository<ButceKodu>
    {
        static ButceKoduKalemiManager butceKoduKalemiManager;
        ButceKoduDal butceKoduDal;
        string controlText;

        private ButceKoduKalemiManager()
        {
            butceKoduDal = ButceKoduDal.GetInstance();
        }
        public string Add(ButceKodu entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return butceKoduDal.Add(entity);

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
                return butceKoduDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ButceKodu Get(int id)
        {
            throw new NotImplementedException();
        }
        public ButceKodu ButceKoduComboBilgiList(string baslik)
        {
            try
            {
                return butceKoduDal.ButceKoduComboBilgiList(baslik);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ButceKodu> GetList()
        {
            try
            {
                return butceKoduDal.GetList();
            }
            catch (Exception)
            {
                return new List<ButceKodu>();
            }
        }

        public string Update(ButceKodu entity)
        {
            try
            {
                return butceKoduDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(ButceKodu butceKodu)
        {
            if (string.IsNullOrEmpty(butceKodu.ButceKoduKalemi))
            {
                return "Lütfen BÜTÇE KODU KALEMİ Bilgisini Giriniz.";
            }
            return "";
        }
        public static ButceKoduKalemiManager GetInstance()
        {
            if (butceKoduKalemiManager == null)
            {
                butceKoduKalemiManager = new ButceKoduKalemiManager();
            }
            return butceKoduKalemiManager;
        }
    }
}
