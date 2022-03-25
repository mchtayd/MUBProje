﻿using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AmbarVeriDal // : IRepository<AmbarVeri>
    {
        static AmbarVeriDal ambarVeriDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AmbarVeriDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AmbarVeri entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AmbarVeri Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AmbarVeri> GetList()
        {
            try
            {
                List<AmbarVeri> ambarVeris = new List<AmbarVeri>();
                dataReader = sqlServices.StoreReader("AmbarVeriIzleme");
                while (dataReader.Read())
                {
                    ambarVeris.Add(new AmbarVeri(
                        dataReader["FABRIKA_BO"].ConInt(),
                        dataReader["MALZEME_TEMIN_ASELSAN"].ConInt(),
                        dataReader["MALZEME_TEMIN_SATIN_ALMA"].ConInt(),
                        dataReader["MALZEME_HAZILAMA"].ConInt(),
                        dataReader["MALZEME_PAKETLEME"].ConInt(),
                        dataReader["BOLGE_SEVKIYAT"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConInt()));
                }
                dataReader.Close();
                return ambarVeris;
            }
            catch (Exception ex)
            {
                return new List<AmbarVeri>();
            }
        }
        public List<AmbarVeri> GetListAselsan()
        {
            try
            {
                List<AmbarVeri> ambarVeris = new List<AmbarVeri>();
                dataReader = sqlServices.StoreReader("AmbarVeriIzlemeAselsan");
                while (dataReader.Read())
                {
                    ambarVeris.Add(new AmbarVeri(
                        dataReader["UGES"].ConInt(),
                        dataReader["MGEO"].ConInt(),
                        dataReader["SST"].ConInt(),
                        dataReader["REHİS"].ConInt(),
                        dataReader["BO"].ConInt(),
                        dataReader["GK"].ConInt(),
                        dataReader["KT"].ConInt(),
                        0));
                }
                dataReader.Close();
                return ambarVeris;
            }
            catch (Exception ex)
            {
                return new List<AmbarVeri>();
            }
        }

        public string Update(AmbarVeri entity)
        {
            throw new NotImplementedException();
        }
        public static AmbarVeriDal GetInstance()
        {
            if (ambarVeriDal == null)
            {
                ambarVeriDal = new AmbarVeriDal();
            }
            return ambarVeriDal;
        }
    }
}
