using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class ServerAyarlarManager //: IRepository<ServerAyarlar>
    {
        static ServerAyarlarManager serverAyarlarManager;
        ServerAyarlarDal serverAyarlarDal;

        private ServerAyarlarManager()
        {
            serverAyarlarDal = ServerAyarlarDal.GetInstance();
        }
        public string Add(ServerAyarlar entity)
        {
            try
            {
                return serverAyarlarDal.Add(entity);
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

        public ServerAyarlar Get(string personelAd)
        {
            try
            {
                return serverAyarlarDal.Get(personelAd);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ServerAyarlar> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(ServerAyarlar entity)
        {
            try
            {
                return serverAyarlarDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ServerAyarlarManager GetInstance()
        {
            if (serverAyarlarManager == null)
            {
                serverAyarlarManager = new ServerAyarlarManager();
            }
            return serverAyarlarManager;
        }
    }
}
