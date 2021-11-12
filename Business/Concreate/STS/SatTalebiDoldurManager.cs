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
    public class SatTalebiDoldurManager //: IRepository<SatTalebiDoldur>
    {
        static SatTalebiDoldurManager satTalebiDoldurManager;
        SatTalebiDoldurDal satTalebiDoldurDal;

        private SatTalebiDoldurManager()
        {
            satTalebiDoldurDal = SatTalebiDoldurDal.GetInstance();
        }

        public string Add(SatTalebiDoldur entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatTalebiDoldur Get(string bolgeAdi)
        {
            try
            {
                return satTalebiDoldurDal.Get(bolgeAdi);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SatTalebiDoldur> GetList()
        {
            try
            {

                return satTalebiDoldurDal.GetList();

            }
            catch
            {

                return new List<SatTalebiDoldur>();
            }
        }
        public List<SatTalebiDoldur> BolgeSatList(string bolgeAdi)
        {
            try
            {

                return satTalebiDoldurDal.BolgeSatList(bolgeAdi);

            }
            catch
            {

                return new List<SatTalebiDoldur>();
            }
        }

        public string Update(SatTalebiDoldur entity)
        {
            throw new NotImplementedException();
        }

        public static SatTalebiDoldurManager GetInstance()
        {
            if (satTalebiDoldurManager == null)
            {
                satTalebiDoldurManager = new SatTalebiDoldurManager();
            }
            return satTalebiDoldurManager;
        }

        /*string IsSatTalebiDoldurComplete(SatTalebiDoldur satTalebiDoldur)
        {
            if (string.IsNullOrEmpty(satTalebiDoldur.Usbolgesi))
            {
                return "Lütfen Bir Stok Numarası Giriniz.";
            }
            if (stokNoTanim.Stokno.Length > 15)
            {
                return "Lütfen en fazla 15 karakter isim giriniz.";
            }
            return "";
        }*/
    }
}
