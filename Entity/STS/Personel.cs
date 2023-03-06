using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Personel
    {
        int id, bolumid, birimid; string sicilno, isim, bolumad,birimad;

        public int Id { get => id; set => id = value; }
        public int Bolumid { get => bolumid; set => bolumid = value; }
        public int Birimid { get => birimid; set => birimid = value; }
        public string Sicilno { get => sicilno; set => sicilno = value; }
        public string Isim { get => isim; set => isim = value; }
        public string Bolumad { get => bolumad; set => bolumad = value; }
        public string Birimad { get => birimad; set => birimad = value; }

        public Personel(int id, string sicilno, string isim, int bolumid, string bolumad, int birimid, string birimad)
        {
            this.id = id;
            this.sicilno = sicilno;
            this.isim = isim;
            this.bolumid = bolumid;
            this.bolumad = bolumad;
            this.birimid = birimid;
            this.birimad = birimad;
        }

        public Personel(string sicilno, string isim, int bolumid, string bolumad, int birimid, string birimad)
        {
            this.sicilno = sicilno;
            this.isim = isim;
            this.bolumid = bolumid;
            this.bolumad = bolumad;
            this.birimid = birimid;
            this.birimad = birimad;
        }
    }
}
