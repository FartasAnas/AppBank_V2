using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class CompteCourant : Compt
    {
        private readonly MAD decouvert;
        public CompteCourant(Client c,MAD v,MAD d):base(c,v)
        {
            this.decouvert = d;
            this.changetype("Courant");
        }
        public override bool debiter(MAD somme)
        {
            if (this.susome(somme) > decouvert)
            {
                base.debiter(somme);
                return true;
            }

            Console.WriteLine("solde-somme < decouvert");
            return false;
        }
        public override void consulter()
        {
            base.consulter();
            Console.WriteLine("decouvert            :" + this.decouvert.afficherMAD());
        }
    }
}
