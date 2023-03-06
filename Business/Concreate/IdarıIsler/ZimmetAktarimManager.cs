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
    public class ZimmetAktarimManager //: IRepository<ZimmetAktarim>
    {
        static ZimmetAktarimManager zimmetAktarimManager;
        ZimmetAktarimDal zimmetAktarimDal;

        private ZimmetAktarimManager()
        {
            zimmetAktarimDal = ZimmetAktarimDal.GetInstance();
        }
        public string Add(ZimmetAktarim entity)
        {
            try
            {
                /*controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }*/
                return zimmetAktarimDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string dvEtiketNo , string personelad)
        {
            try
            {
                return zimmetAktarimDal.Delete(dvEtiketNo, personelad);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<ZimmetAktarim> PersonelZimmeti(string adsoyad)
        {
            try
            {
                return zimmetAktarimDal.PersonelZimmeti(adsoyad);
            }
            catch (Exception)
            {
                return new List<ZimmetAktarim>();
            }
        }
        public ZimmetAktarim Get(string dvEtiketNo)
        {
            try
            {
                return zimmetAktarimDal.Get(dvEtiketNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ZimmetAktarim AracZimmetBilgileri(string plaka)
        {
            try
            {
                return zimmetAktarimDal.AracZimmetBilgileri(plaka);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ZimmetAktarim> GetList()
        {
            try
            {
                return zimmetAktarimDal.GetList();
            }
            catch (Exception)
            {
                return new List<ZimmetAktarim>();
            }
        }
        public List<ZimmetAktarim> ZimmetliAraclar()
        {
            try
            {
                return zimmetAktarimDal.ZimmetliAraclar();
            }
            catch (Exception)
            {
                return new List<ZimmetAktarim>();
            }
        }

        public string Update(ZimmetAktarim entity,int id)
        {
            try
            {
                return zimmetAktarimDal.Update(entity,id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(ZimmetAktarim zimmetAktarim)
        {
            if (string.IsNullOrEmpty(zimmetAktarim.DvEtiketNo))
            {
                return "Lütfen DV ETİKET NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(zimmetAktarim.IslemTuru))
            {
                return "Lütfen İŞLEM TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(zimmetAktarim.AktarimTarihi.ToString()))
            {
                return "Lütfen AKTARIM TARİHİ Bilgisini Giriniz.";
            }
            return "";
        }
        public static ZimmetAktarimManager GetInstance()
        {
            if (zimmetAktarimManager == null)
            {
                zimmetAktarimManager = new ZimmetAktarimManager();
            }
            return zimmetAktarimManager;
        }
    }
}
