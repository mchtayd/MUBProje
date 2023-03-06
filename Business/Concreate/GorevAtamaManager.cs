using DataAccess;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class GorevAtamaManager // : IRepository<GorevAtama>
    {
        static GorevAtamaManager gorevAtamaManager;
        GorevAtamaDal gorevAtamaDal;

        private GorevAtamaManager()
        {
            gorevAtamaDal = GorevAtamaDal.GetInstance();
        }

        public string Add(GorevAtama entity)
        {
            try
            {
                return gorevAtamaDal.Add(entity);
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

        public GorevAtama Get(int id)
        {
            try
            {
                return gorevAtamaDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GorevAtama> GetList(string durum = "",string goreviAtayaPersonel = "")
        {
            try
            {
                return gorevAtamaDal.GetList(durum, goreviAtayaPersonel);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<GorevAtama> GetListTamamlananlar(string adSoyad)
        {
            try
            {
                return gorevAtamaDal.GetListTamamlananlar(adSoyad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GorevAtama> GorevlerList(int isAkisNo)
        {
            try
            {
                return gorevAtamaDal.GorevlerList(isAkisNo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {

                return gorevAtamaDal.IsAkisNoDuzelt(id, isAkisNo, dosyaYolu);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<GorevAtama> GetListGorevlerim(string adSoyad)
        {
            try
            {
                return gorevAtamaDal.GetListGorevlerim(adSoyad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Update(GorevAtama entity)
        {
            try
            {
                return gorevAtamaDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevAtamaManager GetInstance()
        {
            if (gorevAtamaManager == null)
            {
                gorevAtamaManager = new GorevAtamaManager();
            }
            return gorevAtamaManager;
        }
    }
}
