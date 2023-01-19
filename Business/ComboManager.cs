using DataAccess;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ComboManager //: IRepository<Combo>
    {
        static ComboManager comboManager;
        ComboDal comboDal;
        string controlText;

        private ComboManager()
        {
            comboDal = ComboDal.GetInstance();
        }
        public string Add(Combo entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return comboDal.Add(entity);
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
                return comboDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string TumunuSil(string comboAd)
        {
            try
            {
                return comboDal.TumunuSil(comboAd);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Combo Get(string comboAd,int id)
        {
            try
            {
                return comboDal.Get(comboAd, id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Combo> GetList(string comboAd)
        {
            try
            {
                return comboDal.GetList(comboAd);
            }
            catch (Exception)
            {
                return new List<Combo>();
            }
        }
        public List<Combo> GetListProje(string baslik)
        {
            try
            {
                return comboDal.GetListProje(baslik);
            }
            catch (Exception)
            {
                return new List<Combo>();
            }
        }

        public string Update(Combo entity,int id)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return comboDal.Update(entity, id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        string Complate(Combo combo)
        {
            if (string.IsNullOrEmpty(combo.Baslik))
            {
                return "Lütfen ComboBox İçerisine Eklemek İstediğiniz Bilgiyi Giriniz.";
            }
            return "";
        }
        public static ComboManager GetInstance()
        {
            if (comboManager == null)
            {
                comboManager = new ComboManager();
            }
            return comboManager;
        }
    }
}
