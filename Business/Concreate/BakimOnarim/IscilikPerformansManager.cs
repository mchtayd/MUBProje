﻿using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class IscilikPerformansManager // : IRepository<IscilikPerformans>
    {
        static IscilikPerformansManager performansManager;
        IscilikPerformansDal performansDal;
        string controlText;

        private IscilikPerformansManager()
        {
            performansDal = IscilikPerformansDal.GetInstance();
        }

        public string Add(IscilikPerformans entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return performansDal.Add(entity);
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
                return performansDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikPerformans Get(string personelAd)
        {
            try
            {
                return performansDal.Get(personelAd);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IscilikPerformans PerformansBul(int isAkisNo)
        {
            try
            {
                return performansDal.PerformansBul(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikPerformans> PerformansHatalilar()
        {
            try
            {
                return performansDal.PerformansHatalilar();
            }
            catch (Exception)
            {
                return new List<IscilikPerformans>();
            }
        }
        public List<IscilikPerformans> GetList(string personelAd)
        {
            try
            {
                return performansDal.GetList(personelAd);
            }
            catch (Exception)
            {
                return new List<IscilikPerformans>();
            }
        }
        public List<IscilikPerformans> IscilikPerformansList(int isAkisNo)
        {
            try
            {
                return performansDal.IscilikPerformansList(isAkisNo);
            }
            catch (Exception)
            {
                return new List<IscilikPerformans>();
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo)
        {
            try
            {

                return performansDal.IsAkisNoDuzelt(id, isAkisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(IscilikPerformans entity,int isAkisNo,string hata)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return performansDal.Update(entity, isAkisNo,hata);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string HataBildir(int id,string hata)
        {
            try
            {
                return performansDal.HataBildir(id,hata);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IscilikPerformansManager GetInstance()
        {
            if (performansManager == null)
            {
                performansManager = new IscilikPerformansManager();
            }
            return performansManager;
        }
        string Complete(IscilikPerformans performans)
        {
            if (string.IsNullOrEmpty(performans.Personel))
            {
                return "Lütfen PERSONEL ADI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(performans.MevcutDuragi))
            {
                return "Lütfen MEVCUT DURAĞI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(performans.CikisDuragi))
            {
                return "Lütfen ÇIKIŞ DURAĞI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(performans.IstikametDuragi))
            {
                return "Lütfen İSTİKAMET DURAĞI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(performans.CikisDuragi))
            {
                return "Lütfen ÇIKIŞ DURAĞI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(performans.VarisDurag))
            {
                return "Lütfen VARIŞ DURAĞI Bilgisini doldurunuz.";
            }
            return "";
        }
    }
}
