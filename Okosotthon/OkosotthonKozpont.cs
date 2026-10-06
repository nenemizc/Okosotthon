using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosotthonKozpont
    {
        private List<OkosEszkoz> eszkozok;

        public OkosotthonKozpont()
        {
            this.eszkozok = new List<OkosEszkoz>();
        }

        public void EszkozHozzaadasa(OkosEszkoz eszkoz)
        {
            this.eszkozok.Add(eszkoz);
        }

     
        public void OsszesCsatlakoztatasa()
        {
            throw new NotImplementedException();
        }

        public int RendszerDiagnosztikaFuttatasa()
        {
            throw new NotImplementedException();
        }

    }
}
