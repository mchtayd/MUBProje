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
                    new SqlParameter("@malzemekul",entity.Malzemekul),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@alternatifMalzeme",entity.AlternatifMalzeme),
                    new SqlParameter("@dosyayolu",entity.Dosyayolu),
                    new SqlParameter("@sistemStokNo",entity.SistemStokNo),
                    new SqlParameter("@sistemTanim",entity.SistemTanim),
                    new SqlParameter("@sistemSorumlusu",entity.SistemPersonel));
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
        public string UsTakimGuncelle(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeKayitUstTakimEkle", new SqlParameter("@id", id));
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
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString());

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
                    item = new MalzemeKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["ONARIM_DURUMU"].ToString(),
                        dataReader["ONARIM_YERI"].ToString(),
                        dataReader["MALZEME_TURU"].ToString(),
                        dataReader["MALZEME_TAKIP_DURUMU"].ToString(),
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                dataReader.Close();
                return null;
            }
        }
        public MalzemeKayit MalzemeSonStok()
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeSonStokBul");
                MalzemeKayit item = null;
                while (dataReader.Read())
                {
                    item = new MalzemeKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["TEDARIKCI_FIRMA"].ToString(),
                        dataReader["MALZEME_ONARIM_DURUMU"].ToString(),
                        dataReader["MALZEME_ONARIM_YERI"].ToString(),
                        dataReader["MALZEME_TURU"].ToString(),
                        dataReader["MALZEME_TAKIP_DURUMU"].ToString(),
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString());
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
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString()));
                }
                dataReader.Close();
                return malzemeKayits;
            }
            catch (Exception)
            {
                return new List<MalzemeKayit>();
            }
        }
        public List<MalzemeKayit> GetListMalzemeKayit(string stokNo)
        {
            try
            {
                List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
                dataReader = sqlServices.StoreReader("MalzemeKayitList", new SqlParameter("@stokno", stokNo));
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
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString()));
                }
                dataReader.Close();
                return malzemeKayits;
            }
            catch (Exception)
            {
                return new List<MalzemeKayit>();
            }
        }
        public List<MalzemeKayit> UstTakimGetList()
        {
            try
            {
                List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
                dataReader = sqlServices.StoreReader("MalzemeKayitUstList");
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
                        dataReader["MALZEMENIN_KUL_UST"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["ALTERNATIF_MALZEME"].ToString(),
                        dataReader["SISTEM_STOK_NO"].ToString(),
                        dataReader["SISTEM_TANIM"].ToString(),
                        dataReader["SISTEM_SORUMLUSU"].ToString()));
                }
                dataReader.Close();
                return malzemeKayits;
            }
            catch (Exception)
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
                    new SqlParameter("@malzemekul", entity.Malzemekul),
                    new SqlParameter("@alternatifMalzeme", entity.AlternatifMalzeme),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu),
                    new SqlParameter("@sistemStokNo", entity.SistemStokNo),
                    new SqlParameter("@sistemTanim", entity.SistemTanim),
                    new SqlParameter("@sistemSorumlusu", entity.SistemPersonel));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateDirectoryPath(int id, string filePath)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeKayitDosyaYoluUpdate",
                    new SqlParameter("@id", id),
                    new SqlParameter("@dosyaYolu", filePath));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string StokDuzelt(string stokNo,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeStokDuzelt",
                    new SqlParameter("@stokno", stokNo),
                    new SqlParameter("@id", id));
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
