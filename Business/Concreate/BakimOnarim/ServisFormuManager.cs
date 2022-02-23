using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class ServisFormuManager //: IRepository<ServisFormu>
    {
        static ServisFormuManager servisFormuManager;
        ServisFormuDal servisFormuDal;
        string controlText;

        private ServisFormuManager()
        {
            servisFormuDal = ServisFormuDal.GetInstance();
        }
        public string Add(ServisFormu entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return servisFormuDal.Add(entity);
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
                return servisFormuDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ServisFormu Get(int isAkisNo)
        {
            try
            {
                return servisFormuDal.Get(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ServisFormu> GetList()
        {
            try
            {
                return servisFormuDal.GetList();
            }
            catch (Exception)
            {
                return new List<ServisFormu>();
            }
        }

        public string Update(ServisFormu entity,int id)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return servisFormuDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complete(ServisFormu servisFormu)
        {
            if (string.IsNullOrEmpty(servisFormu.Firma))
            {
                return "Lütfen BÖLGE ADI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.UsBolgesi))
            {
                return "Lütfen İLGİLİ PERSONEL Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.ServisFormNo))
            {
                return "Lütfen TELEFON Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.MudehaleTuru))
            {
                return "Lütfen İL Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.Marka))
            {
                return "Lütfen İLÇE Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.Model))
            {
                return "Lütfen BİRLİK ADRESİ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.SeriNo))
            {
                return "Lütfen PROJE Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.Guc))
            {
                return "Lütfen PYP NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.ServisRaporu))
            {
                return "Lütfen BÖLGE SORUMLUSU SİCİL NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.ServisYetkilisi))
            {
                return "Lütfen SORUMLU PERSONEL ADI SOYADI Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(servisFormu.Musteri))
            {
                return "Lütfen SORUMLU PERSONEL GÖREVİ Bilgisini doldurunuz.";
            }
            return "";
        }
        public static ServisFormuManager GetInstance()
        {
            if (servisFormuManager == null)
            {
                servisFormuManager = new ServisFormuManager();
            }
            return servisFormuManager;
        }
    }
}
