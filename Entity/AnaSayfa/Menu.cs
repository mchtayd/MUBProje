using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class MenuBaslik
    {
        int id, baslikId; string baslik;

        public int Id { get => id; set => id = value; }
        public int BaslikId { get => baslikId; set => baslikId = value; }
        public string Baslik { get => baslik; set => baslik = value; }

        public MenuBaslik(int id, int baslikId, string baslik)
        {
            this.id = id;
            this.baslikId = baslikId;
            this.baslik = baslik;
        }
    }
}
