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
    public class SatRenkliiTabloManager //: IRepository<SatRenkliTablo>
    {
        static SatRenkliiTabloManager satRenkliiTabloManager;
        SatRenkliTabloDal satRenkliTabloDal;
        string controlText;
        private SatRenkliiTabloManager()
        {
            satRenkliTabloDal = SatRenkliTabloDal.GetInstance();
        }

        public string Add(SatRenkliTablo entity)
        {
            try
            {
                controlText = IsRenkliTabloComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return satRenkliTabloDal.Add(entity);
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

        public SatRenkliTablo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatRenkliTablo> GetList(string firmaadi, string durum)
        {
            try
            {
                return satRenkliTabloDal.GetList(firmaadi,durum);
            }
            catch (Exception)
            {
                return new List<SatRenkliTablo>();
            }
        }

        public string Update(SatRenkliTablo entity)
        {
            throw new NotImplementedException();
        }
        string IsRenkliTabloComplete(SatRenkliTablo satRenkli)
        {
            if (string.IsNullOrEmpty(satRenkli.Firmaadi))
            {
                return "Lütfen Firma Adini Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(satRenkli.Siparisid))
            {
                return "Lütfen Firmayı Seçiniz.";
            }
            if (string.IsNullOrEmpty(satRenkli.Dosyayolu))
            {
                return "Lütfen Dosya Yolu Bilgisini Giriniz.";
            }
            return "";
        }


        public static SatRenkliiTabloManager GetInstance()
        {
            if (satRenkliiTabloManager == null)
            {
                satRenkliiTabloManager = new SatRenkliiTabloManager();
            }
            return satRenkliiTabloManager;
        }
    }
}
