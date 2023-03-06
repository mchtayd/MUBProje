using DataAccess.Abstract;
using DataAccess.Concreate.STS;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class TeklifiAlinanManager //: IRepository<TeklifAlinan>
    {
        static TeklifiAlinanManager fiyatTeklifiAlManager;
        TeklifAlinanDal teklifAlinanDal;

        private TeklifiAlinanManager()
        {
            teklifAlinanDal = TeklifAlinanDal.GetInstance();
        }

        public string Add(TeklifAlinan entity,string siparisNo)
        {
            try
            {
                return teklifAlinanDal.Add(entity, siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisNo)
        {
            try
            {
                return teklifAlinanDal.Delete(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatTekliflerDurumGuncelle(string siparisNo)
        {
            try
            {
                return teklifAlinanDal.SatTekliflerDurumGuncelle(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatTekliflerDurumGuncelleOnay(string siparisNo)
        {
            try
            {
                return teklifAlinanDal.SatTekliflerDurumGuncelleOnay(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public TeklifAlinan Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeklifAlinan> GetList(string siparisno)
        {
            try
            {
                return teklifAlinanDal.GetList(siparisno);
            }
            catch
            {
                return new List<TeklifAlinan>();
            }
        }

        public string Update(TeklifAlinan entity)
        {
            try
            {
                return teklifAlinanDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DurumGuncelleRed(string siparisNo)
        {
            try
            {
                return teklifAlinanDal.DurumGuncelleRed(siparisNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static TeklifiAlinanManager GetInstance()
        {
            if (fiyatTeklifiAlManager == null)
            {
                fiyatTeklifiAlManager = new TeklifiAlinanManager();
            }
            return fiyatTeklifiAlManager;
        }
        public string FirmaGuncelle(TeklifAlinan entity, string siparisno)
        {
            try
            {
                return teklifAlinanDal.FirmaGuncelle(entity, siparisno);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
