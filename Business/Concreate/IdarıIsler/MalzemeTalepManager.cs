using DataAccess.Abstract;
using DataAccess.Concreate.IdariIsler;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.IdarıIsler
{
    public class MalzemeTalepManager //: IRepository<MalzemeTalep>
    {
        static MalzemeTalepManager malzemeTalepManager;
        MalzemeTalepDal malzemeTalepDal;
        //string controlText;

        private MalzemeTalepManager()
        {
            malzemeTalepDal = MalzemeTalepDal.GetInstance();
        }
        public string Add(MalzemeTalep entity)
        {
            try
            {
                return malzemeTalepDal.Add(entity);
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

        public int GetToplam(string masrafYeriSorumlusu, string kategori)
        {
            try
            {
                return malzemeTalepDal.GetToplam(masrafYeriSorumlusu, kategori);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<MalzemeTalep> GetList()
        {
            try
            {
                return malzemeTalepDal.GetList();
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }
        public List<MalzemeTalep> GetListSat(string masrafYeriSorumlusu)
        {
            try
            {
                return malzemeTalepDal.GetListSat(masrafYeriSorumlusu);
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }
        public List<MalzemeTalep> GetListPersonel(string masrafYeriSorumlusu,string kategori)
        {
            try
            {
                return malzemeTalepDal.GetListPersonel(masrafYeriSorumlusu, kategori);
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }
        public List<MalzemeTalep> MasrafYeriSorumlusu()
        {
            try
            {
                return malzemeTalepDal.GetListMasrafYeri();
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }

        public List<MalzemeTalep> GetListIslemDurumu(string islemAdimi)
        {
            try
            {
                return malzemeTalepDal.GetListIslemDurumu(islemAdimi);
            }
            catch (Exception)
            {
                return new List<MalzemeTalep>();
            }
        }
        

        public string Update(int id, string islemDurumu, string redGerekcesi="")
        {
            try
            {
                return malzemeTalepDal.Update(id, islemDurumu, redGerekcesi);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static MalzemeTalepManager GetInstance()
        {
            if (malzemeTalepManager == null)
            {
                malzemeTalepManager = new MalzemeTalepManager();
            }
            return malzemeTalepManager;
        }
    }
}
