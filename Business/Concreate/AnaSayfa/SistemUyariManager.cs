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
    public class SistemUyariManager //: IRepository<SistemUyari>
    {
        static SistemUyariManager sistemUyariManager;
        SistemUyariDal sistemUyariDal;

        private SistemUyariManager()
        {
            sistemUyariDal = SistemUyariDal.GetInstance();
        }

        public static SistemUyariManager GetInstance()
        {
            if (sistemUyariManager == null)
            {
                sistemUyariManager = new SistemUyariManager();
            }
            return sistemUyariManager;
        }


        public string Add(SistemUyari entity)
        {
            try
            {
                return sistemUyariDal.Add(entity);
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
                return sistemUyariDal.GetList(personel);
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
                return sistemUyariDal.GetListKapatilacak(mesaj);
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
                return sistemUyariDal.Update(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
