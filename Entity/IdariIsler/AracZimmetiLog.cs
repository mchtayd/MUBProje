using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class AracZimmetiLog
    {
        int id, isAkisNo;string plaka, marka, aktaranPersonel, aktaranMasYeriNo, aktaranMasYeri, aktaranMasYeriSor, aktaranBolum, alanPersonel, alanMasYeriNo, alanMasYeri, alanMasYerSor, alanBolum;DateTime aktarimTarihi;string islemYapan; int km;string aktariGerekcesi;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string Marka { get => marka; set => marka = value; }
        public string AktaranPersonel { get => aktaranPersonel; set => aktaranPersonel = value; }
        public string AktaranMasYeriNo { get => aktaranMasYeriNo; set => aktaranMasYeriNo = value; }
        public string AktaranMasYeri { get => aktaranMasYeri; set => aktaranMasYeri = value; }
        public string AktaranMasYeriSor { get => aktaranMasYeriSor; set => aktaranMasYeriSor = value; }
        public string AktaranBolum { get => aktaranBolum; set => aktaranBolum = value; }
        public string AlanPersonel { get => alanPersonel; set => alanPersonel = value; }
        public string AlanMasYeriNo { get => alanMasYeriNo; set => alanMasYeriNo = value; }
        public string AlanMasYeri { get => alanMasYeri; set => alanMasYeri = value; }
        public string AlanMasYerSor { get => alanMasYerSor; set => alanMasYerSor = value; }
        public string AlanBolum { get => alanBolum; set => alanBolum = value; }
        public DateTime AktarimTarihi { get => aktarimTarihi; set => aktarimTarihi = value; }
        public string IslemYapan { get => islemYapan; set => islemYapan = value; }
        public int Km { get => km; set => km = value; }
        public string AktariGerekcesi { get => aktariGerekcesi; set => aktariGerekcesi = value; }

        public AracZimmetiLog(int id, int isAkisNo, string plaka, string marka, string aktaranPersonel, string aktaranMasYeriNo, string aktaranMasYeri, string aktaranMasYeriSor, string aktaranBolum, string alanPersonel, string alanMasYeriNo, string alanMasYeri, string alanMasYerSor, string alanBolum, DateTime aktarimTarihi, string islemYapan,int km,string aktarimGerekcesi)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.plaka = plaka;
            this.marka = marka;
            this.aktaranPersonel = aktaranPersonel;
            this.aktaranMasYeriNo = aktaranMasYeriNo;
            this.aktaranMasYeri = aktaranMasYeri;
            this.aktaranMasYeriSor = aktaranMasYeriSor;
            this.aktaranBolum = aktaranBolum;
            this.alanPersonel = alanPersonel;
            this.alanMasYeriNo = alanMasYeriNo;
            this.alanMasYeri = alanMasYeri;
            this.alanMasYerSor = alanMasYerSor;
            this.alanBolum = alanBolum;
            this.aktarimTarihi = aktarimTarihi;
            this.islemYapan = islemYapan;
            this.km = km;
            this.aktariGerekcesi = aktarimGerekcesi;
        }

        public AracZimmetiLog(int isAkisNo, string plaka, string marka, string aktaranPersonel, string aktaranMasYeriNo, string aktaranMasYeri, string aktaranMasYeriSor, string aktaranBolum, string alanPersonel, string alanMasYeriNo, string alanMasYeri, string alanMasYerSor, string alanBolum, DateTime aktarimTarihi, string islemYapan, int km, string aktarimGerekcesi)
        {
            this.isAkisNo = isAkisNo;
            this.plaka = plaka;
            this.marka = marka;
            this.aktaranPersonel = aktaranPersonel;
            this.aktaranMasYeriNo = aktaranMasYeriNo;
            this.aktaranMasYeri = aktaranMasYeri;
            this.aktaranMasYeriSor = aktaranMasYeriSor;
            this.aktaranBolum = aktaranBolum;
            this.alanPersonel = alanPersonel;
            this.alanMasYeriNo = alanMasYeriNo;
            this.alanMasYeri = alanMasYeri;
            this.alanMasYerSor = alanMasYerSor;
            this.alanBolum = alanBolum;
            this.aktarimTarihi = aktarimTarihi;
            this.islemYapan = islemYapan;
            this.km = km;
            this.aktariGerekcesi = aktarimGerekcesi;
        }
    }
}
