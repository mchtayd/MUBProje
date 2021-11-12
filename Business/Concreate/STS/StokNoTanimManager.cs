using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class StokNoTanimManager //: IRepository<StokNoTanim>
    {

        static StokNoTanimManager stokNoTanimManager;
        StokNoTanimDal stokNoTanimDal;
        string controlText;

        private StokNoTanimManager()
        {
            stokNoTanimDal = StokNoTanimDal.GetInstance();
        }
        public string Add(StokNoTanim entity)
        {
            try
            {
                controlText = IsStokNoTanimComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return stokNoTanimDal.Add(entity);
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
                if (id < 1)
                {
                    return "Lütfen Geçerli Stok Numarası Seçiniz.";
                }
                return stokNoTanimDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public StokNoTanim Get(int id)
        {
            return null;
        }

        public List<StokNoTanim> GetList()
        {
            try
            {
                return stokNoTanimDal.GetList();
            }
            catch
            {
                return new List<StokNoTanim>();
            }
        }

        public string Update(StokNoTanim entity)
        {
            try
            {
                if (entity.Id < 1)
                {
                    return "Lütfen Geçerli Stok Numarası Seçiniz.";
                }
                controlText = IsStokNoTanimComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return stokNoTanimDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string IsStokNoTanimComplete(StokNoTanim stokNoTanim)
        {
            if (string.IsNullOrEmpty(stokNoTanim.Stokno))
            {
                return "Lütfen Bir Stok Numarası Giriniz.";
            }
            if (stokNoTanim.Stokno.Length > 15)
            {
                return "Lütfen en fazla 15 karakter isim giriniz.";
            }
            return "";
        }

        public static StokNoTanimManager GetInstance()
        {
            if (stokNoTanimManager == null)
            {
                stokNoTanimManager = new StokNoTanimManager();
            }
            return stokNoTanimManager;
        }
    }
}
