using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PersonelIslemleri
    {
        int id; string sicilno, sifre;

        public int Id { get => id; set => id = value; }
        public string Sicilno { get => sicilno; set => sicilno = value; }
        public string Sifre { get => sifre; set => sifre = value; }

        public PersonelIslemleri(int id, string sicilno, string sifre)
        {
            this.id = id;
            this.sicilno = sicilno;
            this.sifre = sifre;
        }

        public PersonelIslemleri(string sicilno, string sifre)
        {
            this.sicilno = sicilno;
            this.sifre = sifre;
        }
    }

}
