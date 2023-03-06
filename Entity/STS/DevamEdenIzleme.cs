﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class DevamEdenIzleme
    {
        int id; string siparisno, islem, islemyapan; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string Islem { get => islem; set => islem = value; }
        public string Islemyapan { get => islemyapan; set => islemyapan = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public DevamEdenIzleme(int id, string siparisno, string islem, string islemyapan, DateTime tarih)
        {
            this.id = id;
            this.siparisno = siparisno;
            this.islem = islem;
            this.islemyapan = islemyapan;
            this.tarih = tarih;
        }

        public DevamEdenIzleme(string siparisno, string islem, string islemyapan, DateTime tarih)
        {
            this.siparisno = siparisno;
            this.islem = islem;
            this.islemyapan = islemyapan;
            this.tarih = tarih;
        }
    }
}
