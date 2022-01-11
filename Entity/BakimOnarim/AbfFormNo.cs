using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class AbfFormNo
    {
        int formNo; string personelSicil, personelAd;

        public int FormNo { get => formNo; set => formNo = value; }
        public string PersonelSicil { get => personelSicil; set => personelSicil = value; }
        public string PersonelAd { get => personelAd; set => personelAd = value; }

        public AbfFormNo(int formNo)
        {
            this.formNo = formNo;
        }

        public AbfFormNo(string personelSicil, string personelAd)
        {
            this.personelSicil = personelSicil;
            this.personelAd = personelAd;
        }
    }
}
