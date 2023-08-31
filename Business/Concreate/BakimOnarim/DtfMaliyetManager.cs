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
    public class DtfMaliyetManager //: IRepository<DtfMaliyet>
    {
        static DtfMaliyetManager dtfMaliyetManager;
        DtfMaliyetDal dtfMaliyetDal;

        private DtfMaliyetManager()
        {
            dtfMaliyetDal = DtfMaliyetDal.GetInstance();
        }
        public string Add(DtfMaliyet entity)
        {
            try
            {
                return dtfMaliyetDal.Add(entity);
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
                return dtfMaliyetDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeleteVeriler(int id)
        {
            try
            {
                return dtfMaliyetDal.DeleteVeriler(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DtfMaliyet Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DtfMaliyet> GetList(int benzserizId, string sayfa)
        {
            try
            {
                return dtfMaliyetDal.GetList(benzserizId, sayfa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(DtfMaliyet entity)
        {
            try
            {
                return dtfMaliyetManager.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DtfMaliyetManager GetInstance()
        {
            if (dtfMaliyetManager == null)
            {
                dtfMaliyetManager = new DtfMaliyetManager();
            }
            return dtfMaliyetManager;
        }
    }
}
