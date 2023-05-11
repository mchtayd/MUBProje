using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class GorevAtamaPersonelManager // : IRepository<GorevAtamaPersonel>
    {
        static GorevAtamaPersonelManager gorevAtamaPersonelManager;
        GorevAtamaPersonelDal gorevAtamaPersonelDal;

        private GorevAtamaPersonelManager()
        {
            gorevAtamaPersonelDal = GorevAtamaPersonelDal.GetInstance();
        }
        public string Add(GorevAtamaPersonel entity)
        {
            try
            {
                return gorevAtamaPersonelDal.Add(entity);
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
                return gorevAtamaPersonelDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string IslemAdimiSorumlusuUpdate(int id, string islemAdimiSorumlusu)
        {
            try
            {
                return gorevAtamaPersonelDal.IslemAdimiSorumlusuUpdate(id, islemAdimiSorumlusu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public GorevAtamaPersonel Get(int benzersiz, string departman)
        {
            try
            {
                return gorevAtamaPersonelDal.Get(benzersiz, departman);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GorevAtamaPersonel> GetList(int benzersiz,string departman)
        {
            try
            {
                return gorevAtamaPersonelDal.GetList(benzersiz, departman);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevAtamaGetList(int benzersizId)
        {
            try
            {
                return gorevAtamaPersonelDal.GorevAtamaGetList(benzersizId);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevAtamaAtolyeList()
        {
            try
            {
                return gorevAtamaPersonelDal.GorevAtamaAtolyeList();
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevAtamaPersonelGor(int benzersiz, string departman)
        {
            try
            {
                return gorevAtamaPersonelDal.GorevAtamaPersonelGor(benzersiz, departman);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimiGor(string adSoyad, string departman)
        {
            try
            {
                return gorevAtamaPersonelDal.IsAkisGorevlerim(adSoyad, departman);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }


        public string Update(GorevAtamaPersonel entity,string yapilanIslmeler="")
        {
            try
            {
                return gorevAtamaPersonelDal.Update(entity, yapilanIslmeler);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SureDuzelt(int id, string sure)
        {
            try
            {
                return gorevAtamaPersonelDal.SureDuzelt(id, sure);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevAtamaPersonelManager GetInstance()
        {
            if (gorevAtamaPersonelManager == null)
            {
                gorevAtamaPersonelManager = new GorevAtamaPersonelManager();
            }
            return gorevAtamaPersonelManager;
        }
    }
}
