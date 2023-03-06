using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class ServisFormu
    {
        int id, isAkisNo; string firma, usBolgesi, servisFormNo, mudehaleTuru; DateTime servisTarihi; int jenaratorCalismaSaati; DateTime isBaslamaTarihi, isBitisTarihi; string marka, model, seriNo, guc, servisRaporu, servisYetkilisi, musteri, dosyaYolu, siparisNo;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string Firma { get => firma; set => firma = value; }
        public string UsBolgesi { get => usBolgesi; set => usBolgesi = value; }
        public string ServisFormNo { get => servisFormNo; set => servisFormNo = value; }
        public string MudehaleTuru { get => mudehaleTuru; set => mudehaleTuru = value; }
        public DateTime ServisTarihi { get => servisTarihi; set => servisTarihi = value; }
        public int JenaratorCalismaSaati { get => jenaratorCalismaSaati; set => jenaratorCalismaSaati = value; }
        public DateTime IsBaslamaTarihi { get => isBaslamaTarihi; set => isBaslamaTarihi = value; }
        public DateTime IsBitisTarihi { get => isBitisTarihi; set => isBitisTarihi = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Guc { get => guc; set => guc = value; }
        public string ServisRaporu { get => servisRaporu; set => servisRaporu = value; }
        public string ServisYetkilisi { get => servisYetkilisi; set => servisYetkilisi = value; }
        public string Musteri { get => musteri; set => musteri = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public ServisFormu(int id, int isAkisNo, string firma, string usBolgesi, string servisFormNo, string mudehaleTuru, DateTime servisTarihi, int jenaratorCalismaSaati, DateTime isBaslamaTarihi, DateTime isBitisTarihi, string marka, string model, string seriNo, string guc, string servisRaporu, string servisYetkilisi, string musteri, string dosyaYolu, string siparisNo)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.usBolgesi = usBolgesi;
            this.servisFormNo = servisFormNo;
            this.mudehaleTuru = mudehaleTuru;
            this.servisTarihi = servisTarihi;
            this.jenaratorCalismaSaati = jenaratorCalismaSaati;
            this.isBaslamaTarihi = isBaslamaTarihi;
            this.isBitisTarihi = isBitisTarihi;
            this.marka = marka;
            this.model = model;
            this.seriNo = seriNo;
            this.guc = guc;
            this.servisRaporu = servisRaporu;
            this.servisYetkilisi = servisYetkilisi;
            this.musteri = musteri;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public ServisFormu(int isAkisNo, string firma, string usBolgesi, string servisFormNo, string mudehaleTuru, DateTime servisTarihi, int jenaratorCalismaSaati, DateTime isBaslamaTarihi, DateTime isBitisTarihi, string marka, string model, string seriNo, string guc, string servisRaporu, string servisYetkilisi, string musteri, string dosyaYolu, string siparisNo)
        {
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.usBolgesi = usBolgesi;
            this.servisFormNo = servisFormNo;
            this.mudehaleTuru = mudehaleTuru;
            this.servisTarihi = servisTarihi;
            this.jenaratorCalismaSaati = jenaratorCalismaSaati;
            this.isBaslamaTarihi = isBaslamaTarihi;
            this.isBitisTarihi = isBitisTarihi;
            this.marka = marka;
            this.model = model;
            this.seriNo = seriNo;
            this.guc = guc;
            this.servisRaporu = servisRaporu;
            this.servisYetkilisi = servisYetkilisi;
            this.musteri = musteri;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public ServisFormu(int id, string firma, string usBolgesi, string servisFormNo, string mudehaleTuru, DateTime servisTarihi, int jenaratorCalismaSaati, DateTime isBaslamaTarihi, DateTime isBitisTarihi, string marka, string model, string seriNo, string guc, string servisRaporu, string servisYetkilisi, string musteri)
        {
            this.id = id;
            this.firma = firma;
            this.usBolgesi = usBolgesi;
            this.servisFormNo = servisFormNo;
            this.mudehaleTuru = mudehaleTuru;
            this.servisTarihi = servisTarihi;
            this.jenaratorCalismaSaati = jenaratorCalismaSaati;
            this.isBaslamaTarihi = isBaslamaTarihi;
            this.isBitisTarihi = isBitisTarihi;
            this.marka = marka;
            this.model = model;
            this.seriNo = seriNo;
            this.guc = guc;
            this.servisRaporu = servisRaporu;
            this.servisYetkilisi = servisYetkilisi;
            this.musteri = musteri;
        }
    }
}
