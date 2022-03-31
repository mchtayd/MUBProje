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
    public class SatinAlinacakMalDal
    {

        static SatinAlinacakMalDal satinAlinacakMalDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SatinAlinacakMalDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(SatinAlinacakMalzemeler entity, string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeEkle", new SqlParameter("@stn1", entity.Stn1), new SqlParameter("@t1", entity.T1),
                    new SqlParameter("@m1", entity.M1), new SqlParameter("@b1", entity.B1), new SqlParameter("@siparisNo", siparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatMalzemelerSil",new SqlParameter("@siparisno", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatDurumRed(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatMalzemelerDurumGuncelle", new SqlParameter("@siparisno", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DevamEdenSatGuncelle(SatinAlinacakMalzemeler entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DevamEdenSatMalzemeGuncelle", new SqlParameter("@stokNo", entity.Stn1), new SqlParameter("@tanim", entity.T1),
                    new SqlParameter("@miktari", entity.M1), new SqlParameter("@birim", entity.B1), new SqlParameter("@id", entity.Id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SatDurumOnay(string siparisno)
        {
            try
            {
                sqlServices.Stored("SatMalzemelerDurumGuncelleOnay", new SqlParameter("@siparisno", siparisno));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SatinAlinacakMalzemeler Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatinAlinacakMalzemeler> GetList(string siparisNo)
        {
            try
            {
                List<SatinAlinacakMalzemeler> satins = new List<SatinAlinacakMalzemeler>();
                dataReader = sqlServices.StoreReader("MalzemeListele", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    satins.Add(new SatinAlinacakMalzemeler(dataReader["ID"].ConInt(), dataReader["STN1"].ToString(), dataReader["T1"].ToString(),
                         dataReader["M1"].ConInt(), dataReader["B1"].ToString())); ;
                }
                dataReader.Close();
                return satins;
            }
            catch
            {
                return new List<SatinAlinacakMalzemeler>();
            }
        }

        public string Update(SatinAlinacakMalzemeler entity)
        {
            throw new NotImplementedException();
        }

        public object[] Malzemeler(string siparisNo = "")
        {
            try
            {
                object[] infos1 = null;
                dataReader = sqlServices.StoreReader("MalzemeListele", new SqlParameter("@siparisNo", siparisNo));
                if (dataReader.Read())
                {
                    int id, m1, m2, m3, m4, m5, m6, m7, m8, m9, m10; string stn1, t1, b1, stn2, t2, b2, stn3, t3, b3, stn4, t4, b4, stn5, t5, b5,
                    stn6, t6, b6, stn7, t7, b7, stn8, t8, b8, stn9, t9, b9, stn10, t10, b10;

                    id = dataReader["ID"].ConInt();
                    stn1 = dataReader["STN1"].ToString(); t1 = dataReader["T1"].ToString(); m1 = dataReader["M1"].ConInt();
                    b1 = dataReader["B1"].ToString();
                    stn2 = dataReader["STN2"].ToString(); t2 = dataReader["T2"].ToString(); m2 = dataReader["M2"].ConInt();
                    b2 = dataReader["B2"].ToString(); stn3 = dataReader["STN3"].ToString(); t3 = dataReader["T3"].ToString(); m3 = dataReader["M3"].ConInt();
                    b3 = dataReader["B3"].ToString(); stn4 = dataReader["STN4"].ToString(); t4 = dataReader["T4"].ToString(); m4 = dataReader["M4"].ConInt();
                    b4 = dataReader["B4"].ToString(); stn5 = dataReader["STN5"].ToString(); t5 = dataReader["T5"].ToString(); m5 = dataReader["M5"].ConInt();
                    b5 = dataReader["B5"].ToString(); stn6 = dataReader["STN6"].ToString(); t6 = dataReader["T6"].ToString(); m6 = dataReader["M6"].ConInt();
                    b6 = dataReader["B6"].ToString(); stn7 = dataReader["STN7"].ToString(); t7 = dataReader["T7"].ToString(); m7 = dataReader["M7"].ConInt();
                    b7 = dataReader["B7"].ToString(); stn8 = dataReader["STN8"].ToString(); t8 = dataReader["T8"].ToString(); m8 = dataReader["M8"].ConInt();
                    b8 = dataReader["B8"].ToString(); stn9 = dataReader["STN9"].ToString(); t9 = dataReader["T9"].ToString(); m9 = dataReader["M9"].ConInt();
                    b9 = dataReader["B9"].ToString(); stn10 = dataReader["STN10"].ToString(); t10 = dataReader["T10"].ToString(); m10 = dataReader["M10"].ConInt();
                    b10 = dataReader["B10"].ToString();

                    infos1 = new object[] {id,stn1,t1,m1,b1,stn2,t2,m2,b2,stn3,t3,m3,b3,stn4,t4,m4,b4,stn5,t5,m5,b5,stn6,t6,m6,b6,
                        stn7,t7,m7,b7, stn8,t8,m8,b8, stn9,t9,m9,b9, stn10,t10,m10,b10};
                }
                dataReader.Close();
                return infos1;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static SatinAlinacakMalDal GetInstance()
        {
            if (satinAlinacakMalDal == null)
            {
                satinAlinacakMalDal = new SatinAlinacakMalDal();
            }
            return satinAlinacakMalDal;
        }
    }
}
