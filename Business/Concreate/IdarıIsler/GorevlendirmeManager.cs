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
    public class GorevlendirmeManager //: IRepository<Gorevlendirme>
    {
        static GorevlendirmeManager gorevlendirmeManager;
        GorevlendirmeDal gorevlendirmeDal;

        private GorevlendirmeManager()
        {
            gorevlendirmeDal = GorevlendirmeDal.GetInstance();
        }

        public string Add(Gorevlendirme entity)
        {
            try
            {
                return gorevlendirmeDal.Add(entity);
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
                return gorevlendirmeDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Gorevlendirme Get(int isAkisNo)
        {
            try
            {
                return gorevlendirmeDal.Get(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<string> Yillar()
        {
            try
            {
                return gorevlendirmeDal.Yillar();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public List<Gorevlendirme> GetList(string durum, int yil)
        {
            try
            {
                return gorevlendirmeDal.GetList(durum, yil.ToString());
            }
            catch (Exception)
            {
                return new List<Gorevlendirme>();
            }
        }

        public string Update(Gorevlendirme entity)
        {
            try
            {
                return gorevlendirmeDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevlendirmeManager GetInstance()
        {
            if (gorevlendirmeManager == null)
            {
                gorevlendirmeManager = new GorevlendirmeManager();
            }
            return gorevlendirmeManager;
        }
    }
}
