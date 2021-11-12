using DataAccess.Abstract;
using DataAccess.Concreate.STS;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate.STS
{
    public class TekliflerOnaylananManager : IRepository<TekliflerOnaylanan>
    {
        static TekliflerOnaylananManager tekliflerOnaylananManager;
        TekilflerOnaylananDal tekliflerDal;
        string controlText;
        public string Add(TekliflerOnaylanan entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TekliflerOnaylanan Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TekliflerOnaylanan> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(TekliflerOnaylanan entity)
        {
            throw new NotImplementedException();
        }
    }
}
