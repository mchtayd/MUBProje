using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SatDataGridview1
    {
        int id, personelId; int formno, satno; string masrafyeri, talepeden, bolum, usbolgesi, abfformno, burcekodu, satbirim, harcamaturu, faturafirma, ilgilikisi, masyerino; DateTime tarih; string gerekce, siparisNo, dosyaYolu; int uctekilf; string firmaBilgisi, talepEdenPersonel, personelSiparis, unvani, personelMasYerNo, personelMasYeri, belgeTuru, belgeNumarasi;DateTime belgeTarihi; string islemAdimi, donem, satOlusturmaTuru, redNedeni,durum,teklifDurumu,proje,satinAlinanFirma,mailSiniri,mailDurumu;

        public int Id { get => id; set => id = value; }
        public int Formno { get => formno; set => formno = value; }
        public int Satno { get => satno; set => satno = value; }
        public string Masrafyeri { get => masrafyeri; set => masrafyeri = value; }
        public string Talepeden { get => talepeden; set => talepeden = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string Usbolgesi { get => usbolgesi; set => usbolgesi = value; }
        public string Abfformno { get => abfformno; set => abfformno = value; }
        public string Burcekodu { get => burcekodu; set => burcekodu = value; }
        public string Satbirim { get => satbirim; set => satbirim = value; }
        public string Harcamaturu { get => harcamaturu; set => harcamaturu = value; }
        public string Faturafirma { get => faturafirma; set => faturafirma = value; }
        public string Ilgilikisi { get => ilgilikisi; set => ilgilikisi = value; }
        public string Masyerino { get => masyerino; set => masyerino = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Gerekce { get => gerekce; set => gerekce = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public int Uctekilf { get => uctekilf; set => uctekilf = value; }
        public int PersonelId { get => personelId; set => personelId = value; }
        public string FirmaBilgisi { get => firmaBilgisi; set => firmaBilgisi = value; }
        public string TalepEdenPersonel { get => talepEdenPersonel; set => talepEdenPersonel = value; }
        public string PersonelSiparis { get => personelSiparis; set => personelSiparis = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string PersonelMasYerNo { get => personelMasYerNo; set => personelMasYerNo = value; }
        public string PersonelMasYeri { get => personelMasYeri; set => personelMasYeri = value; }
        public string BelgeTuru { get => belgeTuru; set => belgeTuru = value; }
        public string BelgeNumarasi { get => belgeNumarasi; set => belgeNumarasi = value; }
        public DateTime BelgeTarihi { get => belgeTarihi; set => belgeTarihi = value; }
        public string IslemAdimi { get => islemAdimi; set => islemAdimi = value; }
        public string Donem { get => donem; set => donem = value; }
        public string SatOlusturmaTuru { get => satOlusturmaTuru; set => satOlusturmaTuru = value; }
        public string RedNedeni { get => redNedeni; set => redNedeni = value; }
        public string Durum { get => durum; set => durum = value; }
        public string TeklifDurumu { get => teklifDurumu; set => teklifDurumu = value; }
        public string Proje { get => proje; set => proje = value; }
        public string SatinAlinanFirma { get => satinAlinanFirma; set => satinAlinanFirma = value; }
        public string MailSiniri { get => mailSiniri; set => mailSiniri = value; }
        public string MailDurumu { get => mailDurumu; set => mailDurumu = value; }

        public SatDataGridview1(int id, int formno, int satno, string masrafyeri, string talepeden, string bolum, string usbolgesi, string abfformno, 
            DateTime tarih, string gerekce, string siparisNo, string dosyaYolu, int personelId,string talepEdenPersonel,string personelSiparis, string unvani, 
            string personelMasYerNo,string personelMasYeri, string islemAdimi,string donem, string satOlusturmaTuru, string redNedeni, string durum, string teklifDurumu,int uctekilf,string proje, string satinAlinanFirma)
        {
            this.Id = id;
            this.Formno = formno;
            this.Satno = satno;
            this.Masrafyeri = masrafyeri;
            this.Talepeden = talepeden;
            this.Bolum = bolum;
            this.Usbolgesi = usbolgesi;
            this.Abfformno = abfformno;
            this.Tarih = tarih;
            this.Gerekce = gerekce;
            this.SiparisNo = siparisNo;
            this.DosyaYolu = dosyaYolu;
            this.personelId = personelId;
            this.talepEdenPersonel = talepEdenPersonel;
            this.personelSiparis = personelSiparis;
            this.unvani = unvani;
            this.personelMasYerNo = personelMasYerNo;
            this.personelMasYeri = personelMasYeri;
            this.islemAdimi = islemAdimi;
            this.donem = donem;
            this.satOlusturmaTuru = satOlusturmaTuru;
            this.redNedeni = redNedeni;
            this.durum = durum;
            this.teklifDurumu = teklifDurumu;
            this.uctekilf = uctekilf;
            this.proje = proje;
            this.satinAlinanFirma = satinAlinanFirma;
        }

        public SatDataGridview1(int satno,int formno, string masrafyeri, string talepeden, string bolum, string usbolgesi, string abfformno, DateTime tarih, string gerekce, string siparisNo, string talepEdenPersonel,string personeSiparis,string unvani,string personelMasYerNo, string personelMasYeri, string dosyaYolu, int personelId,string islemAdimi,string donem, string satOlusturmaTuru,string proje, string satinAlinanFirma)
        {
            this.formno = formno;
            this.masrafyeri = masrafyeri;
            this.talepeden = talepeden;
            this.bolum = bolum;
            this.usbolgesi = usbolgesi;
            this.abfformno = abfformno;
            this.Tarih = tarih;
            this.gerekce = gerekce;
            this.siparisNo = siparisNo;
            this.dosyaYolu = dosyaYolu;
            this.personelId = personelId;
            this.talepEdenPersonel = talepEdenPersonel;
            this.personelSiparis = personeSiparis;
            this.unvani = unvani;
            this.personelMasYerNo = personelMasYerNo;
            this.personelMasYeri = personelMasYeri;
            this.islemAdimi = islemAdimi;
            this.satno = satno;
            this.donem = donem;
            this.satOlusturmaTuru = satOlusturmaTuru;
            this.proje = proje;
            this.satinAlinanFirma = satinAlinanFirma;
        }

        public SatDataGridview1(int satno, string burcekodu, string satbirim, string harcamaturu, string faturafirma, string ilgilikisi,
            string masyerino, string siparisNo, int uctekilf, string dosyayolu,string islemAdimi)
        {
            this.Satno = satno;
            this.Burcekodu = burcekodu;
            this.Satbirim = satbirim;
            this.Harcamaturu = harcamaturu;
            this.Faturafirma = faturafirma;
            this.Ilgilikisi = ilgilikisi;
            this.Masyerino = masyerino;
            this.SiparisNo = siparisNo;
            this.Uctekilf = uctekilf;
            this.DosyaYolu = dosyayolu;
            this.islemAdimi = islemAdimi;
        }

        public SatDataGridview1(int id, int formno, int satno, string masrafyeri, string talepeden, string bolum, string usbolgesi, string abfformno, DateTime tarih, string gerekce, string siparisNo, string dosyaYolu, string burcekodu, string satbirim, string harcamaturu, string faturafirma, string ilgilikisi, string masyerino, int uctekilf,string firmaBilgisi,string talepEdenPersonel, string personelSiparis, string unvani, string personelMasYerNo, string personelMasYeri, string belgeTuru, string belgeNumarasi, DateTime belgeTarihi, string islemAdimi,string donem, string satOlusturmaTuru, string redNedeni, string durum,string teklifDurumu,string proje, string satinAlinanFirma,string mailSiniri,string mailDurumu)
        {
            this.Id = id;
            this.Formno = formno;
            this.Satno = satno;
            this.Masrafyeri = masrafyeri;
            this.Talepeden = talepeden;
            this.Bolum = bolum;
            this.Usbolgesi = usbolgesi;
            this.Abfformno = abfformno;
            this.Burcekodu = burcekodu;
            this.Satbirim = satbirim;
            this.Harcamaturu = harcamaturu;
            this.Faturafirma = faturafirma;
            this.Ilgilikisi = ilgilikisi;
            this.Masyerino = masyerino;
            this.Tarih = tarih;
            this.Gerekce = gerekce;
            this.SiparisNo = siparisNo;
            this.DosyaYolu = dosyaYolu;
            this.Uctekilf = uctekilf;
            this.firmaBilgisi = firmaBilgisi;
            this.TalepEdenPersonel = talepEdenPersonel;
            this.personelSiparis = personelSiparis;
            this.unvani = unvani;
            this.personelMasYerNo = personelMasYerNo;
            this.personelMasYeri = personelMasYeri;
            this.belgeTuru = belgeTuru;
            this.belgeNumarasi = belgeNumarasi;
            this.belgeTarihi = belgeTarihi;
            this.islemAdimi = islemAdimi;
            this.donem = donem;
            this.satOlusturmaTuru = satOlusturmaTuru;
            this.redNedeni = redNedeni;
            this.durum = durum;
            this.teklifDurumu = teklifDurumu;
            this.proje = proje;
            this.satinAlinanFirma = satinAlinanFirma;
            this.mailSiniri = mailSiniri;
            this.mailDurumu = mailDurumu;
        }

        public SatDataGridview1(string usbolgesi, string abfformno, string gerekce)
        {
            this.Usbolgesi = usbolgesi;
            this.Abfformno = abfformno;
            this.Gerekce = gerekce;
        }
        public SatDataGridview1(string burcekodu, string satbirim, string harcamaturu, string faturafirma, string ilgilikisi, string masyerino)
        {
            this.Burcekodu = burcekodu;
            this.Satbirim = satbirim;
            this.Harcamaturu = harcamaturu;
            this.Faturafirma = faturafirma;
            this.Ilgilikisi = ilgilikisi;
            this.Masyerino = masyerino;
        }

        public SatDataGridview1(string siparisNo)
        {
            this.siparisNo = siparisNo;
        }

        public SatDataGridview1(string burcekodu, string satbirim, string harcamaturu, string faturafirma, string ilgilikisi, string masyerino, string siparisNo, int uctekilf, string belgeTuru, string belgeNumarasi, DateTime belgeTarihi,string islemAdimi,string donem) : this(burcekodu, satbirim, harcamaturu, faturafirma, ilgilikisi, masyerino)
        {
            this.siparisNo = siparisNo;
            this.uctekilf = uctekilf;
            this.belgeTuru = belgeTuru;
            this.belgeNumarasi = belgeNumarasi;
            this.belgeTarihi = belgeTarihi;
            this.islemAdimi = islemAdimi;
            this.donem = donem;
        }

        public SatDataGridview1(int id, string usbolgesi, string abfformno, string burcekodu, string satbirim, string harcamaturu, string faturafirma, string ilgilikisi, string masyerino, DateTime tarih, string gerekce, string talepEdenPersonel, string personelSiparis, string unvani, string personelMasYerNo, string personelMasYeri, string donem)
        {
            this.id = id;
            this.usbolgesi = usbolgesi;
            this.abfformno = abfformno;
            this.burcekodu = burcekodu;
            this.satbirim = satbirim;
            this.harcamaturu = harcamaturu;
            this.faturafirma = faturafirma;
            this.ilgilikisi = ilgilikisi;
            this.masyerino = masyerino;
            this.tarih = tarih;
            this.gerekce = gerekce;
            this.talepEdenPersonel = talepEdenPersonel;
            this.personelSiparis = personelSiparis;
            this.unvani = unvani;
            this.personelMasYerNo = personelMasYerNo;
            this.personelMasYeri = personelMasYeri;
            this.donem = donem;
        }
    }

}
