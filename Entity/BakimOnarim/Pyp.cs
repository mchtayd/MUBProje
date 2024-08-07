﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class Pyp
    {
        int id; string pypNo, sorumluPersonel, siparisTuru, hesaplamaNedeni;

        public int Id { get => id; set => id = value; }
        public string PypNo { get => pypNo; set => pypNo = value; }
        public string SorumluPersonel { get => sorumluPersonel; set => sorumluPersonel = value; }
        public string SiparisTuru { get => siparisTuru; set => siparisTuru = value; }
        public string HesaplamaNedeni { get => hesaplamaNedeni; set => hesaplamaNedeni = value; }

        public Pyp(int id, string pypNo, string sorumluPersonel, string siparisTuru, string hesaplamaNedeni)
        {
            this.id = id;
            this.pypNo = pypNo;
            this.sorumluPersonel = sorumluPersonel;
            this.siparisTuru = siparisTuru;
            this.hesaplamaNedeni = hesaplamaNedeni;
        }

        public Pyp(string pypNo, string sorumluPersonel, string siparisTuru, string hesaplamaNedeni)
        {
            this.pypNo = pypNo;
            this.sorumluPersonel = sorumluPersonel;
            this.siparisTuru = siparisTuru;
            this.hesaplamaNedeni = hesaplamaNedeni;
        }
    }
}
