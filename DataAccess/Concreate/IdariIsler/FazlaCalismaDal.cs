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
    public class FazlaCalismaDal //: IRepository<FazlaCalisma>
    {
        static FazlaCalismaDal fazlaCalismaDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private FazlaCalismaDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static FazlaCalismaDal GetInstance()
        {
            if (fazlaCalismaDal == null)
            {
                fazlaCalismaDal = new FazlaCalismaDal();
            }
            return fazlaCalismaDal;
        }

        public string Add(FazlaCalisma entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FazlaCalismaAdd",
                    new SqlParameter("@personelAd", entity.PersonelAd),
                    new SqlParameter("@personel_Bolum", entity.PersonelBolum),
                    new SqlParameter("@fazlaCalismaNedeni", entity.FazlaCalismaNedeni),
                    new SqlParameter("@basTarihi", entity.MesaiBasTarihi),
                    new SqlParameter("@bitTarihi", entity.MesaiBitTarihi),
                    new SqlParameter("@toplamMesaiSaati", entity.ToplamMesaiSaati),
                    new SqlParameter("@toplamHakEdilenIzin", entity.ToplamHakEdilenIzin));

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
                sqlServices.Stored("FazlaCalismaDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public FazlaCalisma Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FazlaCalismaGetList", new SqlParameter("@id", id));
                FazlaCalisma fazlaCalisma = null;
                while (dataReader.Read())
                {
                    fazlaCalisma = new FazlaCalisma(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_BOLUM"].ToString(),
                        dataReader["FAZLA_CALISMA_NEDENI"].ToString(),
                        dataReader["MESAI_BASLANGIC_TARIHI"].ConDate(),
                        dataReader["MESAI_BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_MESAI_SAATI"].ToString(),
                        dataReader["TOPLAM_HAK_EDILEN_IZIN"].ToString(),
                        dataReader["ONAY_DURUMU"].ToString(),
                        dataReader["ONAY_VEREN"].ToString());
                }
                dataReader.Close();
                return fazlaCalisma;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public FazlaCalisma GetSon(string personelAdi)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FazlaCalismaSonKayit", new SqlParameter("@personelAdi", personelAdi));
                FazlaCalisma fazlaCalisma = null;
                while (dataReader.Read())
                {
                    fazlaCalisma = new FazlaCalisma(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_BOLUM"].ToString(),
                        dataReader["FAZLA_CALISMA_NEDENI"].ToString(),
                        dataReader["MESAI_BASLANGIC_TARIHI"].ConDate(),
                        dataReader["MESAI_BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_MESAI_SAATI"].ToString(),
                        dataReader["TOPLAM_HAK_EDILEN_IZIN"].ToString(),
                        dataReader["ONAY_DURUMU"].ToString(),
                        dataReader["ONAY_VEREN"].ToString());
                }
                dataReader.Close();
                return fazlaCalisma;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FazlaCalisma> GetList()
        {
            try
            {
                List<FazlaCalisma> fazlaCalismas = new List<FazlaCalisma>();
                dataReader = sqlServices.StoreReader("FazlaCalismaGetList");
                while (dataReader.Read())
                {
                    fazlaCalismas.Add(new FazlaCalisma(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_BOLUM"].ToString(),
                        dataReader["FAZLA_CALISMA_NEDENI"].ToString(),
                        dataReader["MESAI_BASLANGIC_TARIHI"].ConDate(),
                        dataReader["MESAI_BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_MESAI_SAATI"].ToString(),
                        dataReader["TOPLAM_HAK_EDILEN_IZIN"].ToString(),
                        dataReader["ONAY_DURUMU"].ToString(),
                        dataReader["ONAY_VEREN"].ToString()));
                }
                dataReader.Close();
                return fazlaCalismas;

            }
            catch (Exception)
            {
                return new List<FazlaCalisma>();
            }
        }

        public List<FazlaCalisma> GetListPersonel(string personel)
        {
            try
            {
                List<FazlaCalisma> fazlaCalismas = new List<FazlaCalisma>();
                dataReader = sqlServices.StoreReader("FazlaCalismaGetList", new SqlParameter("@personelAd", personel));
                while (dataReader.Read())
                {
                    fazlaCalismas.Add(new FazlaCalisma(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_BOLUM"].ToString(),
                        dataReader["FAZLA_CALISMA_NEDENI"].ToString(),
                        dataReader["MESAI_BASLANGIC_TARIHI"].ConDate(),
                        dataReader["MESAI_BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_MESAI_SAATI"].ToString(),
                        dataReader["TOPLAM_HAK_EDILEN_IZIN"].ToString(),
                        dataReader["ONAY_DURUMU"].ToString(),
                        dataReader["ONAY_VEREN"].ToString()));
                }
                dataReader.Close();
                return fazlaCalismas;

            }
            catch (Exception)
            {
                return new List<FazlaCalisma>();
            }
        }

        public List<FazlaCalisma> GetListOnaylanacaklar()
        {
            try
            {
                List<FazlaCalisma> fazlaCalismas = new List<FazlaCalisma>();
                dataReader = sqlServices.StoreReader("FazlaCalismaOnaylanacaklar");
                while (dataReader.Read())
                {
                    fazlaCalismas.Add(new FazlaCalisma(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_BOLUM"].ToString(),
                        dataReader["FAZLA_CALISMA_NEDENI"].ToString(),
                        dataReader["MESAI_BASLANGIC_TARIHI"].ConDate(),
                        dataReader["MESAI_BITIS_TARIHI"].ConDate(),
                        dataReader["TOPLAM_MESAI_SAATI"].ToString(),
                        dataReader["TOPLAM_HAK_EDILEN_IZIN"].ToString(),
                        dataReader["ONAY_DURUMU"].ToString(),
                        dataReader["ONAY_VEREN"].ToString()));
                }
                dataReader.Close();
                return fazlaCalismas;

            }
            catch (Exception)
            {
                return new List<FazlaCalisma>();
            }
        }


        public string Update(FazlaCalisma entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FazlaCalismaUpdate",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@personelAd", entity.PersonelAd),
                    new SqlParameter("@personel_Bolum", entity.PersonelBolum),
                    new SqlParameter("@fazlaCalismaNedeni", entity.FazlaCalismaNedeni),
                    new SqlParameter("@basTarihi", entity.MesaiBasTarihi),
                    new SqlParameter("@bitTarihi", entity.MesaiBitTarihi),
                    new SqlParameter("@toplamMesaiSaati", entity.ToplamMesaiSaati),
                    new SqlParameter("@toplamHakEdilenIzin", entity.ToplamHakEdilenIzin),
                    new SqlParameter("@onayDurum", entity.OnayDurumu),
                    new SqlParameter("@onayVeren", entity.OnayVeren));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateOnay(int id)
        {
            try
            {
                sqlServices.Stored("FazlaCalismaOnay", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
