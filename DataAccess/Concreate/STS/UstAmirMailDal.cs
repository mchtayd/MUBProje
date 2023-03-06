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
    public class UstAmirMailDal // : IRepository<UstAmirMail>
    {
        static UstAmirMailDal ustAmirMailDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private UstAmirMailDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(UstAmirMail entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UstAmirMail Get(string personelad)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelAmiriMail", new SqlParameter("@personelAd", personelad));
                UstAmirMail item = null;
                while (dataReader.Read())
                {
                    item = new UstAmirMail(
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["ID"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UstAmirMail> GetList(int personelid)
        {
            try
            {
                List<UstAmirMail> ustAmirMails = new List<UstAmirMail>();
                dataReader = sqlServices.StoreReader("UstAmirMail",new SqlParameter("@personelid",personelid));
                while (dataReader.Read())
                {
                    ustAmirMails.Add(new UstAmirMail(
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["OFICE_MAIL"].ToString(),
                        dataReader["SIRKET_BOLUM"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["YETKILI_ID"].ConInt()));
                }
                dataReader.Close();
                return ustAmirMails;
            }
            catch (Exception)
            {
                return new List<UstAmirMail>();
            }
        }

        public string Update(UstAmirMail entity)
        {
            throw new NotImplementedException();
        }
        public static UstAmirMailDal GetInstance()
        {
            if (ustAmirMailDal == null)
            {
                ustAmirMailDal = new UstAmirMailDal();
            }
            return ustAmirMailDal;
        }
    }
}
