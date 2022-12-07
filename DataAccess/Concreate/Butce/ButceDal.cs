using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Butce
{
    public class ButceDal //: IRepository<ButceKayit>
    {
        static ButceDal butceDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ButceDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(ButceKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ButceAdd",
                    new SqlParameter("@yil",entity.Yil),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@butceTanim",entity.ButceTanim),
                    new SqlParameter("@siparisNo",entity.SiparisNo),
                    new SqlParameter("@kisiSayisi",entity.KisiSayisi),
                    new SqlParameter("@butceTutarı",entity.ButceTutari),
                    new SqlParameter("@butceTutariAylik",entity.ButceTutariAylik),
                    new SqlParameter("@butceTutariYillik",entity.ButceTutariYillik));

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
            try
            {
                sqlServices.Stored("ButceUDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ButceKayit Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ButceGetList", new SqlParameter("@id", id));
                ButceKayit item = null;
                while (dataReader.Read())
                {
                    item = new ButceKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["YIL"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["BUTCE_TANIM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["KISI_SAYISI"].ConInt(),
                        dataReader["BUTCE_TUTARI"].ToString(),
                        dataReader["BUTCE_TUTARI_AYLIK"].ToString(),
                        dataReader["BUTCE_TUTARI_YILLIK"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ButceKayit> GetList()
        {
            try
            {
                List<ButceKayit> butceKayits = new List<ButceKayit>();
                dataReader = sqlServices.StoreReader("ButceGetList");
                while (dataReader.Read())
                {
                    butceKayits.Add(new ButceKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["YIL"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["BUTCE_TANIM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["KISI_SAYISI"].ConInt(),
                        dataReader["BUTCE_TUTARI"].ToString(),
                        dataReader["BUTCE_TUTARI_AYLIK"].ToString(),
                        dataReader["BUTCE_TUTARI_YILLIK"].ToString()));
                }
                dataReader.Close();
                return butceKayits;

            }
            catch (Exception)
            {
                return new List<ButceKayit>();
            }
        }

        public string Update(ButceKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ButceUpdate",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@yil", entity.Yil),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@butceTanim", entity.ButceTanim),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@kisiSayisi", entity.KisiSayisi),
                    new SqlParameter("@butceTutarı", entity.ButceTutari),
                    new SqlParameter("@butceTutariAylik", entity.ButceTutariAylik),
                    new SqlParameter("@butceTutariYillik", entity.ButceTutariYillik));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ButceDal GetInstance()
        {
            if (butceDal == null)
            {
                butceDal = new ButceDal();
            }
            return butceDal;
        }
    }
}
