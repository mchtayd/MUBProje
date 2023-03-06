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

    public class MasrafYeriNoDal : IRepository<MasrafYeriNo>
    {
        static MasrafYeriNoDal masrafYeriNo;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        bool result;
        private MasrafYeriNoDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(MasrafYeriNo entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MasrafYeriNoKaydet", new SqlParameter("@masrafno",entity.Masrafyerino),
                    new SqlParameter("@talepedenid", entity.Talepedenid), new SqlParameter("@departman", entity.Departman),
                    new SqlParameter("@bolumid", entity.Bolumid), new SqlParameter("@birimid", entity.Birimid), new SqlParameter("@projekodu", entity.Projekodu));
                if (dataReader.Read())
                {
                    result = dataReader[0].ConBool();
                }
                dataReader.Close();
                if (result)
                {
                    return entity.Masrafyerino + " Numarasıyla Zaten Bir Kayıt Var.";
                }
                return entity.Masrafyerino + " Numarasıyla Kayıt Başarılı Bir Şekilde Eklendi.";
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
                sqlServices.Stored("MasrafYeriNoSil", new SqlParameter("@id", id));
                return "Masraf Yeri Numarası Başarıyla Silindi.";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public MasrafYeriNo Get(int id)
        {
            return null;
        }

        public List<MasrafYeriNo> GetList()
        {
            try
            {
                List<MasrafYeriNo> masrafs = new List<MasrafYeriNo>();
                dataReader = sqlServices.StoreReader("MasrafYeriNoListele");
                while (dataReader.Read())
                {
                    masrafs.Add(new MasrafYeriNo(dataReader["ID"].ConInt(), dataReader["MASRAFNO"].ToString(), dataReader["TALEP_EDEN_ID"].ConInt(),
                        dataReader["AD_SOYAD"].ToString(), dataReader["DEPARTMAN"].ToString(), dataReader["BOLUM_ID"].ConInt(),
                        dataReader["BIRIM_ID"].ConInt(), dataReader["BOLUM"].ToString(), dataReader["BIRIM"].ToString(), dataReader["PROJE_KODU"].ToString()));
                }
                dataReader.Close();
                return masrafs;
            }
            catch
            {
                return new List<MasrafYeriNo>();
            }
        }

        public string Update(MasrafYeriNo entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MasrafYeriNoGuncelle", new SqlParameter("@id", entity.Id), new SqlParameter("@masrafno", entity.Masrafyerino),
                    new SqlParameter("@talepedenid", entity.Talepedenid), new SqlParameter("@departman", entity.Departman), new SqlParameter("@bolumid", entity.Bolumid),
                    new SqlParameter("@birimid", entity.Birimid), new SqlParameter("@projekodu", entity.Projekodu));

                dataReader.Close();
                return entity.Masrafyerino + " Numaralı Kayıt Başarıyla Güncellendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static MasrafYeriNoDal GetInstance()
        {
            if (masrafYeriNo==null)
            {
                masrafYeriNo = new MasrafYeriNoDal();
            }
            return masrafYeriNo;
        }
    }
}
