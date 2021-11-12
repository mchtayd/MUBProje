using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class TeklifsizSatManager //: IRepository<TeklifsizSat>
    {
        static TeklifsizSatManager teklifsizSatManager;
        TeklifsizSatDal teklifsizSatDal;
        string controlText;

        private TeklifsizSatManager()
        {
            teklifsizSatDal = TeklifsizSatDal.GetInstance();
        }

        public string Add(TeklifsizSat entity)
        {
            try
            {
                controlText = IsTeklifsizSatComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return teklifsizSatDal.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisno)
        {
            try
            {
                return teklifsizSatDal.Delete(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatMalzemeDurumGuncelle(string siparisno)
        {
            try
            {
                return teklifsizSatDal.SatMalzemeDurumGuncelle(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatMalzemeDurumGuncelleOnay(string siparisno)
        {
            try
            {
                return teklifsizSatDal.SatMalzemeDurumGuncelleOnay(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatDurumBasla(string siparisno)
        {
            try
            {
                return teklifsizSatDal.SatDurumBasla(siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public TeklifsizSat Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeklifsizSat> GetList(string siparisNo)
        {
            try
            {
                return teklifsizSatDal.GetList(siparisNo);
            }
            catch
            {
                return new List<TeklifsizSat>();
            }
        }

        public string Update(TeklifsizSat entity, string siparisno)
        {
            try
            {
                controlText = IsTeklifsizSatComplete(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return teklifsizSatDal.Update(entity, siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string IsTeklifsizSatComplete(TeklifsizSat teklifsiz)
        {
            if (string.IsNullOrEmpty(teklifsiz.Tutar.ToString()))
            {
                return "Lütfen TUTAR Bilgisini doldurunuz.";
            }
            return "";
        }
        public static TeklifsizSatManager GetInstance()
        {
            if (teklifsizSatManager == null)
            {
                teklifsizSatManager = new TeklifsizSatManager();
            }
            return teklifsizSatManager;
        }
    }
}
