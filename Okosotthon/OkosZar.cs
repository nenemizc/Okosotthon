using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz, IHangjelzo, IStatisztika
    {
        private string pinKod;
        public bool ZartE { get; private set; }

        private int sikertelenPróbakSzama;
        private int osszesNyitasSzama;

        public OkosZar(string azonosito, string nev, string pinKod)
            : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.ZartE = true;
            this.sikertelenPróbakSzama = 0;
            this.osszesNyitasSzama = 0;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("NYITAS:"))
            {
                string megadottPin = parancs.Substring("NYITAS:".Length);

                if (megadottPin == this.pinKod)
                {
                    this.ZartE = false;
                    this.osszesNyitasSzama++;
                }
                else
                {
                    this.sikertelenPróbakSzama++;

                    if (this.sikertelenPróbakSzama >= 3)
                    {
                        VeszjelzesInditasa();
                    }
                    else
                    {
                        Csipog(200);
                    }
                }
            }
            else if (parancs == "ZARAS")
            {
                this.ZartE = true;
            }
        }

        public override string AllapotJelentes()
        {
            if (this.ZartE)
            {
                return "ZÁRVA";
            }

            return "NYITVA";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();

            this.pinKod = "0000";
            this.ZartE = true;
            this.sikertelenPróbakSzama = 0;
            this.osszesNyitasSzama = 0;
        }

        public void Csipog(int hosszu)
        {
            Console.WriteLine($"[OkosZár - {Nev}] *Csipogás* ({hosszu} ms)");
        }

        public void VeszjelzesInditasa()
        {
            Console.WriteLine($"[OkosZár - {Nev}] VÉSZJELZÉS! Túl sok sikertelen próbálkozás ({sikertelenPróbakSzama} alkalom).");
        }

        public string StatisztikatKeszit()
        {
            return $"[OkosZár Statisztika] Azonosító: {Azonosito}, Név: {Nev}, Összes sikeres nyitás: {osszesNyitasSzama}, Sikertelen PIN próbálkozások: {sikertelenPróbakSzama}";
        }
    }
}