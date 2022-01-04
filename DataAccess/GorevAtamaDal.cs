using DataAccess.Abstract;
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
    public class GorevAtamaDal //: IRepository<GorevAtama>
    {
        static GorevAtamaDal gorevAtamaDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private GorevAtamaDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(GorevAtama entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtamaEkle",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@görevinTanimi",entity.GorevinTanimi),
                    new SqlParameter("@goreviIleten",entity.Gorevileten),
                    new SqlParameter("@tarihSaat",entity.TarihSaat),
                    new SqlParameter("@bulunduguIslemAdimi",entity.BulunduguİslemAdimi),
                    new SqlParameter("@islemAdimiSorumlusu",entity.IslemAdimiSorumlusu));

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

        public GorevAtama Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<GorevAtama> GetList()
        {
            try
            {
                List<GorevAtama> gorevAtamas = new List<GorevAtama>();
                dataReader = sqlServices.StoreReader("GorevAtamaList");
                while (dataReader.Read())
                {
                    gorevAtamas.Add(new GorevAtama(
                        dataReader["ID"].ConInt(),
                        dataReader["GOREVIN_TANIMI"].ToString(),
                        dataReader["GOREVI_ILETEN"].ToString(),
                        dataReader["TARIH_SAAT"].ConTime(),
                        dataReader["BULUNDUGU_ISLEM_ADIMI"].ToString(),
                        dataReader["ISLEM_ADIMI_SORUMLUSU"].ToString()));
                }
                dataReader.Close();
                return gorevAtamas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(GorevAtama entity)
        {
            throw new NotImplementedException();
        }
        public static GorevAtamaDal GetInstance()
        {
            if (gorevAtamaDal == null)
            {
                gorevAtamaDal = new GorevAtamaDal();
            }
            return gorevAtamaDal;
        }
    }
}
