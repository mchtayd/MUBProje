using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class Otel
    {
        int id; string il, oteladi;

        public int Id { get => id; set => id = value; }
        public string Il { get => il; set => il = value; }
        public string Oteladi { get => oteladi; set => oteladi = value; }

        public Otel(string il, string oteladi)
        {
            this.il = il;
            this.oteladi = oteladi;
        }

        public Otel(int id, string il, string oteladi)
        {
            this.id = id;
            this.il = il;
            this.oteladi = oteladi;
        }
    }
}
