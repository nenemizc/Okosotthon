using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar: OkosEszkoz
    {
        private bool zartE;
        private string pinKod;

        public bool ZartE { get => zartE; private set => zartE = value; }
        public string PinKod { get => pinKod; private set => pinKod = value; }

        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.zartE = true;
            this.pinKod = pinKod;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            throw new NotImplementedException();
        }


        public override string AllapotJelentes()
        {
            return ZartE ? "Az ajtó zárva van." : "Az ajtó nyitva van.";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.pinKod = "0000";
            this.zartE = true;

        }


    }
}
