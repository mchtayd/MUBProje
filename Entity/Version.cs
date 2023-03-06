using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class VersionBilgi
    {
        int id; string versionNo, dosyayolu;

        public int Id { get => id; set => id = value; }
        public string VersionNo { get => versionNo; set => versionNo = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }

        public VersionBilgi(int id, string versionNo, string dosyayolu)
        {
            this.id = id;
            this.versionNo = versionNo;
            this.dosyayolu = dosyayolu;
        }

        public VersionBilgi(string versionNo, string dosyayolu)
        {
            this.versionNo = versionNo;
            this.dosyayolu = dosyayolu;
        }
    }
}
