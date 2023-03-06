using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class TeklifAlinan
    {
        string stokNo, tanim; int miktar; string birim; double bbf, btf; string firma1; double ibf, itf; string firma2; double ubf, utf; string firma3, siparisno;
        bool secim = true;

        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public double Bbf { get => bbf; set => bbf = value; }
        public double Btf { get => btf; set => btf = value; }
        public string Firma1 { get => firma1; set => firma1 = value; }
        public double Ibf { get => ibf; set => ibf = value; }
        public double Itf { get => itf; set => itf = value; }
        public string Firma2 { get => firma2; set => firma2 = value; }
        public double Ubf { get => ubf; set => ubf = value; }
        public double Utf { get => utf; set => utf = value; }
        public string Firma3 { get => firma3; set => firma3 = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public bool Secim { get => secim; set => secim = value; }

        public TeklifAlinan(string stokNo, double bbf, double btf, double ibf, double itf, double ubf, double utf, string siparisno)
        {
            this.StokNo = stokNo;
            this.Bbf = bbf;
            this.Btf = btf;
            this.Ibf = ibf;
            this.Itf = itf;
            this.Ubf = ubf;
            this.Utf = utf;
            this.Siparisno = siparisno;
        }

        //public TeklifAlinan(string stokNo, string tanim, int miktar, string birim, string firma1, string firma2, string firma3)
        //{
        //    this.StokNo = stokNo;
        //    this.Tanim = tanim;
        //    this.Miktar = miktar;
        //    this.Birim = birim;
        //    this.Firma1 = firma1;
        //    this.Firma2 = firma2;
        //    this.Firma3 = firma3;
        //}

        public TeklifAlinan(string firma1, string firma2, string firma3, string stokNo)
        {
            this.Firma1 = firma1;
            this.Firma2 = firma2;
            this.Firma3 = firma3;
            this.StokNo = stokNo;
        }

        public TeklifAlinan(string stokNo, string tanim, int miktar, string birim, string firma1, double bbf, double btf, string firma2, double ibf, double itf, string firma3, double ubf, double utf, string siparisno)
        {
            this.StokNo = stokNo;
            this.Tanim = tanim;
            this.Miktar = miktar;
            this.Birim = birim;
            this.Firma1 = firma1;
            this.Bbf = bbf;
            this.Btf = btf;
            this.Firma2 = firma2;
            this.Ibf = ibf;
            this.Itf = itf;
            this.Firma3 = firma3;
            this.Ubf = ubf;
            this.Utf = utf;
            this.Siparisno = siparisno;
        }

        public TeklifAlinan(string stokNo, string tanim, int miktar, string birim, double bbf, double btf, string firma1)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.bbf = bbf;
            this.btf = btf;
            this.firma1 = firma1;
        }

        public TeklifAlinan(string stokNo, string tanim, int miktar, string birim, string siparisno)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.siparisno = siparisno;
        }

        public override string ToString()
        {
            if (Firma2.Length > 0 && Firma3.Length == 0)
            {
                return "Stok No: " + StokNo + " - Tanım: " + Tanim + " - Miktar: " + Miktar + " - Birim: " + Birim + " - Firma 1: " + Firma1 + " - Firma 2:" + Firma2 + "\n\n";
            }
            else if (Firma2.Length > 0 || Firma3.Length > 0)
            {
                return "Stok No: " + StokNo + " - Tanım: " + Tanim + " - Miktar: " + Miktar + " - Birim: " + Birim + " - Firma 1: " + Firma1 + " - Firma 2:" + Firma2 + " - Firma 3: " + Firma3 + "\n\n";
            }
            else
            {
                return "Stok No: " + StokNo + " - Tanım: " + Tanim + " - Miktar: " + Miktar + " - Birim: " + Birim + " - Firma 1: " + Firma1 + "\n\n";
            }
        }
    }
}
