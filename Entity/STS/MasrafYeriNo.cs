using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MasrafYeriNo
    {
        int id, talepedenid, bolumid, birimid; string masrafyerino, departman, projekodu,talepedenad,bolumad,birimad;

        public int Id { get => id; set => id = value; }
        public int Talepedenid { get => talepedenid; set => talepedenid = value; }
        public int Bolumid { get => bolumid; set => bolumid = value; }
        public int Birimid { get => birimid; set => birimid = value; }
        public string Masrafyerino { get => masrafyerino; set => masrafyerino = value; }
        public string Departman { get => departman; set => departman = value; }
        public string Projekodu { get => projekodu; set => projekodu = value; }
        public string Talepedenad { get => talepedenad; set => talepedenad = value; }
        public string Bolumad { get => bolumad; set => bolumad = value; }
        public string Birimad { get => birimad; set => birimad = value; }

        public MasrafYeriNo(int id, string masrafyerino, int talepedenid, string talepedenad, string departman, int bolumid, int birimid, string bolumad, 
             string birimad, string projekodu)
        {
            this.id = id;
            this.masrafyerino = masrafyerino;
            this.talepedenid = talepedenid;
            this.talepedenad = talepedenad;
            this.departman = departman;
            this.bolumid = bolumid;
            this.birimid = birimid;
            this.bolumad = bolumad;
            this.birimad = birimad;
            this.projekodu = projekodu;
        }

        public MasrafYeriNo(string masrafyerino, int talepedenid, string talepedenad, string departman, int bolumid, string birimad, string bolumad, int birimid
           ,string projekodu)
        {
            this.masrafyerino = masrafyerino;
            this.talepedenid = talepedenid;
            this.talepedenad = talepedenad;
            this.departman = departman;
            this.bolumid = bolumid;
            this.birimid = birimid;
            this.bolumad = bolumad;
            this.birimad = birimad;
            this.projekodu = projekodu;
        }
    }
}
