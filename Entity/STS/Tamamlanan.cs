using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class Tamamlanan
    {
        int id, formno; string satno, masrafyeri, talepeden, bolum, usbolgesi, abfform; DateTime istenentarih, tamamlanantarih;string gerekce, butcekodukalemi, satbirim, harcamaturu, faturaedilecekfirma, ilgilikisi, masrafyerino; double harcanantutar; string belgeturu, belgenumarasi;DateTime belgetarihi;string dosyayolu, siparisno; int ucteklif; string islemAdimi, donem, satOlusturmaTuru, proje, satinAlinanFirma, harcamaYapan; string gecensure, usProjeNo, garantiDurumu, mlzTeslimAldTarih;

        public int     Id        { get => id; set => id = value; }
        public int Formno { get => formno; set => formno = value; }
        public string Satno { get => satno; set => satno = value; }
        public string Masrafyeri { get => masrafyeri; set => masrafyeri = value; }
        public string Talepeden { get => talepeden; set => talepeden = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string Usbolgesi { get => usbolgesi; set => usbolgesi = value; }
        public string Abfform { get => abfform; set => abfform = value; }
        public DateTime Istenentarih { get => istenentarih; set => istenentarih = value; }
        public DateTime Tamamlanantarih { get => tamamlanantarih; set => tamamlanantarih = value; }
        public string Gerekce { get => gerekce; set => gerekce = value; }
        public string Butcekodukalemi { get => butcekodukalemi; set => butcekodukalemi = value; }
        public string Satbirim { get => satbirim; set => satbirim = value; }
        public string Harcamaturu { get => harcamaturu; set => harcamaturu = value; }
        public string Faturaedilecekfirma { get => faturaedilecekfirma; set => faturaedilecekfirma = value; }
        public string Ilgilikisi { get => ilgilikisi; set => ilgilikisi = value; }
        public string Masrafyerino { get => masrafyerino; set => masrafyerino = value; }
        public double Harcanantutar { get => harcanantutar; set => harcanantutar = value; }
        public string Belgeturu { get => belgeturu; set => belgeturu = value; }
        public string Belgenumarasi { get => belgenumarasi; set => belgenumarasi = value; }
        public DateTime Belgetarihi { get => belgetarihi; set => belgetarihi = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public int Ucteklif { get => ucteklif; set => ucteklif = value; }
        public string IslemAdimi { get => islemAdimi; set => islemAdimi = value; }
        public string Donem { get => donem; set => donem = value; }
        public string SatOlusturmaTuru { get => satOlusturmaTuru; set => satOlusturmaTuru = value; }
        public string Proje { get => proje; set => proje = value; }
        public string SatinAlinanFirma { get => satinAlinanFirma; set => satinAlinanFirma = value; }
        public string HarcamaYapan { get => harcamaYapan; set => harcamaYapan = value; }
        public string Gecensure { get => gecensure; set => gecensure = value; }
        public string UsProjeNo { get => usProjeNo; set => usProjeNo = value; }
        public string GarantiDurumu { get => garantiDurumu; set => garantiDurumu = value; }
        public string MlzTeslimAldTarih { get => mlzTeslimAldTarih; set => mlzTeslimAldTarih = value; }

        public Tamamlanan(int id, int formno, string satno, string masrafyeri, string talepeden, string bolum, string usbolgesi, string abfform, DateTime istenentarih, DateTime tamamlanantarih, string gerekce, string butcekodukalemi, string satbirim, string harcamaturu, string faturaedilecekfirma, string ilgilikisi, string masrafyerino, double harcanantutar, string belgeturu, string belgenumarasi, DateTime belgetarihi, string dosyayolu, string siparisno, int ucteklif, string islemAdimi, string donem,string satOlusturmaTuru,string proje,string satinAlinanFirma, string harcamaYapan,string gecenSure,string usProjeNo, string garantiDurumu, string mlzTeslimAldTarih)
        {
            this.id = id;
            this.formno = formno;
            this.satno = satno;
            this.masrafyeri = masrafyeri;
            this.talepeden = talepeden;
            this.bolum = bolum;
            this.usbolgesi = usbolgesi;
            this.abfform = abfform;
            this.istenentarih = istenentarih;
            this.tamamlanantarih = tamamlanantarih;
            this.gerekce = gerekce;
            this.butcekodukalemi = butcekodukalemi;
            this.satbirim = satbirim;
            this.harcamaturu = harcamaturu;
            this.faturaedilecekfirma = faturaedilecekfirma;
            this.ilgilikisi = ilgilikisi;
            this.masrafyerino = masrafyerino;
            this.harcanantutar = harcanantutar;
            this.belgeturu = belgeturu;
            this.belgenumarasi = belgenumarasi;
            this.belgetarihi = belgetarihi;
            this.dosyayolu = dosyayolu;
            this.siparisno = siparisno;
            this.ucteklif = ucteklif;
            this.islemAdimi = islemAdimi;
            this.donem = donem;
            this.satOlusturmaTuru = satOlusturmaTuru;
            this.proje = proje;
            this.satinAlinanFirma = satinAlinanFirma;
            this.harcamaYapan = harcamaYapan;
            this.gecensure = gecenSure;
            this.usProjeNo = usProjeNo;
            this.garantiDurumu = garantiDurumu;
            this.mlzTeslimAldTarih = mlzTeslimAldTarih;
        }

        public Tamamlanan(string satno, int formno, string masrafyeri, string talepeden, string bolum, string usbolgesi, string abfform, DateTime istenentarih, DateTime tamamlanantarih, string gerekce, string butcekodukalemi, string satbirim, string harcamaturu, string belgeturu, string belgenumarasi, DateTime belgetarihi, string faturaedilecekfirma, string ilgilikisi, string masrafyerino, double harcanantutar, string dosyayolu, string siparisno, int ucteklif,string islemAdimi,string donem, string satOlusturmaTuru,string proje, string satinAlinanFirma, string harcamaYapan, string usProjeNo, string garantiDurumu, string mlzTeslimAldTarih)
        {
            this.Satno = satno;
            this.formno = formno;
            this.Masrafyeri = masrafyeri;
            this.Talepeden = talepeden;
            this.Bolum = bolum;
            this.Usbolgesi = usbolgesi;
            this.Abfform = abfform;
            this.Istenentarih = istenentarih;
            this.Tamamlanantarih = tamamlanantarih;
            this.Gerekce = gerekce;
            this.Butcekodukalemi = butcekodukalemi;
            this.Satbirim = satbirim;
            this.Harcamaturu = harcamaturu;
            this.belgeturu = belgeturu;
            this.belgenumarasi = belgenumarasi;
            this.belgetarihi = belgetarihi;
            this.Faturaedilecekfirma = faturaedilecekfirma;
            this.Ilgilikisi = ilgilikisi;
            this.Masrafyerino = masrafyerino;
            this.Harcanantutar = harcanantutar;
            this.Dosyayolu = dosyayolu;
            this.Siparisno = siparisno;
            this.Ucteklif = ucteklif;
            this.islemAdimi = islemAdimi;
            this.Donem = donem;
            this.satOlusturmaTuru = satOlusturmaTuru;
            this.proje = proje;
            this.satinAlinanFirma = satinAlinanFirma;
            this.harcamaYapan = harcamaYapan;
            this.usProjeNo = usProjeNo;
            this.garantiDurumu = garantiDurumu;
            this.MlzTeslimAldTarih = mlzTeslimAldTarih;
        }
    }
}
