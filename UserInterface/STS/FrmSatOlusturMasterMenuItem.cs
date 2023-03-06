using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.STS
{
    public class FrmSatOlusturMasterMenuItem
    {
        public FrmSatOlusturMasterMenuItem()
        {
            TargetType = typeof(FrmSatOlusturMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}