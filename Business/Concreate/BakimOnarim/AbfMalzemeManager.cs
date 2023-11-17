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
        public string AddSokulenTakilan(AbfMalzeme entity)
        {
            try
            {
                return abfMalzemeDal.AddSokulenTakilan(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SokulenMalzemeUpdate(string calismaDurumu, string fizikselDurum, string yapilacakIslem, int id)
        {
            try
            {
                return abfMalzemeDal.SokulenMalzemeUpdate(calismaDurumu, fizikselDurum, yapilacakIslem, id);

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
            try
            {
                return abfMalzemeDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfMalzeme GetBul(int benzersizId, string stokNo, string seriNo, string revizyon)
        {
            try
            {
                return abfMalzemeDal.GetBul(benzersizId, stokNo, seriNo, revizyon);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfMalzeme GetBulTakilan(int benzersizId, string tanim, string seriNo, string revizyon)
        {
            try
            {
                return abfMalzemeDal.GetBulTakilan(benzersizId, tanim, seriNo, revizyon);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfMalzeme GetBulStokGirisCikis(string stokNo, string seriNo, string revizyon)
        {
            try
            {
                return abfMalzemeDal.GetBulStokGirisCikis(stokNo, seriNo, revizyon);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public AbfMalzeme GetBulStokGirisCikisOlmayan(string stokNo, int benzersizId)
        {
            try
            {
                return abfMalzemeDal.GetBulStokGirisCikisOlmayan(stokNo, benzersizId);
            }
            catch (Exception)
            {
                return null;
            }
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
        public List<AbfMalzeme> GetListStok(string stokNo,int benzersizId=0)
        {
            try
            {
                return abfMalzemeDal.GetListStok(stokNo, benzersizId);
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }
        public List<AbfMalzeme> DepoyaTeslimEdilecekMalzemeList(string teslimDurum, string fizikselDurum="")
        {
            try
            {
                return abfMalzemeDal.DepoyaTeslimEdilecekMalzemeList(teslimDurum, fizikselDurum);
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }
        public List<AbfMalzeme> DtfKayitList()
        {
            try
            {
                return abfMalzemeDal.DtfKayitList();
            }
            catch (Exception)
            {
                return new List<AbfMalzeme>();
            }
        }

        public List<string> MalzemeTeslimTuru()
        {
            try
            {
                return abfMalzemeDal.MalzemeTeslimTuru();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
        public List<string> MalzemeTeslimTuruTakilan()
        {
            try
            {
                return abfMalzemeDal.MalzemeTeslimTuruTakilan();
            }
            catch (Exception)
            {
                return new List<string>();
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

        public string MalzemeTeslimBilgisiUpdate(int id, string teslimDurum)
        {
            try
            {
                return abfMalzemeDal.MalzemeTeslimBilgisiUpdate(id, teslimDurum);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TakilanMalzemeTeslimBilgisiUpdate(int id, string teslimDurum)
        {
            try
            {
                return abfMalzemeDal.TakilanMalzemeTeslimBilgisiUpdate(id, teslimDurum);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string YerineMalzemeTakilma(int id)
        {
            try
            {
                return abfMalzemeDal.YerineMalzemeTakilma(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TeslimTesellumDurumUpdate(int id, string tesllimDurum)
        {
            try
            {
                return abfMalzemeDal.TeslimTesellumDurumUpdate(id, tesllimDurum);
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
