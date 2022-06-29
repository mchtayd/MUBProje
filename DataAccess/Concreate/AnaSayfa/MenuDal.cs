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
    public class MenuDal //: IRepository<MenuBaslik>
    {
        static MenuDal menuDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private MenuDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(MenuBaslik entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MenuBaslik Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<MenuBaslik> GetList()
        {
            try
            {
                List<MenuBaslik> menuBasliks = new List<MenuBaslik>();
                dataReader = sqlServices.StoreReader("BasiklarList");
                while (dataReader.Read())
                {
                    menuBasliks.Add(new MenuBaslik(dataReader["ID"].ConInt(), dataReader["BASLIK_ID"].ConInt(),
                        dataReader["BASLIK"].ToString()));
                }
                dataReader.Close();
                return menuBasliks;
            }
            catch (Exception)
            {

                return new List<MenuBaslik>();
            }
        }
        public List<MenuBaslik> GetListAlt(int baslikİd)
        {
            try
            {
                List<MenuBaslik> menuBasliks = new List<MenuBaslik>();
                dataReader = sqlServices.StoreReader("BaslikAltBaslik", new SqlParameter("@baslikId", baslikİd));
                while (dataReader.Read())
                {
                    menuBasliks.Add(new MenuBaslik(dataReader["ID"].ConInt(), dataReader["BASLIK_ID"].ConInt(),
                        dataReader["BASLIK"].ToString()));
                }
                dataReader.Close();
                return menuBasliks;
            }
            catch (Exception)
            {

                return new List<MenuBaslik>();
            }
        }

        public string Update(MenuBaslik entity)
        {
            throw new NotImplementedException();
        }

        public static MenuDal GetInstance()
        {
            if (menuDal == null)
            {
                menuDal = new MenuDal();
            }
            return menuDal;
        }
    }
}
