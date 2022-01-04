using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class AbfFormNo
    {
        int formNo;

        public int FormNo { get => formNo; set => formNo = value; }

        public AbfFormNo(int formNo)
        {
            this.formNo = formNo;
        }
    }
}
