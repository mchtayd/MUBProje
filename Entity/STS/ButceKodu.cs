using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class ButceKodu
    {
        int id; string butcekodu;

        public int Id { get => id; set => id = value; }
        public string Butcekodu { get => butcekodu; set => butcekodu = value; }

        public ButceKodu(int id, string butcekodu)
        {
            this.id = id;
            this.butcekodu = butcekodu;
        }

        public ButceKodu(string butcekodu)
        {
            this.butcekodu = butcekodu;
        }
    }
}
