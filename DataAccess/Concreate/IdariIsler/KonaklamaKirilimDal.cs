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
    public class KonaklamaKirilimDal //: IRepository<KonaklamaKirilim>
    {
        static KonaklamaKirilimDal konaklamaKirilimDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private KonaklamaKirilimDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(KonaklamaKirilim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KonaklamaKirilimEkle",
                    new SqlParameter("@isAkisNo", entity.IsAkisNo),
                    new SqlParameter("@gun", entity.Gun),
                    new SqlParameter("@gunTl", entity.GunTl),
                    new SqlParameter("@toplam", entity.Toplam));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KonaklamaKirilimSil", new SqlParameter("@isAkisNo", isAkisNo));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public KonaklamaKirilim Get(int isAkisNo)
        {
            throw new NotImplementedException();
        }

        public List<KonaklamaKirilim> GetList(int isAkisNo)
        {
            try
            {
                List<KonaklamaKirilim> konaklamaKirilims = new List<KonaklamaKirilim>();
                dataReader = sqlServices.StoreReader("KonaklamaKirilimList",new SqlParameter("@isAkisNo", isAkisNo));
                while (dataReader.Read())
                {
                    konaklamaKirilims.Add(new KonaklamaKirilim(
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["GUN"].ConInt(),
                        dataReader["GUN_TL"].ConInt(),
                        dataReader["TOPLAM"].ConInt()));
                }
                dataReader.Close();
                return konaklamaKirilims;

            }
            catch (Exception ex)
            {
                return new List<KonaklamaKirilim>();
            }
        }

        public string Update(KonaklamaKirilim entity)
        {
            throw new NotImplementedException();
        }
        public static KonaklamaKirilimDal GetInstance()
        {
            if (konaklamaKirilimDal == null)
            {
                konaklamaKirilimDal = new KonaklamaKirilimDal();
            }
            return konaklamaKirilimDal;
        }
    }
}
