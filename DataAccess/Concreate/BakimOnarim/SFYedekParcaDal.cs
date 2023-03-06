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
    public class SFYedekParcaDal //: IRepository<SFYedekPaca>
    {
        static SFYedekParcaDal sFYedekParcaDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SFYedekParcaDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SFYedekPaca entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ServisFormuYedekParcaEkle",
                    new SqlParameter("@parcaKodu",entity.ParcaKodu),
                    new SqlParameter("@kullanilanMalzeme",entity.KullanilanMalzeme),
                    new SqlParameter("@adet",entity.Adet),
                    new SqlParameter("@siparisNo",entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisNo)
        {
            try
            {
                sqlServices.Stored("ServisFormuYedekParcaSil",new SqlParameter("@siparisNo",siparisNo));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SFYedekPaca Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SFYedekPaca> GetList(string siparisNo)
        {
            try
            {
                List<SFYedekPaca> sFYedekPacas = new List<SFYedekPaca>();
                dataReader = sqlServices.StoreReader("ServisFormuYedekParcaListele",new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    sFYedekPacas.Add(new SFYedekPaca(
                        dataReader["ID"].ConInt(),
                        dataReader["PARCA_KODU"].ToString(),
                        dataReader["KULLANILAN_MALZEME"].ToString(),
                        dataReader["ADET"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return sFYedekPacas;
            }
            catch (Exception)
            {
                return new List<SFYedekPaca>();
            }
        }

        public string Update(SFYedekPaca entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ServisFormuYedekParcaGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@parcaKodu", entity.ParcaKodu),
                    new SqlParameter("@kullanilanMalzeme", entity.KullanilanMalzeme),
                    new SqlParameter("@adet", entity.Adet));

                dataReader.Close();
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SFYedekParcaDal GetInstance()
        {
            if (sFYedekParcaDal == null)
            {
                sFYedekParcaDal = new SFYedekParcaDal();
            }
            return sFYedekParcaDal;
        }
    }
}
