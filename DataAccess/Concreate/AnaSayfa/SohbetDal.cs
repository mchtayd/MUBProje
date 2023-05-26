using DataAccess.Abstract;
using DataAccess.Database;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess.Concreate.AnaSayfa
{
    public class SohbetDal //: IRepository<Sohbet>
    {
        static SohbetDal sohbetDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SohbetDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static SohbetDal GetInstance()
        {
            if (sohbetDal == null)
            {
                sohbetDal = new SohbetDal();
            }
            return sohbetDal;
        }

        public string Add(Sohbet entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SohbetAdd", 
                    new SqlParameter("@gonderen",entity.Gonderen),
                    new SqlParameter("@alan", entity.Alan),
                    new SqlParameter("@gondermeZaman", entity.GondermeZaman),
                    new SqlParameter("@mesaj", entity.Mesaj));

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

        public Sohbet Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sohbet> GetList(string gonderen, string alan)
        {
            try
            {
                List<Sohbet> sohbets = new List<Sohbet>();
                dataReader = sqlServices.StoreReader("SohbetList", new SqlParameter("@gonderen", gonderen), new SqlParameter("@alan", alan));
                while (dataReader.Read())
                {
                    sohbets.Add(new Sohbet(
                        dataReader["ID"].ConInt(),
                        dataReader["GONDEREN"].ToString(),
                        dataReader["ALAN"].ToString(),
                        dataReader["GONDERME_ZAMAN"].ConDate(),
                        dataReader["ALMA_ZAMAN"].ConDate(),
                        dataReader["MESAJ"].ToString(),
                        "AKTİF"));
                }
                dataReader.Close();
                return sohbets;
            }
            catch (Exception)
            {
                dataReader.Close();
                return new List<Sohbet>();
            }
        }
        public List<Sohbet> GetListSohbetler(string gonderen, string alan)
        {
            try
            {
                List<Sohbet> sohbets = new List<Sohbet>();
                dataReader = sqlServices.StoreReader("Sohbetler", new SqlParameter("@gonderen", gonderen), new SqlParameter("@alan", alan));
                while (dataReader.Read())
                {
                    sohbets.Add(new Sohbet(
                        dataReader["ID"].ConInt(),
                        dataReader["GONDEREN"].ToString(),
                        dataReader["ALAN"].ToString(),
                        dataReader["GONDERME_ZAMAN"].ConDate(),
                        dataReader["ALMA_ZAMAN"].ConDate(),
                        dataReader["MESAJ"].ToString(),
                        dataReader["GORULME_DURUMU"].ToString()));
                }
                dataReader.Close();
                return sohbets;
            }
            catch (Exception)
            {
                return new List<Sohbet>();
            }
        }

        public string UpdateGoruldu(int id)
        {
            try
            {
                sqlServices.Stored("SohbetMesajGoruldu", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
