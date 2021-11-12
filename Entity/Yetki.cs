using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class Yetki
    {
        int id; string name, izinIdleri;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string IzinIdleri { get => izinIdleri; set => izinIdleri = value; }

        public Yetki(int id, string name, string izinIdleri)
        {
            this.id = id;
            this.name = name;
            this.izinIdleri = izinIdleri;
        }

        public Yetki(int id, string izinIdleri)
        {
            this.id = id;
            this.izinIdleri = izinIdleri;
        }
    }
}
