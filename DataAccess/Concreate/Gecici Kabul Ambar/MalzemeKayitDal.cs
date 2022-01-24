using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Gecici_Kabul_Ambar
{
    public class MalzemeKayitDal // :IRepository<MalzemeKayit>
    {

        static MalzemeKayitDal malzemeKayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private MalzemeKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(MalzemeKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeKaydet",
                    new SqlParameter("@stokno",entity.Stokno),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@birim",entity.Birim),
                    new SqlParameter("@tedarikcifirma",entity.Tedarikcifirma),
                    new SqlParameter("@malzemeonarimdurumu",entity.Malzemeonarimdurumu),
                    new SqlParameter("@malzemeonarimyeri",entity.Malzemeonarımyeri),
                    new SqlParameter("@malzemeturu",entity.Malzemeturu),
                    new SqlParameter("@malzemetakipdurumu",entity.Malzemetakipdurumu),
                    new SqlParameter("@malzemerevizyon",entity.Malzemerevizyon),
                    new SqlParameter("@malzemekul",entity.Malzemekul),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@alternatifMalzeme",entity.AlternatifMalzeme),
                    new SqlParameter("@dosyayolu",entity.Dosyayolu));
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
                dataReader = sqlServices.StoreReader("MalzemeSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public MalzemeKayit Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeCek", new SqlParameter("@id", id));
                MalzemeKayit item = null;
                while (dataReader.Read())
                {
                    item = new MalzemeKayit(dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["MALZEME_ONARIM_DURUMU"].ToString(),
                        dataReader["MALZEME_ONARIM_YERI"].ToString(),
                        dataReader["MALZEME_TURU"].ToString(),
                        dataReader["MALZEME_TAKIP_DURUMU"].ToString(),
                        dataReader["MALZEME_REVIZYON"].ToString(),
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public MalzemeKayit MalzemeBul(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemelerList", new SqlParameter("@stokno", stokNo));
                MalzemeKayit item = null;
                while (dataReader.Read())
                {
                    item = new MalzemeKayit(dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["MALZEME_ONARIM_DURUMU"].ToString(),
                        dataReader["MALZEME_ONARIM_YERI"].ToString(),
                        dataReader["MALZEME_TURU"].ToString(),
                        dataReader["MALZEME_TAKIP_DURUMU"].ToString(),
                        dataReader["MALZEME_REVIZYON"].ToString(),
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MalzemeKayit> GetList(string stokNo)
        {
            try
            {
                List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
                dataReader = sqlServices.StoreReader("MalzemelerList", new SqlParameter("@stokno", stokNo));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new MalzemeKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["MALZEME_ONARIM_DURUMU"].ToString(),
                        dataReader["MALZEME_ONARIM_YERI"].ToString(),
                        dataReader["MALZEME_TURU"].ToString(),
                        dataReader["MALZEME_TAKIP_DURUMU"].ToString(),
                        dataReader["MALZEME_REVIZYON"].ToString(),
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString()));
                }
                dataReader.Close();
                return malzemeKayits;
            }
            catch (Exception ex)
            {
                return new List<MalzemeKayit>();
            }
        }

        public string Update(MalzemeKayit entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemelerGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@tedarikcifirma", entity.Tedarikcifirma),
                    new SqlParameter("@malzemeonarimdurumu", entity.Malzemeonarimdurumu),
                    new SqlParameter("@malzemeonarimyeri", entity.Malzemeonarımyeri),
                    new SqlParameter("@malzemeturu", entity.Malzemeturu),
                    new SqlParameter("@malzemetakipdurumu", entity.Malzemetakipdurumu),
                    new SqlParameter("@malzemerevizyon", entity.Malzemerevizyon),
                    new SqlParameter("@malzemekul", entity.Malzemekul),
                    new SqlParameter("@alternatifMalzeme", entity.AlternatifMalzeme),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static MalzemeKayitDal GetInstance()
        {
            if (malzemeKayitDal == null)
            {
                malzemeKayitDal = new MalzemeKayitDal();
            }
            return malzemeKayitDal;
        }
    }
}
