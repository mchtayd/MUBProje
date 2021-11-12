using DataAccess.Abstract;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class TeklifsizSatDal //: IRepository<TeklifsizSat>
    {
        static TeklifsizSatDal teklifsizSatDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private TeklifsizSatDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(TeklifsizSat entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTeklifsizEkle", new SqlParameter("@stokno",entity.Stokno),new SqlParameter("@tanim",entity.Tanim),new SqlParameter("@miktar",entity.Miktar), new SqlParameter("@birim",entity.Birim), new SqlParameter("@tutar",entity.Tutar),new SqlParameter("@siparisno",entity.Siparisno));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatTeklifsizSil", new SqlParameter("@siparisno", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        public string SatMalzemeDurumGuncelle(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatTeklifsizDurumGuncelle", new SqlParameter("@siparisNo", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string SatMalzemeDurumGuncelleOnay(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatTeklifsizDurumGuncelleOnay", new SqlParameter("@siparisNo", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string SatDurumBasla(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatDurumBasla", new SqlParameter("@siparisNo", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public TeklifsizSat Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeklifsizSat> GetList(string siparisno)
        {
            try
            {
                List<TeklifsizSat> sats = new List<TeklifsizSat>();
                dataReader = sqlServices.StoreReader("SatTeklifsizListele",new SqlParameter("@siparisno",siparisno));
                while (dataReader.Read())
                {
                    sats.Add(new TeklifsizSat(dataReader["ID"].ConInt(), dataReader["STOK_NO"].ToString(), dataReader["TANIM"].ToString(), dataReader["MIKTAR"].ConDouble(), dataReader["BIRIM"].ToString(), dataReader["TUTAR"].ConDouble(), dataReader["SiparisNo"].ToString()));

                }
                dataReader.Close();
                return sats;

            }
            catch (Exception ex)
            {
                return new List<TeklifsizSat>();
            }
        }

        public string Update(TeklifsizSat entity, string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTeklifsizGuncelle", 
                    new SqlParameter("@stokno", entity.Stokno), 
                    new SqlParameter("@tutar", entity.Tutar), 
                    new SqlParameter("@siparisno", siparisno));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static TeklifsizSatDal GetInstance()
        {
            if (teklifsizSatDal == null)
            {
                teklifsizSatDal = new TeklifsizSatDal();
            }
            return teklifsizSatDal;
        }
    }
}
