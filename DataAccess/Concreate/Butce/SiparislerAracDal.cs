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
    public class SiparislerAracDal //: IRepository<SiparislerArac>
    {
        static SiparislerAracDal siparislerAracDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SiparislerAracDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SiparislerArac entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SiparislerAracEkle",
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@mulkiyetBilgileri", entity.MulkiyetBilgileri),
                    new SqlParameter("@bolumu", entity.Bolumu),
                    new SqlParameter("@durumu", entity.Durum),
                    new SqlParameter("@siparis", entity.Siparis),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@zimmetliPersonel", entity.ZimmetliPersonel),
                    new SqlParameter("@masrafYeriSorumlusu", entity.MasYerSorumlusu));

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

        public SiparislerArac Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SiparislerArac> GetList(string siparis)
        {
            try
            {
                List<SiparislerArac> siparislerAracs = new List<SiparislerArac>();
                dataReader = sqlServices.StoreReader("SiparislerAraListele", new SqlParameter("@siparis", siparis));
                while (dataReader.Read())
                {
                    siparislerAracs.Add(new SiparislerArac(
                        dataReader["ID"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["BOLUMU"].ToString(),
                        dataReader["ZIMMETLI_PERSONEL"].ToString(),
                        dataReader["MASRAF_YERI_SORUMLUSU"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["SIPARIS"].ToString(),
                        dataReader["TARIH"].ConDate()));
                }
                dataReader.Close();
                return siparislerAracs;
            }
            catch (Exception)
            {
                return new List<SiparislerArac>();
            }
        }

        public string Update(SiparislerArac entity)
        {
            throw new NotImplementedException();
        }
        public static SiparislerAracDal GetInstance()
        {
            if (siparislerAracDal == null)
            {
                siparislerAracDal = new SiparislerAracDal();
            }
            return siparislerAracDal;
        }
    }
}
