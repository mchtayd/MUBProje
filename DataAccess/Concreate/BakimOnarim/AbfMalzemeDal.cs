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
    public class AbfMalzemeDal //: IRepository<AbfMalzeme>
    {
        static AbfMalzemeDal abfMalzemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AbfMalzemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string AddSokulen(AbfMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMazlemeSokulenEkle",
                    new SqlParameter("@stokNo",entity.SokulenStokNo),
                    new SqlParameter("@tanim",entity.SokulenTanim),
                    new SqlParameter("@seriNo",entity.SokulenSeriNo),
                    new SqlParameter("@miktar",entity.SokulenMiktar),
                    new SqlParameter("@birim",entity.SokulenBirim),
                    new SqlParameter("@calismaSaati",entity.SokulenCalismaSaati),
                    new SqlParameter("@revizyonNo",entity.SokulenRevizyon),
                    new SqlParameter("@calismaDurumu",entity.CalismaDurumu),
                    new SqlParameter("@fizikselDurumu",entity.FizikselDurum),
                    new SqlParameter("@yapilacakIslem",entity.YapilacakIslem),
                    new SqlParameter("@benzersizId",entity.BenzersizId));

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
                sqlServices.Stored("AbfMazlemeSil", new SqlParameter("@benzersizId", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeleteTekMalzemeSil(int id)
        {
            try
            {
                sqlServices.Stored("AbfTekMalzemeSil", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AbfMalzeme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AbfMalzeme> GetList(int benzersizId, string teminDurumu)
        {
            try
            {
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("AbfMazlemeList", new SqlParameter("@benzersizId", benzersizId), new SqlParameter("@teminDurumu", teminDurumu));
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_CALISMA_SAATI"].ConDouble(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["CALISMA_DURUMU"].ToString(),
                        dataReader["FIZIKSEL_DURUMU"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["TAKILAN_STOK_NO"].ToString(),
                        dataReader["TAKILAN_TANIM"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_MIKTAR"].ConInt(),
                        dataReader["TAKILAN_BIRIM"].ToString(),
                        dataReader["TAKILAN_CALISMA_SAATI"].ConDouble(),
                        dataReader["TAKILAN_REVIZYON_NO"].ToString(),
                        dataReader["TEMIN_DURUMU"].ToString()));
                }
                dataReader.Close();
                return abfMalzemes;
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }

        public List<AbfMalzeme> TeminGetList(string teminDurumu, int abfNo)
        {
            try
            {
                List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
                dataReader = sqlServices.StoreReader("DepoTeminGor", new SqlParameter("@teminDurumu", teminDurumu), new SqlParameter("@abfNo", abfNo));
                while (dataReader.Read())
                {
                    abfMalzemes.Add(new AbfMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConInt(),
                        dataReader["SOKULEN_BIRIM"].ToString(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["TEMINE_ATILMA_TARIHI"].ConDate(),
                        dataReader["TEMIN_DURUMU"].ToString()));
                }
                dataReader.Close();
                return abfMalzemes;
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }

        public string UpdateTakilan(AbfMalzeme entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMazlemeTakilanGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@stokNo", entity.TakilanStokNo),
                    new SqlParameter("@tanim", entity.TakilanTanim),
                    new SqlParameter("@seriNo", entity.TakilanSeriNo),
                    new SqlParameter("@miktar",entity.TakilanMiktar),
                    new SqlParameter("@birim",entity.TakilanBirim),
                    new SqlParameter("@calismaSaati",entity.TakilanCalismaSaati),
                    new SqlParameter("@revizyonNo",entity.TakilanRevizyon));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddTakilan(AbfMalzeme entity,int benzersizId)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMazlemeTakilanEkle",
                    new SqlParameter("@benzersizId",benzersizId),
                    new SqlParameter("@stokNo", entity.TakilanStokNo),
                    new SqlParameter("@tanim", entity.TakilanTanim),
                    new SqlParameter("@seriNo", entity.TakilanSeriNo),
                    new SqlParameter("@miktar", entity.TakilanMiktar),
                    new SqlParameter("@birim", entity.TakilanBirim),
                    new SqlParameter("@calismaSaati", entity.TakilanCalismaSaati),
                    new SqlParameter("@revizyonNo", entity.TakilanRevizyon));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TeminBilgisi(int id, string teminBilgisi,string temineGonderen)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfMalzemeTemin",
                    new SqlParameter("@id", id),
                    new SqlParameter("@teminBilgisi", teminBilgisi),
                    new SqlParameter("@temineGonderen", temineGonderen));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AbfMalzemeDal GetInstance()
        {
            if (abfMalzemeDal == null)
            {
                abfMalzemeDal = new AbfMalzemeDal();
            }
            return abfMalzemeDal;
        }
    }
}
