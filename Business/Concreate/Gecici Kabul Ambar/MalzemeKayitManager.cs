﻿using DataAccess.Abstract;
using DataAccess.Concreate.Gecici_Kabul_Ambar;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Gecici_Kabul_Ambar
{
    public class MalzemeKayitManager // : IRepository<MalzemeKayit>
    {
        static MalzemeKayitManager malzemeKayitManager;
        MalzemeKayitDal malzemeKayitDal;
        string controlText;

        private MalzemeKayitManager()
        {
            malzemeKayitDal = MalzemeKayitDal.GetInstance();
        }

        public string Add(MalzemeKayit entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText!="")
                {
                    return controlText;
                }
                return malzemeKayitDal.Add(entity);
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
                if (id<0)
                {
                    return "Lütfen Bir Kayit Seçiniz.";
                }
                return malzemeKayitDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public MalzemeKayit Get(int id)
        {
            try
            {
                return malzemeKayitDal.Get(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<MalzemeKayit> GetList(int id=0)
        {
            try
            {
                return malzemeKayitDal.GetList(id);
            }
            catch (Exception)
            {
                return new List<MalzemeKayit>();
            }
        }

        public string Update(MalzemeKayit entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return malzemeKayitDal.Update(entity,id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static MalzemeKayitManager GetInstance()
        {
            if (malzemeKayitManager == null)
            {
                malzemeKayitManager = new MalzemeKayitManager();
            }
            return malzemeKayitManager;
        }
        string Complete(MalzemeKayit malzemeKayit)
        {
            if (string.IsNullOrEmpty(malzemeKayit.Stokno))
            {
                return "Lütfen MALZEME STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Tanim))
            {
                return "Lütfen MALZEME TANIM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Birim))
            {
                return "Lütfen MALZEME BİRİM Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Tedarikcifirma))
            {
                return "Lütfen TEDARİKÇİ FİRMA Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Malzemeonarimdurumu))
            {
                return "Lütfen MALZEME ONARIM DURUMU Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Malzemeonarımyeri))
            {
                return "Lütfen MALZEME ONARIM YERİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Malzemeturu))
            {
                return "Lütfen MALZEME TÜRÜ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Malzemetakipdurumu))
            {
                return "Lütfen MALZEME TAKİP DURUMU Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Malzemerevizyon))
            {
                return "Lütfen MALZEME REVİZYON NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Malzemekul))
            {
                return "Lütfen MALZEMENİN KULLANILDIĞI ÜST TAKIM STOK NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Aciklama))
            {
                return "Lütfen AÇIKLAMA Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(malzemeKayit.Dosyayolu))
            {
                return "Lütfen MALZEMEYE AİT DOKUMAN VEYA FOROĞRAF EKLEYİNİ Bilgisini doldurunuz.";
            }
            return "";
        }
    }
}
