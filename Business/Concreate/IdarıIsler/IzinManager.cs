using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class IzinManager  //: IRepository<Izin>
    {
        static IzinManager İzinManager;
        IzinDal İzinDal;
        string controlText;

        private IzinManager()
        {
            İzinDal = IzinDal.GetInstance();
        }

        public string Add(Izin entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return İzinDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int isakisno)
        {
            try
            {
                return İzinDal.Delete(isakisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Izin Get(int isakisno)
        {
            try
            {
                return İzinDal.Get(isakisno);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Izin> GetList(int isakisno=0)
        {
            try
            {
                return İzinDal.GetList(isakisno);
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }
        public List<Izin> DevamDevamsizlik()
        {
            try
            {
                return İzinDal.DevamDevamsizlik();
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }

        public string Update(Izin entity,int isakisno)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return İzinDal.Update(entity, isakisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IzinManager GetInstance()
        {
            if (İzinManager== null)
            {
                İzinManager = new IzinManager();
            }
            return İzinManager;
        }

        string Complate(Izin ızin)
        {
            if (string.IsNullOrEmpty(ızin.Izinkategori))
            {
                return "Lütfen izin Kategori Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ızin.Izinturu))
            {
                return "Lütfen İzin Türü bilgilerini Giriniz.";
            }
            if (string.IsNullOrEmpty(ızin.Siparisno))
            {
                return "Lütfen Personel Sipariş No Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ızin.Adsoyad))
            {
                return "Lütfen Personel Ad Soyad Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(ızin.Izınnedeni))
            {
                return "Lütfen İzin Nedeni Bilgisini Giriniz.";
            }
            return "";
        }
    }
}
