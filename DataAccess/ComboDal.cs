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
    public class ComboDal //: IRepository<Combo>
    {
        static ComboDal comboDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ComboDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Combo entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ComboEkle",
                    new SqlParameter("@baslik",entity.Baslik),
                    new SqlParameter("@comboAd",entity.ComboAd),
                    new SqlParameter("@sayfa",entity.Sayfa));
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
                sqlServices.Stored("ComboSil",new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TumunuSil(string comboAd)
        {
            try
            {
                sqlServices.Stored("ComboTumunuSil", new SqlParameter("@comboAd", comboAd));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Combo Get(string comboAd,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ComboList",new SqlParameter("@comboAd",comboAd),new SqlParameter("@id",id));
                Combo item = null;
                while (dataReader.Read())
                {
                    item = new Combo(
                        dataReader["ID"].ConInt(),
                        dataReader["BASLIK"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["COMBO_AD"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Combo> GetList(string comboAd)
        {
            try
            {
                List<Combo> combos = new List<Combo>();
                dataReader = sqlServices.StoreReader("ComboList",new SqlParameter("@comboAd", comboAd));
                while (dataReader.Read())
                {
                    combos.Add(new Combo(
                        dataReader["ID"].ConInt(),
                        dataReader["BASLIK"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["COMBO_AD"].ToString()));
                }
                dataReader.Close();
                return combos;
            }
            catch (Exception)
            {
                return new List<Combo>();
            }
        }
        public List<Combo> GetListProje(string baslik)
        {
            try
            {
                List<Combo> combos = new List<Combo>();
                dataReader = sqlServices.StoreReader("ComboProjeList", new SqlParameter("@baslik", baslik));
                while (dataReader.Read())
                {
                    combos.Add(new Combo(
                        dataReader["ID"].ConInt(),
                        dataReader["BASLIK"].ToString(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["COMBO_AD"].ToString()));
                }
                dataReader.Close();
                return combos;
            }
            catch (Exception)
            {
                return new List<Combo>();
            }
        }

        public string Update(Combo entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ComboGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@baslik", entity.Baslik));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ComboDal GetInstance()
        {
            if (comboDal == null)
            {
                comboDal = new ComboDal();
            }
            return comboDal;
        }
    }
}
