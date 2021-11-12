using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class SatNumarasiManagerMasterMenuItem
    {
        public SatNumarasiManagerMasterMenuItem()
        {
            TargetType = typeof(SatNumarasiManagerMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}