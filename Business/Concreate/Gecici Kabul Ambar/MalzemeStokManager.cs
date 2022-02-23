using DataAccess.Abstract;
using DataAccess.Concreate.Gecici_Kabul_Ambar;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Gecici_Kabul_Ambar
{
    public class MalzemeStokManager //: IRepository<MalzemeStok>
    {
        static MalzemeStokManager malzemeStokManager;
        MalzemeStokDal malzemeStokDal;

        private MalzemeStokManager()
        {
            malzemeStokDal = MalzemeStokDal.GetInstance();
        }
        public string Add(MalzemeStok entity)
        {
            try
            {
                return malzemeStokDal.Add(entity);
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

        public MalzemeStok Get(int id)
        {
            try
            {
                return malzemeStokDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MalzemeStok> GetList()
        {
            try
            {
                return malzemeStokDal.GetList();
            }
            catch (Exception)
            {
                return new List<MalzemeStok>();
            }
        }

        public string Update(MalzemeStok entity)
        {
            throw new NotImplementedException();
        }
        public static MalzemeStokManager GetInstance()
        {
            if (malzemeStokManager == null)
            {
                malzemeStokManager = new MalzemeStokManager();
            }
            return malzemeStokManager;
        }
    }
}
