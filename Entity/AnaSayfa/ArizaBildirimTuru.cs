using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class ArizaBildirimTuru
    {
        int sarf, entegrasyon, abf, kismiCalisan, ekstra, sahaKabul, acmaKapat, diger;

        public int Sarf { get => sarf; set => sarf = value; }
        public int Entegrasyon { get => entegrasyon; set => entegrasyon = value; }
        public int Abf { get => abf; set => abf = value; }
        public int KismiCalisan { get => kismiCalisan; set => kismiCalisan = value; }
        public int Ekstra { get => ekstra; set => ekstra = value; }
        public int SahaKabul { get => sahaKabul; set => sahaKabul = value; }
        public int AcmaKapat { get => acmaKapat; set => acmaKapat = value; }
        public int Diger { get => diger; set => diger = value; }

        public ArizaBildirimTuru(int sarf, int entegrasyon, int abf, int kismiCalisan, int ekstra, int sahaKabul, int acmaKapat, int diger)
        {
            this.sarf = sarf;
            this.entegrasyon = entegrasyon;
            this.abf = abf;
            this.kismiCalisan = kismiCalisan;
            this.ekstra = ekstra;
            this.sahaKabul = sahaKabul;
            this.acmaKapat = acmaKapat;
            this.diger = diger;
        }
    }
}
