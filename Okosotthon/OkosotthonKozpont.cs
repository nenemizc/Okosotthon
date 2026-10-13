using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosotthonKozpont
    {
        private readonly List<OkosEszkoz> eszkozok;

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
            foreach (OkosEszkoz eszkoz in this.eszkozok)
            {
                eszkoz.Csatlakozas();
            }
        }

        public int RendszerDiagnosztikaFuttatasa()
        {
            int sikeres = 0;

            foreach (OkosEszkoz eszkoz in this.eszkozok)
            {
                if (eszkoz.DiagnosztikaFuttatasa())
                {
                    sikeres++;
                }
            }

            return sikeres;
        }

        public void OsszesVeszjelzesInditasa()
        {
            foreach (OkosEszkoz eszkoz in this.eszkozok)
            {
                if (eszkoz is IHangjelzo hangjelzoEszkoz)
                {
                    hangjelzoEszkoz.VeszjelzesInditasa();
                }
            }
        }

        public void StatisztikakLekerdezeseEsKiirasa()
        {
            foreach (OkosEszkoz eszkoz in this.eszkozok)
            {
                IStatisztika statEszkoz = eszkoz as IStatisztika;

                if (statEszkoz != null)
                {
                    Console.WriteLine(statEszkoz.StatisztikatKeszit());
                }
            }
        }

        public void MindenIdozitestBeallit(int perc)
        {
            foreach (OkosEszkoz eszkoz in this.eszkozok)
            {
                if (eszkoz is IIdozitheto idozithetoEszkoz)
                {
                    idozithetoEszkoz.IdozitestBeallit(perc);
                }
            }
        }
    }
}