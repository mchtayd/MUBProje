using DataAccess.Abstract;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class MalzemeTalepDal //: IRepository<MalzemeTalep>
    {
        static MalzemeTalepDal malzemeTalepDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private MalzemeTalepDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(MalzemeTalep entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeTalepEkle",
                    new SqlParameter("@malzemeKategori", entity.MalzemeKategorisi),
                    new SqlParameter("@talepEdenPersonel", entity.TalepEdenPersonel),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@talebiOlusturan", entity.TalebiOlusturan),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@masrafYeri", entity.MasrafYeri));

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

        public MalzemeTalep Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<MalzemeTalep> GetList()
        {
            try
            {
                List<MalzemeTalep> malzemeTaleps = new List<MalzemeTalep>();
                dataReader = sqlServices.StoreReader("MalzemeTalepList");
                while (dataReader.Read())
                {
                    malzemeTaleps.Add(new MalzemeTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["MALZEME_KATEGORISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TALEBI_OLUSTURAN"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["SAT_BILGISI"].ConInt(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["ISLEM_DURUMU"].ToString(),
                        dataReader["RED_GEREKCESI"].ToString(),
                        dataReader["DEPO_DURUM"].ToString()));
                }
                dataReader.Close();
                return malzemeTaleps;
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }
        public List<MalzemeTalep> GetListSat(string personeAdi)
        {
            try
            {
                List<MalzemeTalep> malzemeTaleps = new List<MalzemeTalep>();
                dataReader = sqlServices.StoreReader("MalzemeTalepListSat", new SqlParameter("@masrafYeriSorumlusu", personeAdi));
                while (dataReader.Read())
                {
                    malzemeTaleps.Add(new MalzemeTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["MALZEME_KATEGORISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TALEBI_OLUSTURAN"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["SAT_BILGISI"].ConInt(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["ISLEM_DURUMU"].ToString(),
                        dataReader["RED_GEREKCESI"].ToString(),
                        dataReader["DEPO_DURUM"].ToString()));
                }
                dataReader.Close();
                return malzemeTaleps;
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }
        public List<MalzemeTalep> GetListPersonel(string masrafYeriSorumlusu,string kategori)
        {
            try
            {
                List<MalzemeTalep> malzemeTaleps = new List<MalzemeTalep>();
                dataReader = sqlServices.StoreReader("MalzemeTalepPersonel", new SqlParameter("@masrafYeriSorumlusu", masrafYeriSorumlusu),
                    new SqlParameter("@kategori", kategori));
                while (dataReader.Read())
                {
                    malzemeTaleps.Add(new MalzemeTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["MALZEME_KATEGORISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TALEBI_OLUSTURAN"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["SAT_BILGISI"].ConInt(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["ISLEM_DURUMU"].ToString(),
                        dataReader["RED_GEREKCESI"].ToString(),
                        dataReader["DEPO_DURUM"].ToString()));
                }
                dataReader.Close();
                return malzemeTaleps;
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }
        public List<MalzemeTalep> GetListMasrafYeri()
        {
            try
            {
                List<MalzemeTalep> masrafYeriSorumlusu = new List<MalzemeTalep>();
                dataReader = sqlServices.StoreReader("MalzemeTalepMasrafYeriSorumlusu");
                while (dataReader.Read())
                {
                    masrafYeriSorumlusu.Add(new MalzemeTalep(dataReader["MALZEME_KATEGORISI"].ToString(), dataReader["TALEBI_OLUSTURAN"].ToString(), dataReader["BOLUM"].ToString(), dataReader["MASRAF_YERI"].ToString(),0));
                }
                dataReader.Close();
                return masrafYeriSorumlusu;
            }
            catch (Exception)
            {

                return new List<MalzemeTalep>();
            }
            

        }

        public List<MalzemeTalep> GetListIslemDurumu(string islemAdimi)
        {
            try
            {
                List<MalzemeTalep> malzemeTaleps = new List<MalzemeTalep>();
                dataReader = sqlServices.StoreReader("MalzemeTalepGetList", new SqlParameter("@islemDurumu", islemAdimi));
                while (dataReader.Read())
                {
                    malzemeTaleps.Add(new MalzemeTalep(
                        dataReader["ID"].ConInt(),
                        dataReader["MALZEME_KATEGORISI"].ToString(),
                        dataReader["TALEP_EDEN_PERSONEL"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TALEBI_OLUSTURAN"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["SAT_BILGISI"].ConInt(),
                        dataReader["MASRAF_YERI"].ToString(),
                        dataReader["ISLEM_DURUMU"].ToString(),
                        dataReader["RED_GEREKCESI"].ToString(),
                        dataReader["DEPO_DURUM"].ToString()));
                }
                dataReader.Close();
                return malzemeTaleps;
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }
        public int GetToplam(string masrafYeriSorumlusu, string kategori)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeTalepMasrafYeriPersonel", new SqlParameter("@masrafYeriSorumlusu", masrafYeriSorumlusu),
                    new SqlParameter("@kategori", kategori));
                int toplam = 0;
                while (dataReader.Read())
                {
                    toplam = dataReader["TOPLAM_ADET"].ConInt();
                }
                dataReader.Close();
                return toplam;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string Update(int id, string islemDurumu, string redGerekcesi)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeTalep",
                    new SqlParameter("@id", id),
                    new SqlParameter("@islemDurumu", islemDurumu),
                    new SqlParameter("@redGerekcesi", redGerekcesi));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static MalzemeTalepDal GetInstance()
        {
            if (malzemeTalepDal == null)
            {
                malzemeTalepDal = new MalzemeTalepDal();
            }
            return malzemeTalepDal;
        }
    }
}
