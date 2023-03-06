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
    public class MasrafYeriManager //: IRepository<MasrafYeri>
    {
        static MasrafYeriManager masrafYeriManager;
        MasrafYeriDal masrafYeriDal;
        string controlText;

        private MasrafYeriManager()
        {
            masrafYeriDal = MasrafYeriDal.GetInstance();
        }

        public string Add(MasrafYeri entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return masrafYeriDal.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Delete(int id)
        {
            try
            {
                return masrafYeriDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public MasrafYeri Get(int id)
        {
            try
            {
                return masrafYeriDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MasrafYeri> GetList()
        {
            try
            {
                return masrafYeriDal.GetList();
            }
            catch (Exception)
            {
                return new List<MasrafYeri>();
            }
        }

        public string Update(MasrafYeri entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return masrafYeriDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(MasrafYeri masrafYeri)
        {
            if (string.IsNullOrEmpty(masrafYeri.MasrafYeriNo))
            {
                return "Lütfen Masraf Yeri No Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(masrafYeri.MasrafYeriBilgi))
            {
                return "Lütfen Masraf Yeri Bilgisini Giriniz.";
            }
            return "";
        }
        public static MasrafYeriManager GetInstance()
        {
            if (masrafYeriManager == null)
            {
                masrafYeriManager = new MasrafYeriManager();
            }
            return masrafYeriManager;
        }
    }
}
