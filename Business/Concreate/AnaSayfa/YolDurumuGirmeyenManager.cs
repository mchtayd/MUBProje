using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class YolDurumuGirmeyenManager //: IRepository<YolDurumuGirmeyen>
    {
        static YolDurumuGirmeyenManager yolDurumuGirmeyenManager;
        YolDurumuGirmeyenDall yolDurumuGirmeyenDall;
        string controlText;

        private YolDurumuGirmeyenManager()
        {
            yolDurumuGirmeyenDall = YolDurumuGirmeyenDall.GetInstance();
        }
        public static YolDurumuGirmeyenManager GetInstance()
        {
            if (yolDurumuGirmeyenManager == null)
            {
                yolDurumuGirmeyenManager = new YolDurumuGirmeyenManager();
            }
            return yolDurumuGirmeyenManager;
        }

        public string Add(YolDurumuGirmeyen entity)
        {
            try
            {
                return yolDurumuGirmeyenDall.Add(entity);
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

        public YolDurumuGirmeyen Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<YolDurumuGirmeyen> GetList()
        {
            try
            {
                return yolDurumuGirmeyenDall.GetList();
            }
            catch (Exception)
            {
                return new List<YolDurumuGirmeyen>();
            }
        }
        public List<YolDurumuGirmeyen> GetListLoginOlmayan()
        {
            try
            {
                return yolDurumuGirmeyenDall.GetListLoginOlmayan();
            }
            catch (Exception)
            {
                return new List<YolDurumuGirmeyen>();
            }
        }
        public string Update(YolDurumuGirmeyen entity)
        {
            throw new NotImplementedException();
        }
    }
}
