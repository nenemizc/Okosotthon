using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz, IIdozitheto, IStatisztika
    {
        public double JelenlegiHomerseklet { get; private set; }
        public double CelHomerseklet { get; private set; }

        private int maradtIdo;

        public Termosztat(string azonosito, string nev, double celHomerseklet)
            : base(azonosito, nev)
        {
            this.JelenlegiHomerseklet = 21.0;
            this.CelHomerseklet = celHomerseklet;
            this.maradtIdo = 0;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string ertek = parancs.Substring("BEALLIT_HOMERSEKLET:".Length);
                this.CelHomerseklet = double.Parse(ertek, CultureInfo.InvariantCulture);
            }
        }

        public override string AllapotJelentes()
        {
            return "Jelenlegi hőmérséklet: " + this.JelenlegiHomerseklet +
                   " °C, célhőmérséklet: " + this.CelHomerseklet + " °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 &&
                   this.CelHomerseklet <= 35.0;
        }

        public void IdozitestBeallit(int perc)
        {
            this.maradtIdo = perc;
        }

        public int GetMaradtIdo()
        {
            return this.maradtIdo;
        }

        public string StatisztikatKeszit()
        {
            return $"[Termosztát Statisztika] Azonosító: {Azonosito}, Név: {Nev}, Jelenlegi hőmérséklet: {JelenlegiHomerseklet} °C, Célhőmérséklet: {CelHomerseklet} °C, Hátralévő fűtési idő: {maradtIdo} perc";
        }
    }
}