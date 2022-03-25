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
            throw new NotImplementedException();
        }

        public ButceKodu Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ButceKodu> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(ButceKodu entity)
        {
            throw new NotImplementedException();
        }
        string Complate(ButceKodu butceKodu)
        {
            if (string.IsNullOrEmpty(butceKodu.ButceKoduKalemi))
            {
                return "Lütfen BÜTÇE KODU KALEMİ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(butceKodu.Aciklama))
            {
                return "Lütfen AÇIKLAMA Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(butceKodu.GiderKarsilayacakFirma))
            {
                return "Lütfen GİDER KARŞILAYACAK FİRMA Bilgisini Giriniz.";
            }
            return "";
        }
    }
}
