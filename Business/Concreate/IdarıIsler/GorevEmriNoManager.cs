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
    public class GorevEmriNoManager //: IRepository<GorevEmriNo>
    {
        static GorevEmriNoManager gorevEmriNoManager;
        GorevEmriNoDal gorevEmriNoDal;
        private GorevEmriNoManager()
        {
            gorevEmriNoDal = GorevEmriNoDal.GetInstance();
        }
        public static GorevEmriNoManager GetInstance()
        {
            if (gorevEmriNoManager == null)
            {
                gorevEmriNoManager = new GorevEmriNoManager();
            }
            return gorevEmriNoManager;
        }

        public string Add(GorevEmriNo entity)
        {
            try
            {
                return gorevEmriNoDal.Add(entity);
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

        public GorevEmriNo Get(string durum)
        {
            try
            {
                return gorevEmriNoDal.Get(durum);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public GorevEmriNo Get2(string durum)
        {
            try
            {
                return gorevEmriNoDal.Get2(durum);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GorevEmriNo> GetList()
        {
            try
            {
                return gorevEmriNoDal.GetList();
            }
            catch (Exception)
            {
                return new List<GorevEmriNo>();
            }
        }

        public string Update(int id, string durum)
        {
            try
            {
                return gorevEmriNoDal.Update(id, durum);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateMevcutNo(int id, int mevcutNo)
        {
            try
            {
                return gorevEmriNoDal.UpdateMevcutNo(id, mevcutNo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
