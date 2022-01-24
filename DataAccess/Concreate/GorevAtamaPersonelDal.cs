using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class GorevAtamaPersonelDal //: IRepository<GorevAtamaPersonel>
    {
        static GorevAtamaPersonelDal gorevAtamaPersonelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private GorevAtamaPersonelDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(GorevAtamaPersonel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtananPersonelEkle",
                    new SqlParameter("@benzersiz",entity.BenzersizId),
                    new SqlParameter("@departman",entity.Departman),
                    new SqlParameter("@gorevAtanacakPersonel",entity.GorevAtanacakPersonel),
                    new SqlParameter("@islemAdimi",entity.IslemAdimi),
                    new SqlParameter("@sure",entity.Sure),
                    new SqlParameter("@tarih",entity.Tarih));

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
            throw new NotImplementedException();
        }

        public GorevAtamaPersonel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GorevAtamaPersonel> GetList(int benzersiz, string departman, string sure)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("GorevAtananPersonelListele",
                    new SqlParameter("@benzersiz", benzersiz),new SqlParameter("@departman",departman),new SqlParameter("@sure",sure));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConTime(),
                        dataReader["SURE"].ToString()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }

        public string Update(GorevAtamaPersonel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtananPersonelSureGuncelle",
                    new SqlParameter("@benzersiz",entity.BenzersizId),
                    new SqlParameter("@departman",entity.Departman),
                    new SqlParameter("@sure",entity.Sure));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevAtamaPersonelDal GetInstance()
        {
            if (gorevAtamaPersonelDal == null)
            {
                gorevAtamaPersonelDal = new GorevAtamaPersonelDal();
            }
            return gorevAtamaPersonelDal;
        }
    }
}
