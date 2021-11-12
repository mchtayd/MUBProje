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

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FiyatTeklifiAl Get(int id)
        {
            throw new NotImplementedException();
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
            catch (Exception ex)
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
        public string Update(FiyatTeklifiAl entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FiyatTeklifiAlGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanım", entity.Tanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@firma1", entity.Firma1),
                    new SqlParameter("@firma2", entity.Firma2),
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
