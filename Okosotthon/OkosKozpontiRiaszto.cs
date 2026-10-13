using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosKozpontiRiaszto : OkosEszkoz, IIdozitheto, IHangjelzo, IStatisztika
    {
        private int maradtIdoPerc;
        private int inditottVeszjelzesekSzama;
        private bool aktivRiasztasE;

        public OkosKozpontiRiaszto(string azonosito, string nev)
            : base(azonosito, nev)
        {
            this.maradtIdoPerc = 0;
            this.inditottVeszjelzesekSzama = 0;
            this.aktivRiasztasE = false;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == "AKTIVALAS")
            {
                this.aktivRiasztasE = true;
            }
            else if (parancs == "HATAKTIVALAS")
            {
                this.aktivRiasztasE = false;
            }
        }

        public override string AllapotJelentes()
        {
            return $"Központi riasztó állapota: {(aktivRiasztasE ? "ÉLESÍTVE" : "HATÁSTALANÍTVA")}, Hátralévő idő: {maradtIdoPerc} perc";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public void IdozitestBeallit(int perc)
        {
            this.maradtIdoPerc = perc;
        }

        public int GetMaradtIdo()
        {
            return this.maradtIdoPerc;
        }

        public void Csipog(int hosszu)
        {
            Console.WriteLine($"[Központi Riasztó - {Nev}] *Finom figyelmeztető csipogás* ({hosszu} ms)");
        }

        public void VeszjelzesInditasa()
        {
            this.inditottVeszjelzesekSzama++;
            this.aktivRiasztasE = true;
            Console.WriteLine($"[Központi Riasztó - {Nev}] KÖZPONTI VÉSZJELZÉS INDÍTVA! (Összes vészjelzés: {inditottVeszjelzesekSzama})");
        }

        public string StatisztikatKeszit()
        {
            return $"[Központi Riasztó Statisztika] Azonosító: {Azonosito}, Név: {Nev}, Élesítve: {(aktivRiasztasE ? "Igen" : "Nem")}, Indított vészjelzések száma: {inditottVeszjelzesekSzama}, Időzítő hátralévő ideje: {maradtIdoPerc} perc";
        }
    }
}