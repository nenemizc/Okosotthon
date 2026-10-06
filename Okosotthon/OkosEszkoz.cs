using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public abstract class OkosEszkoz
    {
        private string azonosito;
        private string nev;
        private bool onlineE;
        private DateTime utolsoFrissites;


        public OkosEszkoz(string azonosito, string nev)
        {

            this.azonosito = azonosito;
            this.nev = nev;
            this.onlineE = false;
            this.utolsoFrissites = DateTime.Now;
        }


        public void Csatlakozas()
        {
            this.onlineE = true;
        }


        public void KapcsolatBontasa()
        {
            this.onlineE = false;
        }
        public bool DiagnosztikaFuttatasa()
        {
            if (!this.onlineE)
            {
                return false;
            }
            return this.OnTesztFuttatasa();
        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            Console.WriteLine("Gyáriba visszarakva.");
        }


        public abstract void ParancsVegrehajtasa(string parancs);
        public abstract string AllapotJelentes();
        protected abstract bool OnTesztFuttatasa();
    }
}
