using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class SirketBolum
    {
        int id; string bolum, bagliOlduguBolum; int bolumNo;

        public int Id { get => id; set => id = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string BagliOlduguBolum { get => bagliOlduguBolum; set => bagliOlduguBolum = value; }
        public int BolumNo { get => bolumNo; set => bolumNo = value; }

        public SirketBolum(int id, string bolum, string bagliOlduguBolum, int bolumNo)
        {
            this.id = id;
            this.bolum = bolum;
            this.bagliOlduguBolum = bagliOlduguBolum;
            this.bolumNo = bolumNo;
        }

        public SirketBolum(string bolum, string bagliOlduguBolum, int bolumNo)
        {
            this.bolum = bolum;
            this.bagliOlduguBolum = bagliOlduguBolum;
            this.bolumNo = bolumNo;
        }
    }
}
