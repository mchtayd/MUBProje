using DataAccess.Abstract;
using DataAccess.Concreate.AnaSayfa;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.AnaSayfa
{
    public class MenuManager //: IRepository<MenuBaslik>
    {
        static MenuManager menuManager;
        MenuDal menuDal;

        private MenuManager()
        {
            menuDal = MenuDal.GetInstance();
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

        public List<MenuBaslik> GetList(int sonId=0)
        {
            try
            {
                return menuDal.GetList(sonId);
            }
            catch (Exception)
            {

                return new List<MenuBaslik>();
            }
        }
        public List<MenuBaslik> GetListAlt(int baslikId)
        {
            try
            {
                return menuDal.GetListAlt(baslikId);
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
        public static MenuManager GetInstance()
        {
            if (menuManager == null)
            {
                menuManager = new MenuManager();
            }
            return menuManager;
        }
    }
}
