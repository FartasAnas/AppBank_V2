using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class Operation
    {
        private static int cptop=0;
        private readonly int numop;
        private readonly DateTime dateop;
        private readonly MAD montant;
        private readonly string libelle;
        public Operation(string libelle,MAD montant)
        {
            this.numop = ++(Operation.cptop);
            this.dateop = DateTime.Now;
            this.montant = montant;
            this.libelle = libelle;
        }
        public void afficherOP()
        {
            Console.WriteLine("         "+this.libelle + ":" + this.dateop + "|| N°" + this.numop + "||"  + this.montant.afficherMAD());
        }

    }
}
