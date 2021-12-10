﻿using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class IscilikPerformansDal // : IRepository<IscilikPerformans>
    {
        static IscilikPerformansDal iscilikPerformans;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IscilikPerformansDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IscilikPerformans entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikPerformansEkle", 
                    new SqlParameter("@iscilikTuru",entity.IscilikTuru),
                    new SqlParameter("@performans",entity.Personel),
                    new SqlParameter("@mevcutDuragi",entity.MevcutDuragi),
                    new SqlParameter("@cikisDuragi",entity.CikisDuragi),
                    new SqlParameter("@istikametDuragi",entity.IstikametDuragi),
                    new SqlParameter("@cikisTarihiSaati",entity.CikisTarihiSaati),
                    new SqlParameter("@cikisSebebi",entity.CikisSebebi),
                    new SqlParameter("@varisDuragi",entity.VarisDurag),
                    new SqlParameter("@varisTarihiSaati",entity.VarisTarihiSaat),
                    new SqlParameter("@sonuc",entity.Sonuc));
                
                dataReader.Read();
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
                dataReader = sqlServices.StoreReader("IscilikPerformansSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikPerformans Get(string personelAd)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikPerformansList",new SqlParameter("@personelAd", personelAd));
                IscilikPerformans item = null;
                while (dataReader.Read())
                {
                    item = new IscilikPerformans(
                        dataReader["ID"].ConInt(),
                        dataReader["ISCILIK_TURU"].ToString(),
                        dataReader["PERSONEL"].ToString(),
                        dataReader["MEVCUT_DURAGI"].ToString(),
                        dataReader["CIKIS_DURAGI"].ToString(),
                        dataReader["ISTIKAMET_DURAGI"].ToString(),
                        dataReader["CIKIS_TARIHI_SAATI"].ConTime(),
                        dataReader["CIKIS_SEBEBI"].ToString(),
                        dataReader["VARIS_DURAGI"].ToString(),
                        dataReader["VARIS_TARIHI_SAATI"].ConTime(),
                        dataReader["SONUC"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikPerformans> GetList()
        {
            try
            {
                List<IscilikPerformans> performans = new List<IscilikPerformans>();
                dataReader = sqlServices.StoreReader("IscilikPerformansList");
                while (dataReader.Read())
                {
                    performans.Add(new IscilikPerformans(
                        dataReader["ID"].ConInt(),
                        dataReader["ISCILIK_TURU"].ToString(),
                        dataReader["PERSONEL"].ToString(),
                        dataReader["MEVCUT_DURAGI"].ToString(),
                        dataReader["CIKIS_DURAGI"].ToString(),
                        dataReader["ISTIKAMET_DURAGI"].ToString(),
                        dataReader["CIKIS_TARIHI_SAATI"].ConTime(),
                        dataReader["CIKIS_SEBEBI"].ToString(),
                        dataReader["VARIS_DURAGI"].ToString(),
                        dataReader["VARIS_TARIHI_SAATI"].ConTime(),
                        dataReader["SONUC"].ToString()));
                }
                dataReader.Close();
                return performans;
            }
            catch (Exception)
            {
                return new List<IscilikPerformans>();
            }
        }

        public string Update(IscilikPerformans entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikPerformansGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@iscilikTuru", entity.IscilikTuru),
                    new SqlParameter("@performans", entity.Personel),
                    new SqlParameter("@mevcutDuragi", entity.MevcutDuragi),
                    new SqlParameter("@cikisDuragi", entity.CikisDuragi),
                    new SqlParameter("@istikametDuragi", entity.IstikametDuragi),
                    new SqlParameter("@cikisTarihiSaati", entity.CikisTarihiSaati),
                    new SqlParameter("@cikisSebebi", entity.CikisSebebi),
                    new SqlParameter("@varisDuragi", entity.VarisDurag),
                    new SqlParameter("@varisTarihiSaati", entity.VarisTarihiSaat),
                    new SqlParameter("@sonuc", entity.Sonuc));

                dataReader.Read();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IscilikPerformansDal GetInstance()
        {
            if (iscilikPerformans == null)
            {
                iscilikPerformans = new IscilikPerformansDal();
            }
            return iscilikPerformans;
        }
    }
}