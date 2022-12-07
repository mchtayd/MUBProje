﻿using DataAccess.Abstract;
using DataAccess.Concreate.Butce;
using Entity.Butce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.Butce
{
    public class ButceManager //: IRepository<ButceKayit>
    {
        static ButceManager butceManager;
        ButceDal butceDal;

        private ButceManager()
        {
            butceDal = ButceDal.GetInstance();
        }

        public string Add(ButceKayit entity)
        {
            try
            {
                return butceDal.Add(entity);
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
                return butceDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ButceKayit Get(int id)
        {
            try
            {
                return butceDal.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ButceKayit> GetList()
        {
            try
            {
                return butceDal.GetList();
            }
            catch (Exception)
            {
                return new List<ButceKayit>();
            }
        }

        public string Update(ButceKayit entity)
        {
            try
            {
                return butceDal.Update(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ButceManager GetInstance()
        {
            if (butceManager == null)
            {
                butceManager = new ButceManager();
            }
            return butceManager;
        }
    }
}
