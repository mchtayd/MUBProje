using DataAccess;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class GorevAtamaManager // : IRepository<GorevAtama>
    {
        static GorevAtamaManager gorevAtamaManager;
        GorevAtamaDal gorevAtamaDal;

        private GorevAtamaManager()
        {
            gorevAtamaDal = GorevAtamaDal.GetInstance();
        }

        public string Add(GorevAtama entity)
        {
            try
            {
                return gorevAtamaDal.Add(entity);
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

        public GorevAtama Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GorevAtama> GetList(string adSoyad, int benzersizId)
        {
            try
            {
                return gorevAtamaDal.GetList(adSoyad, benzersizId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(GorevAtama entity)
        {
            throw new NotImplementedException();
        }
        public static GorevAtamaManager GetInstance()
        {
            if (gorevAtamaManager == null)
            {
                gorevAtamaManager = new GorevAtamaManager();
            }
            return gorevAtamaManager;
        }
    }
}
