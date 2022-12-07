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
    public class TeklifAlinanDal //: IRepository<TeklifAlinan>
    {

        static TeklifAlinanDal teklifiAlDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private TeklifAlinanDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(TeklifAlinan entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTeklifiAlinanEkle",
                    new SqlParameter("@stokno",entity.StokNo),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@birim",entity.Birim),
                    new SqlParameter("@firma1",entity.Firma1),
                    new SqlParameter("@firma2",entity.Firma2),
                    new SqlParameter("@firma3",entity.Firma3),
                    new SqlParameter("@bbf",entity.Bbf),
                    new SqlParameter("@btf",entity.Btf),
                    new SqlParameter("@ibf",entity.Ibf),
                    new SqlParameter("@itf",entity.Itf),
                    new SqlParameter("@ubf",entity.Ubf),
                    new SqlParameter("@utf",entity.Utf),
                    new SqlParameter("@siparisno",entity.Siparisno));
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
                dataReader = sqlServices.StoreReader("FiyatTeklifiAlSil",new SqlParameter("@siparisno",siparisNo));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatTekliflerDurumGuncelle(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTekliflerDurumGuncelle", new SqlParameter("@siparisNo", siparisNo));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatTekliflerDurumGuncelleOnay(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTekliflerDurumGuncelleOnay", new SqlParameter("@siparisNo", siparisNo));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public TeklifAlinan Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeklifAlinan> GetList(string siparisno)
        {
            try
            {
                List<TeklifAlinan> teklifs = new List<TeklifAlinan>();
                dataReader = sqlServices.StoreReader("SatGuncelleFirmalarList",new SqlParameter("@siparisno",siparisno));
                while (dataReader.Read())
                {
                    teklifs.Add(new TeklifAlinan(
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["FIRMA1"].ToString(),
                        dataReader["FIRMA2"].ToString(),
                        dataReader["FIRMA3"].ToString()));
                }
                dataReader.Close();
                return teklifs;
            }
            catch (Exception)
            {
                return new List<TeklifAlinan>();
            }
        }

        public string Update(TeklifAlinan entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("TeklifleriGuncelle",
                    new SqlParameter("@bbf", entity.Bbf),
                    new SqlParameter("@btf", entity.Btf),
                    new SqlParameter("@ibf", entity.Ibf),
                    new SqlParameter("@itf", entity.Itf),
                    new SqlParameter("@ubf", entity.Ubf),
                    new SqlParameter("@utf", entity.Utf),
                    new SqlParameter("@siparisno", entity.Siparisno),
                    new SqlParameter("@stokNo", entity.StokNo));

                dataReader.Close();
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DurumGuncelleRed(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTekliflerDurumGuncelle", new SqlParameter("siparisNo",siparisNo));

                dataReader.Close();
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static TeklifAlinanDal GetInstance()
        {
            if (teklifiAlDal == null)
            {
                teklifiAlDal = new TeklifAlinanDal();
            }
            return teklifiAlDal;
        }
        public string FirmaGuncelle(TeklifAlinan entity, string siparisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatGuncelleFirmalar",
                    new SqlParameter("@firma1", entity.Firma1),
                    new SqlParameter("@firma2", entity.Firma2),
                    new SqlParameter("@firma3", entity.Firma3),
                    new SqlParameter("@siparisno", siparisno),
                    new SqlParameter("@stokno",entity.StokNo));

                dataReader.Close();
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
