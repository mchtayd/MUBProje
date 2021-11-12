using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ARAYÜZDEN GELEN DEĞERLERİ KONTROL EDECEĞİMİZ SINIF
namespace Business.Concreate
{
    public class MasrafYeriNoManager //: IRepository <MasrafYeriNo>
    {
        static MasrafYeriNoManager masrafYeriNoManager;
        MasrafYeriNoDal masrafYeriNoDal;
        string controlText;

        private MasrafYeriNoManager()
        {
            masrafYeriNoDal = MasrafYeriNoDal.GetInstance();
        }

        public string Add(MasrafYeriNo entity)
        {
            try
            {
                controlText = IsMasYerNoComplete(entity);
                if (controlText!="")
                {
                    return controlText;
                }
                return masrafYeriNoDal.Add(entity);
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
                    return "Lütfen Geçerli Bir Masraf Yeri Numarası Seçiniz.";
                }
                return masrafYeriNoDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public MasrafYeriNo Get(int id)
        {
            return null;
        }

        public List<MasrafYeriNo> GetList()
        {
            try
            {
                return masrafYeriNoDal.GetList();
            }
            catch
            {
                return new List<MasrafYeriNo>();
            }
        }

        public string Update(MasrafYeriNo entity)
        {
            try
            {
                if (entity.Id<1)
                {
                    return "Lütfen Geçerli Bir Masraf Yeri Numarası Seçiniz.";
                }
                controlText = IsMasYerNoComplete(entity);
                if (controlText!="")
                {
                    return controlText;
                }
                return masrafYeriNoDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        string IsMasYerNoComplete(MasrafYeriNo masrafYeriNo)
        {
            if (string.IsNullOrEmpty(masrafYeriNo.Masrafyerino))
            {
                return "Lütfen Bir Masraf Yeri Numarası Giriniz.";
            }
            if (masrafYeriNo.Talepedenad.Length>20)
            {
                return "Lütfen en fazla 20 karakter isim giriniz.";
            }
            return "";
        }

        public static MasrafYeriNoManager GetInstance()
        {
            if (masrafYeriNoManager == null)
            {
                masrafYeriNoManager = new MasrafYeriNoManager();
            }
            return masrafYeriNoManager;
        }

        
    }
}
