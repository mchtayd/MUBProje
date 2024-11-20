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
    public class GorevEmriNoDal //: IRepository<GorevEmriNo>
    {
        static GorevEmriNoDal gorevEmriNoDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private GorevEmriNoDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public static GorevEmriNoDal GetInstance()
        {
            if (gorevEmriNoDal == null)
            {
                gorevEmriNoDal = new GorevEmriNoDal();
            }
            return gorevEmriNoDal;
        }

        public string Add(GorevEmriNo entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevEmriNoAdd", new SqlParameter("@baslangicNo", entity.BaslangicNo), new SqlParameter("@bitisNo", entity.BitisNo));
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

        public GorevEmriNo Get(string durum)
        {
            try
            {
                GorevEmriNo gorevEmriNo = null;
                dataReader = sqlServices.StoreReader("GorevEmriNoDurumList", new SqlParameter("@durum", durum));
                while (dataReader.Read()) 
                {
                    gorevEmriNo = new GorevEmriNo(dataReader["ID"].ConInt(), dataReader["BASLANGIC_NO"].ConInt(), dataReader["BITIS_NO"].ConInt(), dataReader["TARIH"].ConDate(), dataReader["DEVAM_DURUMU"].ToString(), dataReader["MEVCUT_NO"].ConInt());
                }
                dataReader.Close();
                return gorevEmriNo;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                return null;
            }
        }
        public GorevEmriNo Get2(string durum)
        {
            try
            {
                GorevEmriNo gorevEmriNo = null;
                dataReader = sqlServices.StoreReader("GorevEmriNoDurumList2", new SqlParameter("@durum", durum));
                while (dataReader.Read())
                {
                    gorevEmriNo = new GorevEmriNo(dataReader["ID"].ConInt(), dataReader["BASLANGIC_NO"].ConInt(), dataReader["BITIS_NO"].ConInt(), dataReader["TARIH"].ConDate(), dataReader["DEVAM_DURUMU"].ToString(), dataReader["MEVCUT_NO"].ConInt());
                }
                dataReader.Close();
                return gorevEmriNo;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                return null;
            }
        }

        public List<GorevEmriNo> GetList()
        {
            try
            {
                List<GorevEmriNo> gorevEmriNos = new List<GorevEmriNo>();
                dataReader = sqlServices.StoreReader("GorevEmriNoListBaslamayan");
                while (dataReader.Read())
                {
                    gorevEmriNos.Add(new GorevEmriNo(dataReader["ID"].ConInt(), dataReader["BASLANGIC_NO"].ConInt(), dataReader["BITIS_NO"].ConInt(), dataReader["TARIH"].ConDate(), dataReader["DEVAM_DURUMU"].ToString(), dataReader["MEVCUT_NO"].ConInt()));
                }
                dataReader.Close();
                return gorevEmriNos;
            }
            catch (Exception)
            {
                return new List<GorevEmriNo>();
            }
        }

        public string Update(int id, string durum)
        {
            try
            {
                sqlServices.Stored("GorevEmriNoBaslat", new SqlParameter("@id", id), new SqlParameter("@durum", durum));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateMevcutNo(int id, int mevcutNo)
        {
            try
            {
                sqlServices.Stored("GorevEmriNoMevcutNoGuncelle", new SqlParameter("@id", id), new SqlParameter("@mevcutNo", mevcutNo));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
