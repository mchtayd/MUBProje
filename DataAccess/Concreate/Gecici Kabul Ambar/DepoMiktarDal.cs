﻿using DataAccess.Abstract;
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
                sqlServices.Stored("DepoMiktarSil",new SqlParameter("@id",id));
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
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
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
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
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
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return depoMiktars;
            }
            catch (Exception)
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
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return depoMiktars;
            }
            catch (Exception)
            {
                return new List<DepoMiktar>();
            }
        }

        public string Update(DepoMiktar entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DepoMiktarGuncelle",
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@depoNo",entity.DepoNo),
                    new SqlParameter("@seriNo",entity.SeriNo),
                    new SqlParameter("@lotNo",entity.LotNo),
                    new SqlParameter("@revizyon",entity.Revizyon),
                    new SqlParameter("@sonIslemTarihi", entity.SonIslemTarihi),
                    new SqlParameter("@sonIslemYapan", entity.SonIslemYapan),
                    new SqlParameter("@miktar", entity.Miktar));

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