using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class ReddedilenlerDalMasterMenuItem
    {
        public ReddedilenlerDalMasterMenuItem()
        {
            TargetType = typeof(ReddedilenlerDalMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}