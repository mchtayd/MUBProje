using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class IslemAdimlariDal // : IRepository<IslemAdimlari>
    {
        static IslemAdimlariDal islemAdimlariDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IslemAdimlariDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IslemAdimlari entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IslemAdimlariEkle",
                    new SqlParameter("@islemAdimi",entity.IslemaAdimi),
                    new SqlParameter("@departman",entity.Departman));

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
                sqlServices.Stored("IslemAdimiDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IslemAdimlari Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IslemAdimlari> GetList(string departman)
        {
            try
            {
                List<IslemAdimlari> ıslemAdimlaris = new List<IslemAdimlari>();
                dataReader = sqlServices.StoreReader("IslemAdimlariList",new SqlParameter("@departman",departman));
                while (dataReader.Read())
                {
                    ıslemAdimlaris.Add(new IslemAdimlari(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DEPARTMAN"].ToString()));
                }
                dataReader.Close();

                List<int> sayilar = new List<int>();
                for (int i = 0; i < ıslemAdimlaris.Count; i++)
                {
                    string[] sayi = ıslemAdimlaris[i].IslemaAdimi.Split('_');
                    sayilar.Add(sayi[0].ConInt());
                }

                sayilar.Sort();
                List<IslemAdimlari> ıslemAdimlaris2 = new List<IslemAdimlari>();

                int sayac = ıslemAdimlaris.Count;
                for (int i = 0; i < sayilar.Count; i++)
                {
                    int j = 0;
                    while (j >=0 && j < sayac)
                    {
                        string[] sayi = ıslemAdimlaris[j].IslemaAdimi.Split('_');
                        if (sayi[0].ConInt() == sayilar[i])
                        {
                            ıslemAdimlaris2.Add(ıslemAdimlaris[j]);
                            ıslemAdimlaris.RemoveAt(j);
                            break;
                        }
                        else
                        {
                            j++;
                        }
                    }
                }

                return ıslemAdimlaris2;
            }
            catch (Exception)
            {
                return new List<IslemAdimlari>();
            }
        }

        public string Update(IslemAdimlari entity)
        {
            throw new NotImplementedException();
        }
        public static IslemAdimlariDal GetInstance()
        {
            if (islemAdimlariDal == null)
            {
                islemAdimlariDal = new IslemAdimlariDal();
            }
            return islemAdimlariDal;
        }
    }
}
