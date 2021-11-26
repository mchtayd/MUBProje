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
    public class SatMailDal //: IRepository<SatMail>
    {
        static SatMailDal satMailDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SatMailDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SatMail entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatMail Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatMail> GetList()
        {
            try
            {
                List<SatMail> altYuklenicis = new List<SatMail>();
                dataReader = sqlServices.StoreReader("MailOnizleme");
                while (dataReader.Read())
                {
                    altYuklenicis.Add(new SatMail(
                    dataReader["STOK_NO"].ToString(),
                    dataReader["TANIM"].ToString(),
                    dataReader["MIKTAR"].ConInt(),
                    dataReader["BIRIM"].ToString(),
                    dataReader["FIRMA1"].ToString(),
                    dataReader["BBF"].ConDouble(),
                    dataReader["BTF"].ConDouble(),
                    dataReader["FIRMA2"].ToString(),
                    dataReader["IBF"].ConDouble(),
                    dataReader["ITF"].ConDouble(),
                    dataReader["FIRMA3"].ToString(),
                    dataReader["UBF"].ConDouble(),
                    dataReader["UTF"].ConDouble(),
                    dataReader["SiparisNo"].ToString(),
                    dataReader["GEREKCE"].ToString(),
                    dataReader["US_BOLGESI"].ToString(),
                    dataReader["SAT_NO"].ConInt()));
                }
                dataReader.Close();
                return altYuklenicis;
            }
            catch (Exception)
            {
                return new List<SatMail>();
            }
        }

        public string Update(SatMail entity)
        {
            throw new NotImplementedException();
        }
        public static SatMailDal GetInstance()
        {
            if (satMailDal == null)
            {
                satMailDal = new SatMailDal();
            }
            return satMailDal;
        }
    }
}
