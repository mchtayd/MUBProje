using DataAccess.Abstract;
using DataAccess.Database;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class SatOnayTarihiDal //: IRepository<SatOnayTarihi>
    {
        static SatOnayTarihiDal satOnayTarihiDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SatOnayTarihiDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SatOnayTarihi entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTarihleriOlusturmaTarihi", 
                    new SqlParameter("@olusturmaTarihi",DateTime.Now),
                    new SqlParameter("@siparisNo",entity.SiparisNo));

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

        public SatOnayTarihi Get(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTarihleriList");
                SatOnayTarihi item = null;
                while (dataReader.Read())
                {
                    item = new SatOnayTarihi(
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["OLUSTURMA_TARIHI"].ConDate(),
                        dataReader["BASLAMA_TARIHI"].ConDate(),
                        dataReader["ONAY_TARIHI"].ConDate());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SatOnayTarihi> GetList()
        {
            throw new NotImplementedException();
        }

        public string UpdateBaslama(SatOnayTarihi entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTarihleriBaslamaTarihi",
                    new SqlParameter("@baslamaTarihi",DateTime.Now),
                    new SqlParameter("@siparisNo",entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateOnay(SatOnayTarihi entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTarihleriOnayTarihi",
                    new SqlParameter("@onayTarihi", DateTime.Now),
                    new SqlParameter("@siparisNo", entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SatOnayTarihiDal GetInstance()
        {
            if (satOnayTarihiDal == null)
            {
                satOnayTarihiDal = new SatOnayTarihiDal();
            }
            return satOnayTarihiDal;
        }
    }
}
