using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class UstAmirMail
    {
        string adsoyad, oficemail,bolum; int personelid, yetkiid;

        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Oficemail { get => oficemail; set => oficemail = value; }
        public int Personelid { get => personelid; set => personelid = value; }
        public int Yetkiid { get => yetkiid; set => yetkiid = value; }
        public string Bolum { get => bolum; set => bolum = value; }

        public UstAmirMail(string adsoyad, string oficemail, string bolum, int personelid, int yetkiid)
        {
            this.adsoyad = adsoyad;
            this.oficemail = oficemail;
            this.personelid = personelid;
            this.yetkiid = yetkiid;
            this.bolum = bolum;
        }

        public UstAmirMail(string adsoyad, int personelid)
        {
            this.adsoyad = adsoyad;
            this.personelid = personelid;
        }
    }
}
