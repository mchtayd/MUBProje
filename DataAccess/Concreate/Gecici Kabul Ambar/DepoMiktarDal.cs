using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig.Graphics.Operations.General;

namespace DataAccess.Concreate.Gecici_Kabul_Ambar
{
    public class DepoMiktarDal // : IRepository<DepoMiktar>
    {
        static DepoMiktarDal depoMiktarDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DepoMiktarDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(DepoMiktar entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMiktarKayit", 
                    new SqlParameter("@stokNo",entity.StokNo),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@lotNo",entity.LotNo),
                    new SqlParameter("@revizyon",entity.Revizyon),
                    new SqlParameter("@sonIslemTarihi",entity.SonIslemTarihi),
                    new SqlParameter("@sonIslemYapan",entity.SonIslemYapan),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@depoNo",entity.DepoNo),
                    new SqlParameter("@depoAdresi",entity.DepoAdresi),
                    new SqlParameter("@depoLokasyon",entity.DepoLokasyon),
                    new SqlParameter("@aciklama",entity.Aciklama));

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
                sqlServices.Stored("DepoMiktarSil",new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DepoMiktar Get(string stokNo,string depoNo,string seriNo,string lotNo,string revizyon)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMiktarList",new SqlParameter("@stokNo",stokNo),new SqlParameter("@depoNo",depoNo),
                    new SqlParameter("@seriNo",seriNo),new SqlParameter("@lotNo",lotNo),new SqlParameter("@revizyon",revizyon));
                DepoMiktar item = null;
                while (dataReader.Read())
                {
                    item = new DepoMiktar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["SON_ISLEM_TARIHI"].ConDate(),
                        dataReader["SON_ISLEM_YAPAN"].ToString(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["REZERVE_DURUMU"].ToString(),
                        dataReader["REZERVE_ID"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DepoMiktar GetEdit(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMiktarGetList", new SqlParameter("@id", id));
                DepoMiktar item = null;
                while (dataReader.Read())
                {
                    item = new DepoMiktar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["SON_ISLEM_TARIHI"].ConDate(),
                        dataReader["SON_ISLEM_YAPAN"].ToString(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["REZERVE_DURUMU"].ToString(),
                        dataReader["REZERVE_ID"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DepoMiktar GetBarkodLokasyonBul(string stokNo, string seriNo, string revizyon, string takipDurum)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BarkodLokasyonBul", 
                    new SqlParameter("@stokNo", stokNo), 
                    new SqlParameter("@seriNo", seriNo), 
                    new SqlParameter("@revizyon", revizyon),
                    new SqlParameter("@takipDurum",takipDurum));
                DepoMiktar item = null;
                while (dataReader.Read())
                {
                    item = new DepoMiktar(
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DepoMiktar GetBarkodLokasyonBul2500(string stokNo, string seriNo, string revizyon, string takipDurum, int miktar)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BarkodLokasyonBul2500",
                    new SqlParameter("@stokNo", stokNo),
                    new SqlParameter("@seriNo", seriNo),
                    new SqlParameter("@revizyon", revizyon),
                    new SqlParameter("@takipDurum", takipDurum),
                    new SqlParameter("miktar", miktar));
                DepoMiktar item = null;
                while (dataReader.Read())
                {
                    item = new DepoMiktar(
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DepoMiktar GetBarkodLokasyonBul2600(string stokNo, string seriNo, string revizyon, string takipDurum, int miktar)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BarkodLokasyonBul2600",
                    new SqlParameter("@stokNo", stokNo),
                    new SqlParameter("@seriNo", seriNo),
                    new SqlParameter("@revizyon", revizyon),
                    new SqlParameter("@takipDurum", takipDurum),
                    new SqlParameter("miktar", miktar));
                DepoMiktar item = null;
                while (dataReader.Read())
                {
                    item = new DepoMiktar(
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DepoMiktar GetBarkodLokasyonBul3000(string stokNo, string seriNo, string revizyon, string takipDurum, int miktar)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BarkodLokasyonBul3000",
                    new SqlParameter("@stokNo", stokNo),
                    new SqlParameter("@seriNo", seriNo),
                    new SqlParameter("@revizyon", revizyon),
                    new SqlParameter("@takipDurum", takipDurum),
                    new SqlParameter("miktar", miktar));
                DepoMiktar item = null;
                while (dataReader.Read())
                {
                    item = new DepoMiktar(
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DepoMiktar StokSeriLotKontrol(string stokNo, string depoNo, string seriNo, string lotNo, string revizyon)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoStokSeriKontrol", 
                    new SqlParameter("@stokNo", stokNo),
                    new SqlParameter("@depoNo", depoNo),
                    new SqlParameter("@seriNo", seriNo),
                    new SqlParameter("@lotNo", lotNo),
                    new SqlParameter("@revizyon", revizyon));
                DepoMiktar item = null;
                while (dataReader.Read())
                {
                    item = new DepoMiktar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["SON_ISLEM_TARIHI"].ConDate(),
                        dataReader["SON_ISLEM_YAPAN"].ToString(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["REZERVE_DURUMU"].ToString(),
                         dataReader["REZERVE_ID"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DepoMiktar> GetList(string stokNo,string depoNo)
        {
            try
            {
                List<DepoMiktar> depoMiktars = new List<DepoMiktar>();
                dataReader = sqlServices.StoreReader("DepoMiktarList",new SqlParameter("@stokNo",stokNo),new SqlParameter("@depoNo",depoNo));
                while (dataReader.Read())
                {
                    depoMiktars.Add(new DepoMiktar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["SON_ISLEM_TARIHI"].ConDate(),
                        dataReader["SON_ISLEM_YAPAN"].ToString(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["REZERVE_DURUMU"].ToString(),
                         dataReader["REZERVE_ID"].ConInt()));
                }
                dataReader.Close();
                return depoMiktars;
            }
            catch (Exception)
            {
                return new List<DepoMiktar>();
            }
        }

        public List<DepoMiktar> GetListTumu()
        {
            try
            {
                List<DepoMiktar> depoMiktars = new List<DepoMiktar>();
                dataReader = sqlServices.StoreReader("DepoMiktarTum");
                while (dataReader.Read())
                {
                    depoMiktars.Add(new DepoMiktar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["SON_ISLEM_TARIHI"].ConDate(),
                        dataReader["SON_ISLEM_YAPAN"].ToString(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["REZERVE_DURUMU"].ToString(),
                         dataReader["REZERVE_ID"].ConInt()));
                }
                dataReader.Close();
                return depoMiktars;
            }
            catch (Exception)
            {
                return new List<DepoMiktar>();
            }
        }

        public List<DepoMiktar> StokKontrol(string stokNo)
        {
            try
            {
                List<DepoMiktar> depoMiktars = new List<DepoMiktar>();
                dataReader = sqlServices.StoreReader("DepoStokKontrol", new SqlParameter("@stokNo", stokNo));
                while (dataReader.Read())
                {
                    depoMiktars.Add(new DepoMiktar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["SON_ISLEM_TARIHI"].ConDate(),
                        dataReader["SON_ISLEM_YAPAN"].ToString(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["REZERVE_DURUMU"].ToString(),
                         dataReader["REZERVE_ID"].ConInt()));
                }
                dataReader.Close();
                return depoMiktars;
            }
            catch (Exception ex)
            {
                return new List<DepoMiktar>();
            }
        }

        public List<DepoMiktar> DepoGor()
        {
            try
            {
                List<DepoMiktar> depoMiktars = new List<DepoMiktar>();
                dataReader = sqlServices.StoreReader("DepoGor");
                while (dataReader.Read())
                {
                    depoMiktars.Add(new DepoMiktar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["SON_ISLEM_TARIHI"].ConDate(),
                        dataReader["SON_ISLEM_YAPAN"].ToString(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["DEPO_LOKASYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["REZERVE_DURUMU"].ToString(),
                         dataReader["REZERVE_ID"].ConInt()));
                }
                dataReader.Close();
                return depoMiktars;
            }
            catch (Exception)
            {
                return new List<DepoMiktar>();
            }
        }

        public string Update(DepoMiktar entity, string rezerveDurumu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMiktarGuncelle",
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@depoNo", entity.DepoNo),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@lotNo", entity.LotNo),
                    new SqlParameter("@revizyon", entity.Revizyon),
                    new SqlParameter("@sonIslemTarihi", entity.SonIslemTarihi),
                    new SqlParameter("@sonIslemYapan", entity.SonIslemYapan),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@depoLokasyon", entity.DepoLokasyon),
                    new SqlParameter("@rezerveDurum", rezerveDurumu));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateDepoStok(DepoMiktar entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoStokUpdate",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@seriNo",entity.SeriNo),
                    new SqlParameter("@lotNo",entity.LotNo),
                    new SqlParameter("@rev",entity.Revizyon),
                    new SqlParameter("@islemTarihi",entity.SonIslemTarihi),
                    new SqlParameter("@depoNo",entity.DepoNo),
                    new SqlParameter("@depoAdresi",entity.DepoAdresi),
                    new SqlParameter("@depoLokasyon",entity.DepoLokasyon),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@rezerveDurum",entity.RezerveDurumu),
                    new SqlParameter("@rezerveId",entity.RezerveId));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DepoRezerve(DepoMiktar entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoRezerve",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@islemYapan", entity.SonIslemYapan),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@rezerveId", entity.RezerveId));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DepoMiktarDal GetInstance()
        {
            if (depoMiktarDal == null)
            {
                depoMiktarDal = new DepoMiktarDal();
            }
            return depoMiktarDal;
        }
    }
}
