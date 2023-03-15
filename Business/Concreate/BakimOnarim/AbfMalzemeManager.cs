using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.BakimOnarim
{
    public class AbfMalzemeManager // : IRepository<AbfMalzeme>
    {
        static AbfMalzemeManager abfFormNoManager;
        AbfMalzemeDal abfMalzemeDal;

        private AbfMalzemeManager()
        {
            abfMalzemeDal = AbfMalzemeDal.GetInstance();
        }

        public string AddSokulen(AbfMalzeme entity)
        {
            try
            {
                return abfMalzemeDal.AddSokulen(entity);
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
                return abfMalzemeDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeleteTekMalzemeSil(int id)
        {
            try
            {
                return abfMalzemeDal.DeleteTekMalzemeSil(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public AbfMalzeme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AbfMalzeme> GetList(int benzersizId, string teminDurumu="")
        {
            try
            {
                return abfMalzemeDal.GetList(benzersizId, teminDurumu);
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }
        public List<AbfMalzeme> GetListStok(string stokNo)
        {
            try
            {
                return abfMalzemeDal.GetListStok(stokNo);
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }
        public List<AbfMalzeme> DepoyaTeslimEdilecekMalzemeList()
        {
            try
            {
                return abfMalzemeDal.DepoyaTeslimEdilecekMalzemeList();
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }
        public List<AbfMalzeme> TeminGetList(string teminDurumu, int abfNo = 0)
        {
            try
            {
                return abfMalzemeDal.TeminGetList(teminDurumu, abfNo);
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }

        public string AddTakilan(AbfMalzeme entity,int benzersizId)
        {
            try
            {
                return abfMalzemeDal.AddTakilan(entity, benzersizId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateTakilan(AbfMalzeme entity, int id)
        {
            try
            {
                return abfMalzemeDal.UpdateTakilan(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TeminBilgisi(int id, string teminBilgisi, string temineGonderen, string malzemeIslemAdimi)
        {
            try
            {
                return abfMalzemeDal.TeminBilgisi(id, teminBilgisi, temineGonderen, malzemeIslemAdimi);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AbfMalzemeManager GetInstance()
        {
            if (abfFormNoManager == null)
            {
                abfFormNoManager = new AbfMalzemeManager();
            }
            return abfFormNoManager;
        }
    }
}
