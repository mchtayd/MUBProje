﻿using DataAccess.Abstract;
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
    public class SatRaporDal // : IRepository<SatRapor>
    {
        static SatRaporDal satRaporDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private SatRaporDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SatRapor entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatRapor Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatRapor> GetList(string firma, string donem)
        {
            try
            {
                List<SatRapor> tamamlanans = new List<SatRapor>();
                dataReader = sqlServices.StoreReader("SatRaporuCek", new SqlParameter("@firma", firma), new SqlParameter("@donem", donem));
                while (dataReader.Read())
                {
                    tamamlanans.Add(new SatRapor(
                        dataReader["KATEGORI"].ToString(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["HARCANAN_TUTAR"].ConDouble(),
                        dataReader["PROJE"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["GEREKCE"].ToString()));
                }
                dataReader.Close();
                return tamamlanans;

            }
            catch (Exception ex)
            {
                return new List<SatRapor>();
            }
        }
        public List<SatRapor> GetListBasaran(string firma, string donem)
        {
            try
            {
                List<SatRapor> tamamlanans = new List<SatRapor>();
                dataReader = sqlServices.StoreReader("SatRaporuCek", new SqlParameter("@firma", firma), new SqlParameter("@donem", donem));
                while (dataReader.Read())
                {
                    string[] array = dataReader["BUTCE_KODU_KALEMI"].ToString().Split('/');

                    tamamlanans.Add(new SatRapor(
                        array[0],
                        array[1],
                        dataReader["BELGE_TARIHI"].ConTime(),
                        dataReader["BELGE_NUMARASI"].ToString(),
                        dataReader["BELGE_TURU"].ToString(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["HARCANAN_TUTAR"].ConDouble(),
                        dataReader["HARCAMA_YAPAN"].ToString()));
                }
                dataReader.Close();
                return tamamlanans;

            }
            catch (Exception ex)
            {
                return new List<SatRapor>();
            }
        }

        public string Update(SatRapor entity)
        {
            throw new NotImplementedException();
        }
        public static SatRaporDal GetInstance()
        {
            if (satRaporDal == null)
            {
                satRaporDal = new SatRaporDal();
            }
            return satRaporDal;
        }
    }
}
