using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class IslemAdimlari
    {
        int id; string islemaAdimi, departman;

        public int Id { get => id; set => id = value; }
        public string IslemaAdimi { get => islemaAdimi; set => islemaAdimi = value; }
        public string Departman { get => departman; set => departman = value; }

        public IslemAdimlari(int id, string islemaAdimi, string departman)
        {
            this.id = id;
            this.islemaAdimi = islemaAdimi;
            this.departman = departman;
        }

        public IslemAdimlari(string islemaAdimi, string departman)
        {
            this.islemaAdimi = islemaAdimi;
            this.departman = departman;
        }
    }
}
