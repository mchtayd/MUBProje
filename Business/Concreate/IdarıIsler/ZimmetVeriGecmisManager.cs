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
    public class ZimmetVeriGecmisManager //: IRepository<ZimmetVeriGecmis>
    {
        static ZimmetVeriGecmisManager zimmetVeriGecmisManager;
        ZimmetVeriGecmisDal zimmetVeriGecmisDal;
        string controlText;

        private ZimmetVeriGecmisManager()
        {
            zimmetVeriGecmisDal = ZimmetVeriGecmisDal.GetInstance();
        }
        public string Add(ZimmetVeriGecmis entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return zimmetVeriGecmisDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ZimmetVeriGecmis Get(string dvEtiketNo)
        {
            try
            {
                return zimmetVeriGecmisDal.Get(dvEtiketNo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ZimmetVeriGecmis> GetList()
        {
            try
            {
                return zimmetVeriGecmisDal.GetList();
            }
            catch (Exception)
            {
                return new List<ZimmetVeriGecmis>();
            }
        }

        public string Update(ZimmetVeriGecmis entity)
        {
            throw new NotImplementedException();
        }
        string Complate(ZimmetVeriGecmis zimmetVeriGecmis)
        {
            if (string.IsNullOrEmpty(zimmetVeriGecmis.DvEtiketNo))
            {
                return "Lütfen DV ETİKET NO Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(zimmetVeriGecmis.IslemTuru))
            {
                return "Lütfen İŞLEM TÜRÜ Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(zimmetVeriGecmis.AktarimGerekcesi))
            {
                return "Lütfen AKTARIM GEREKÇESİ Bilgisini Giriniz.";
            }
            return "";
        }
        public static ZimmetVeriGecmisManager GetInstance()
        {
            if (zimmetVeriGecmisManager == null)
            {
                zimmetVeriGecmisManager = new ZimmetVeriGecmisManager();
            }
            return zimmetVeriGecmisManager;
        }
    }
}
