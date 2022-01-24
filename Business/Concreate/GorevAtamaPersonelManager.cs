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
            throw new NotImplementedException();
        }

        public GorevAtamaPersonel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GorevAtamaPersonel> GetList(int benzersiz,string departman,string sure)
        {
            try
            {
                return gorevAtamaPersonelDal.GetList(benzersiz, departman, sure);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }

        public string Update(GorevAtamaPersonel entity)
        {
            try
            {
                return gorevAtamaPersonelDal.Update(entity);
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
