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
    public class KonaklamaGecmisManager : IRepository<KonaklamaGecmis>
    {
        static KonaklamaGecmisManager konaklamaGecmisManager;
        KonaklamaGecmisDal konaklamaGecmisDal;
        string controlText;

        private KonaklamaGecmisManager()
        {
            konaklamaGecmisDal = KonaklamaGecmisDal.GetInstance();
        }
        public string Add(KonaklamaGecmis entity)
        {
            try
            {
                return konaklamaGecmisDal.Add(entity);
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

        public KonaklamaGecmis Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<KonaklamaGecmis> GetList()
        {
            try
            {
                return konaklamaGecmisDal.GetList();
            }
            catch (Exception)
            {
                return new List<KonaklamaGecmis>();
            }
        }

        public string Update(KonaklamaGecmis entity)
        {
            throw new NotImplementedException();
        }
        public static KonaklamaGecmisManager GetInstance()
        {
            if (konaklamaGecmisManager == null)
            {
                konaklamaGecmisManager = new KonaklamaGecmisManager();
            }
            return konaklamaGecmisManager;
        }
    }
}
