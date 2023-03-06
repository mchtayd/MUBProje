using DataAccess.Abstract;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.AnaSayfa
{
    public class ServerAyarlarDal //: IRepository<ServerAyarlar>
    {
        static ServerAyarlarDal serverAyarlarDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ServerAyarlarDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(ServerAyarlar entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ServerAyarlariAdd",
                    new SqlParameter("@personel", entity.PersonelAdi),
                    new SqlParameter("@onlineYenileme", entity.OnlineYenileme),
                    new SqlParameter("@bildirimAlma", entity.BildirimAlma));

                dataReader.Close();
                return "OK";
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

        public ServerAyarlar Get(string personel)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ServerAyarlariList", new SqlParameter("@personel", personel));
                ServerAyarlar item = null;
                while (dataReader.Read())
                {
                    item = new ServerAyarlar(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL"].ToString(),
                        dataReader["ONLINE_YENILEME"].ToString(),
                        dataReader["BILDIRIM_ALMA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
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
                dataReader = sqlServices.StoreReader("ServerAyarlariUpdate",
                    new SqlParameter("@personel", entity.PersonelAdi),
                    new SqlParameter("@onlineYenileme", entity.OnlineYenileme),
                    new SqlParameter("@bildirimAlma", entity.BildirimAlma));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ServerAyarlarDal GetInstance()
        {
            if (serverAyarlarDal == null)
            {
                serverAyarlarDal = new ServerAyarlarDal();
            }
            return serverAyarlarDal;
        }
    }
}
