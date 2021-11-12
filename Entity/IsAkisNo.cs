using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class IsAkisNo
    {
        int id;

        public int Id { get => id; set => id = value; }

        public IsAkisNo(int id)
        {
            this.id = id;
        }
    }
}
