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
    public class SirketBolumManager //: IRepository<SirketBolum>
    {

        static SirketBolumManager sirketBolumManager;
        SirketBolumDal sirketBolumDal;

        private SirketBolumManager()
        {
            sirketBolumDal = SirketBolumDal.GetInstance();
        }

        public string Add(SirketBolum entity)
        {
            try
            {
                return sirketBolumDal.Add(entity);
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
                return sirketBolumDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SirketBolum Get(int id)
        {
            try
            {
                return sirketBolumDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SirketBolum> GetList(string bagliOlduguBolum)
        {
            try
            {
                return sirketBolumDal.GetList(bagliOlduguBolum);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SirketBolum> GetListBolumNo(int bolumNo)
        {
            try
            {
                return sirketBolumDal.GetListBolumNo(bolumNo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(SirketBolum entity)
        {
            try
            {
                return sirketBolumDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SirketBolumManager GetInstance()
        {
            if (sirketBolumManager == null)
            {
                sirketBolumManager = new SirketBolumManager();
            }
            return sirketBolumManager;
        }
    }
}
