﻿using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Depo
{
    public class KKDDal // : IRepository<DestekDepoKKD>
    {
        static KKDDal kKDDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private KKDDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DestekDepoKKD entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKKDKaydet",
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));
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
                dataReader = sqlServices.StoreReader("DestekDepoKKDSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public DestekDepoKKD Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKKDList", new SqlParameter("@id", id));
                DestekDepoKKD item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoKKD(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoKKD GetTanim(string tanim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKKDList", new SqlParameter("@tanim", tanim));
                DestekDepoKKD item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoKKD(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoKKD GetStokNo(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKKDListStokNo", new SqlParameter("@stokNo", stokNo));
                DestekDepoKKD item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoKKD(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoKKD> GetList(int id)
        {
            try
            {
                List<DestekDepoKKD> malzemeKayits = new List<DestekDepoKKD>();
                dataReader = sqlServices.StoreReader("DestekDepoKKDList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new DestekDepoKKD(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return malzemeKayits;
            }
            catch (Exception)
            {
                return new List<DestekDepoKKD>();
            }
        }

        public string Update(DestekDepoKKD entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKKDGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static KKDDal GetInstance()
        {
            if (kKDDal == null)
            {
                kKDDal = new KKDDal();
            }
            return kKDDal;
        }
    }
}
