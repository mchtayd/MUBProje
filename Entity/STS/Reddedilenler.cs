using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class Reddedilenler
    {
        int id; int satFormNo, satNo; string masrafYeri, talepEden, bolum, usBolgesi, abfFormNo; DateTime istenenTarih; string gerekce, siparisNo, dosyaYolu, redNedeni, durum, teklifDurumu, donem; int personelId; string butceKodu, satBirim, harcamaTuru, faturaFirma, ilgiliKisi, masrafYeriNo; int ucTeklif; string firmaBilgisi, talepEdenPersonel, personelSiparis, unvani, personelMasYeriNo, islemAdimi, satOlusturmaTuru;

        public int Id { get => id; set => id = value; }
        public int SatFormNo { get => satFormNo; set => satFormNo = value; }
        public int SatNo { get => satNo; set => satNo = value; }
        public string MasrafYeri { get => masrafYeri; set => masrafYeri = value; }
        public string TalepEden { get => talepEden; set => talepEden = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string UsBolgesi { get => usBolgesi; set => usBolgesi = value; }
        public string AbfFormNo { get => abfFormNo; set => abfFormNo = value; }
        public DateTime IstenenTarih { get => istenenTarih; set => istenenTarih = value; }
        public string Gerekce { get => gerekce; set => gerekce = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string RedNedeni { get => redNedeni; set => redNedeni = value; }
        public string Durum { get => durum; set => durum = value; }
        public string TeklifDurumu { get => teklifDurumu; set => teklifDurumu = value; }
        public string Donem { get => donem; set => donem = value; }
        public int PersonelId { get => personelId; set => personelId = value; }
        public string ButceKodu { get => butceKodu; set => butceKodu = value; }
        public string SatBirim { get => satBirim; set => satBirim = value; }
        public string HarcamaTuru { get => harcamaTuru; set => harcamaTuru = value; }
        public string FaturaFirma { get => faturaFirma; set => faturaFirma = value; }
        public string IlgiliKisi { get => ilgiliKisi; set => ilgiliKisi = value; }
        public string MasrafYeriNo { get => masrafYeriNo; set => masrafYeriNo = value; }
        public int UcTeklif { get => ucTeklif; set => ucTeklif = value; }
        public string FirmaBilgisi { get => firmaBilgisi; set => firmaBilgisi = value; }
        public string TalepEdenPersonel { get => talepEdenPersonel; set => talepEdenPersonel = value; }
        public string PersonelSiparis { get => personelSiparis; set => personelSiparis = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string PersonelMasYeriNo { get => personelMasYeriNo; set => personelMasYeriNo = value; }
        public string IslemAdimi { get => islemAdimi; set => islemAdimi = value; }
        public string SatOlusturmaTuru { get => satOlusturmaTuru; set => satOlusturmaTuru = value; }

        public Reddedilenler(int id, int satFormNo, int satNo, string masrafYeri, string talepEden, string bolum, string usBolgesi, string abfFormNo, DateTime istenenTarih, string gerekce, string siparisNo, string dosyaYolu, string redNedeni, string durum, string teklifDurumu, string donem, int personelId, string butceKodu, string satBirim, string harcamaTuru, string faturaFirma, string ilgiliKisi, string masrafYeriNo, int ucTeklif, string firmaBilgisi, string talepEdenPersonel, string personelSiparis, string unvani, string personelMasYeriNo, string islemAdimi, string satOlusturmaTuru)
        {
            this.id = id;
            this.satFormNo = satFormNo;
            this.satNo = satNo;
            this.masrafYeri = masrafYeri;
            this.talepEden = talepEden;
            this.bolum = bolum;
            this.usBolgesi = usBolgesi;
            this.abfFormNo = abfFormNo;
            this.istenenTarih = istenenTarih;
            this.gerekce = gerekce;
            this.siparisNo = siparisNo;
            this.dosyaYolu = dosyaYolu;
            this.redNedeni = redNedeni;
            this.durum = durum;
            this.teklifDurumu = teklifDurumu;
            this.donem = donem;
            this.personelId = personelId;
            this.butceKodu = butceKodu;
            this.satBirim = satBirim;
            this.harcamaTuru = harcamaTuru;
            this.faturaFirma = faturaFirma;
            this.ilgiliKisi = ilgiliKisi;
            this.masrafYeriNo = masrafYeriNo;
            this.ucTeklif = ucTeklif;
            this.firmaBilgisi = firmaBilgisi;
            this.talepEdenPersonel = talepEdenPersonel;
            this.personelSiparis = personelSiparis;
            this.unvani = unvani;
            this.personelMasYeriNo = personelMasYeriNo;
            this.islemAdimi = islemAdimi;
            this.satOlusturmaTuru = satOlusturmaTuru;
        }

        public Reddedilenler(int satFormNo, int satNo, string masrafYeri, string talepEden, string bolum, string usBolgesi, string abfFormNo, DateTime istenenTarih, string gerekce, string siparisNo, string dosyaYolu, string redNedeni, string durum, string teklifDurumu, string donem, int personelId, string butceKodu, string satBirim, string harcamaTuru, string faturaFirma, string ilgiliKisi, string masrafYeriNo, int ucTeklif, string firmaBilgisi, string talepEdenPersonel, string personelSiparis, string unvani, string personelMasYeriNo, string islemAdimi, string satOlusturmaTuru)
        {
            this.satFormNo = satFormNo;
            this.satNo = satNo;
            this.masrafYeri = masrafYeri;
            this.talepEden = talepEden;
            this.bolum = bolum;
            this.usBolgesi = usBolgesi;
            this.abfFormNo = abfFormNo;
            this.istenenTarih = istenenTarih;
            this.gerekce = gerekce;
            this.siparisNo = siparisNo;
            this.dosyaYolu = dosyaYolu;
            this.redNedeni = redNedeni;
            this.durum = durum;
            this.teklifDurumu = teklifDurumu;
            this.donem = donem;
            this.personelId = personelId;
            this.butceKodu = butceKodu;
            this.satBirim = satBirim;
            this.harcamaTuru = harcamaTuru;
            this.faturaFirma = faturaFirma;
            this.ilgiliKisi = ilgiliKisi;
            this.masrafYeriNo = masrafYeriNo;
            this.ucTeklif = ucTeklif;
            this.firmaBilgisi = firmaBilgisi;
            this.talepEdenPersonel = talepEdenPersonel;
            this.personelSiparis = personelSiparis;
            this.unvani = unvani;
            this.personelMasYeriNo = personelMasYeriNo;
            this.islemAdimi = islemAdimi;
            this.satOlusturmaTuru = satOlusturmaTuru;
        }
    }
}
