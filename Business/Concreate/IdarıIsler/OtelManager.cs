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
    public class OtelManager //: IRepository<Otel>
    {
        static OtelManager otelManager;
        OtelDal otelDal;
        string controlText;

        private OtelManager()
        {
            otelDal = OtelDal.GetInstance();
        }
        public string Add(Otel entity)
        {
            try
            {
                controlText = Complate(entity);
                if (controlText != "")
                {
                    return controlText;
                }
                return otelDal.Add(entity);
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

        public Otel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Otel> GetList(string il)
        {
            try
            {
                return otelDal.GetList(il);
            }
            catch (Exception)
            {
                return new List<Otel>();
            }
        }

        public string Update(Otel entity)
        {
            throw new NotImplementedException();
        }
        string Complate(Otel otel)
        {
            if (string.IsNullOrEmpty(otel.Il))
            {
                return "Lütfen İl Bilgisini Giriniz.";
            }
            if (string.IsNullOrEmpty(otel.Oteladi))
            {
                return "Lütfen Otel Adı bilgilerini Giriniz.";
            }
            return "";
        }
        public static OtelManager GetInstance()
        {
            if (otelManager == null)
            {
                otelManager = new OtelManager();
            }
            return otelManager;
        }
    }
}
