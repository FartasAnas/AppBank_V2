using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class CompteEpargne : Compt
    {
        private readonly double TauxInteret;
        private Operation[] operation = new Operation[0];
        
        public CompteEpargne(Client c,MAD v,double T): base(c,v)
        {
            while(T < 0 || T > 100)
            {
                Console.WriteLine("le taux est negative!!!");
                Console.Write("Entrez un autre TauxInteret:");
                T= Convert.ToDouble(Console.ReadLine());
            }
            this.TauxInteret = T;
            this.changetype("Epargne");
        }
        public MAD calculInteret()
        {
            return this.Xsome(new MAD(this.TauxInteret / 100));
        }
        public override void AjoutInteret()
        {
            base.AjoutInteret();
            this.ajouter(this.calculInteret());
            this.ajoutop("Interet", this.calculInteret());
        }
        public override void consulter()
        {
            base.consulter();
            Console.WriteLine("Taux Interet         :" + this.TauxInteret+"%");
            Console.WriteLine("Interet              :" + calculInteret().afficherMAD());
        }
    }
}
