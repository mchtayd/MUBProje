using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class PersonelKayitBO
    {
        int id; string bolum2;

        public int Id { get => id; set => id = value; }
        public string Bolum2 { get => bolum2; set => bolum2 = value; }

        public PersonelKayitBO(int id, string bolum2)
        {
            this.id = id;
            this.bolum2 = bolum2;
        }

        public PersonelKayitBO(string bolum2)
        {
            this.bolum2 = bolum2;
        }
    }
}
