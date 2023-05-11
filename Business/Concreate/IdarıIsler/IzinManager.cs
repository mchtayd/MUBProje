﻿using DataAccess.Abstract;
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

        public string Delete(int id)
        {
            try
            {
                return İzinDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Izin Get(int isakisno, string personelAd="")
        {
            try
            {
                return İzinDal.Get(isakisno, personelAd);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Izin GetId(int id)
        {
            try
            {
                return İzinDal.GetId(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                return İzinDal.IsAkisNoDuzelt(id, isAkisNo, dosyaYolu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string IzinOnay(int id, string onayBilgi)
        {
            try
            {
                return İzinDal.IzinOnay(id, onayBilgi);
            }
            catch (Exception ex)
            {
                return ex.Message;
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
        public List<Izin> GetListPersonel(string personelAdi)
        {
            try
            {
                return İzinDal.GetListPersonel(personelAdi);
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }
        public List<Izin> GetListTarih(DateTime baslamaTarihi, DateTime bitisTarihi)
        {
            try
            {
                return İzinDal.GetListTarih(baslamaTarihi, bitisTarihi);
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }

        public List<Izin> GetListOnay()
        {
            try
            {
                return İzinDal.GetListOnay();
            }
            catch (Exception)
            {
                return new List<Izin>();
            }
        }

        public List<Izin> GetListIzinlerim(string personelAd)
        {
            try
            {
                return İzinDal.GetListIzinlerim(personelAd);
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
        public string UpdateToplamSure(int id, string toplamSure)
        {
            try
            {
                
                return İzinDal.UpdateToplamSure(id, toplamSure);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateIzin(Izin entity)
        {
            try
            {

                return İzinDal.UpdateIzin(entity);
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
