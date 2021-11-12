using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class PersKaytLojistik
    {
        int id;string bolum3; int bolumid;

        public int Id { get => id; set => id = value; }
        public string Bolum3 { get => bolum3; set => bolum3 = value; }
        public int Bolumid { get => bolumid; set => bolumid = value; }

        public PersKaytLojistik(int id, string bolum3, int bolumid)
        {
            this.id = id;
            this.bolum3 = bolum3;
            this.bolumid = bolumid;
        }

        public PersKaytLojistik(string bolum3, int bolumid)
        {
            this.bolum3 = bolum3;
            this.bolumid = bolumid;
        }
    }
}
