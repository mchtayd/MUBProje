using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using DataAccess.Database;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.AnaSayfa
{
    public class SistemUyariDal //: IRepository<SistemUyari>
    {
        static SistemUyariDal sistemUyariDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SistemUyariDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public static SistemUyariDal GetInstance()
        {
            if (sistemUyariDal == null)
            {
                sistemUyariDal = new SistemUyariDal();
            }
            return sistemUyariDal;
        }

        public string Add(SistemUyari entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SistemUyariAdd", new SqlParameter("@personeller", entity.Personel), new SqlParameter("@uyariMesaji", entity.UyariMesaji));
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

        public SistemUyari Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SistemUyari> GetList(string personel)
        {
            try
            {
                List<SistemUyari> sistemUyaris = new List<SistemUyari>();
                dataReader = sqlServices.StoreReader("SistemUyariList", new SqlParameter("@personel", personel));
                while (dataReader.Read())
                {
                    sistemUyaris.Add(new SistemUyari(dataReader["ID"].ConInt(), dataReader["PERSONELLER"].ToString(), dataReader["UYARI_MESAJI_2"].ToString(),
                        dataReader["MESAJ_DURUM"].ToString(), dataReader["TARIH"].ConDate()));
                }
                dataReader.Close();
                return sistemUyaris;
            }
            catch (Exception)
            {
                return new List<SistemUyari>();
            }
        }
        public List<SistemUyari> GetListKapatilacak(string mesaj)
        {
            try
            {
                List<SistemUyari> sistemUyaris = new List<SistemUyari>();
                dataReader = sqlServices.StoreReader("SistemUyariListKapatilacak", new SqlParameter("@mesaj", mesaj));
                while (dataReader.Read())
                {
                    sistemUyaris.Add(new SistemUyari(dataReader["ID"].ConInt(), dataReader["PERSONELLER"].ToString(), dataReader["UYARI_MESAJI_2"].ToString(),
                        dataReader["MESAJ_DURUM"].ToString(), dataReader["TARIH"].ConDate()));
                }
                dataReader.Close();
                return sistemUyaris;
            }
            catch (Exception)
            {

                return new List<SistemUyari>();
            }
        }

        public string Update(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SistemUyariUpdate", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
