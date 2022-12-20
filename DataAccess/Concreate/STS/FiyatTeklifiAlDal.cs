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
    public class FiyatTeklifiAlDal //: IRepository<FiyatTeklifiAl>
    {
        static FiyatTeklifiAlDal teklifiAlDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private FiyatTeklifiAlDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(FiyatTeklifiAl entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FiyatTeklifiAlEkle",
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanım", entity.Tanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@firma1", entity.Firma1),
                    new SqlParameter("@firma2", entity.Firma2),
                    new SqlParameter("@siparisNo", entity.Siparisno),
                    new SqlParameter("@firma3", entity.Firma3),
                    new SqlParameter("@teklifdurumu", entity.Teklifdurumu));

                dataReader.Close();
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TeklifGir(FiyatTeklifiAl entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FiyatTeklifiGir",
                    new SqlParameter("@stokNo", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@birimFiyat", entity.Firma1),
                    new SqlParameter("@toplamFiyat", entity.Firma2),
                    new SqlParameter("@firma", entity.Siparisno));

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

        public FiyatTeklifiAl Get(string siparisNo, string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FiyatTeklifiAlGet", new SqlParameter("@siparisNo", siparisNo), new SqlParameter("@stokNo", stokNo));
                FiyatTeklifiAl item = null;
                while (dataReader.Read())
                {
                    item = new FiyatTeklifiAl(
                        dataReader["ID"].ConInt(),
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
                        dataReader["TeklifDurumu"].ToString(),
                        dataReader["OnaylananTeklif"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FiyatTeklifiAl> GetList(string durum, string siparisNo)
        {
            try
            {
                List<FiyatTeklifiAl> fiyats = new List<FiyatTeklifiAl>();
                dataReader = sqlServices.StoreReader("FiyatTeklifiAlListele", new SqlParameter("@teklifdurumu", durum), new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    fiyats.Add(new FiyatTeklifiAl(
                        dataReader["ID"].ConInt(),
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
                        dataReader["TeklifDurumu"].ToString(),
                        dataReader["OnaylananTeklif"].ConInt()));
                }
                dataReader.Close();
                return fiyats;

            }
            catch (Exception)
            {
                return new List<FiyatTeklifiAl>();
            }
        }
        
        public string UpdateTekifDurum(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatTeklifDurumBekle", new SqlParameter("@siparisno", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(FiyatTeklifiAl entity,int onayliTeklif)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FiyatTeklifiAlGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanım", entity.Tanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@firma", entity.Firma1),
                    new SqlParameter("@bf", entity.Bbf),
                    new SqlParameter("@tf", entity.Btf),
                    new SqlParameter("@onayliTeklif", onayliTeklif));

                dataReader.Close();
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DevamEdenFiyateklifiGuncelle(FiyatTeklifiAl entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DevamEdenFiyatTeklifiGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@stokNo", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@firma1", entity.Firma1),
                    new SqlParameter("@bbf", entity.Bbf),
                    new SqlParameter("@btf", entity.Btf),
                    new SqlParameter("@firma2", entity.Firma2),
                    new SqlParameter("@ibf",entity.Ibf),
                    new SqlParameter("@itf",entity.Itf),
                    new SqlParameter("@firma3",entity.Firma3),
                    new SqlParameter("@ubf",entity.Ubf),
                    new SqlParameter("@utf",entity.Utf));

                dataReader.Close();
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static FiyatTeklifiAlDal GetInstance()
        {
            if (teklifiAlDal == null)
            {
                teklifiAlDal = new FiyatTeklifiAlDal();
            }
            return teklifiAlDal;
        }
        public void DurumGuncelle(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FiyatTeklifiDurumGuncelle", new SqlParameter("@id", id));
                dataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
