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
    public class PypManager // : IRepository<Pyp>
    {
        static PypManager pypManager;
        PypDal pypDal;
        string controlText;

        private PypManager()
        {
            pypDal = PypDal.GetInstance();
        }
        public string Add(Pyp entity)
        {
            try
            {
                controlText = Complete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return pypDal.Add(entity);
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
                return pypDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Pyp Get(int id)
        {
            try
            {
                return pypDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Pyp> GetList()
        {
            try
            {
                return pypDal.GetList();
            }
            catch (Exception)
            {
                return new List<Pyp>();
            }
        }

        public string Update(Pyp entity)
        {
            try
            {
                return pypDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static PypManager GetInstance()
        {
            if (pypManager == null)
            {
                pypManager = new PypManager();
            }
            return pypManager;
        }
        string Complete(Pyp pyp)
        {
            if (string.IsNullOrEmpty(pyp.PypNo))
            {
                return "Lütfen PYP NO Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(pyp.SorumluPersonel))
            {
                return "Lütfen SORUMLU PERSONEL Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(pyp.SiparisTuru))
            {
                return "Lütfen SİPARİŞ TÜRÜ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(pyp.IslemTuru))
            {
                return "Lütfen İŞLEM TÜRÜ Bilgisini doldurunuz.";
            }
            if (string.IsNullOrEmpty(pyp.HesaplamaNedeni))
            {
                return "Lütfen HESAPLAMA NEDENİ Bilgisini doldurunuz.";
            }
            return "";
        }
    }
}
