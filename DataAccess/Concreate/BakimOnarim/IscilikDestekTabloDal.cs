using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class IscilikDestekTabloDal //: IRepository<IscilikDestekTablo>
    {
        static IscilikDestekTabloDal destekTabloDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IscilikDestekTabloDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IscilikDestekTablo entity,string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikTabloEkle",
                    new SqlParameter("@adSoyad",entity.AdSoyad),
                    new SqlParameter("@gorevi",entity.Gorevi),
                    new SqlParameter("@personelBolum",entity.PersonelBolum),
                    new SqlParameter("@siparisNo", siparisNo));

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
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikTabloDelete",
                    new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikDestekTablo Get(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikTabloList",
                    new SqlParameter("@siparisNo",siparisNo));
                IscilikDestekTablo item = null;
                while (dataReader.Read())
                {
                    item = new IscilikDestekTablo(
                        dataReader["ID"].ConInt(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["GOREVI"].ToString(),
                        dataReader["PERSONEL_BOLUM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikDestekTablo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(IscilikDestekTablo entity,string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikTabloGuncelle",
                    new SqlParameter("@adSoyad", entity.AdSoyad),
                    new SqlParameter("@gorevi", entity.Gorevi),
                    new SqlParameter("@personelBolum", entity.PersonelBolum),
                    new SqlParameter("@siparisNo", siparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static IscilikDestekTabloDal GetInstance()
        {
            if (destekTabloDal == null)
            {
                destekTabloDal = new IscilikDestekTabloDal();
            }
            return destekTabloDal;
        }
    }
}
