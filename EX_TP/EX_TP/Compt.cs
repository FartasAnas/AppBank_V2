using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    abstract class Compt
    {
        private readonly int NumComp;
        private static int cpt=0;
        private readonly Client titulaire;
        private MAD sold;
        private static MAD plafond=new MAD(5000);
        private Operation[] opts = new Operation[0];
        private DateTime dateO = DateTime.Now;
        private DateTime dateE = DateTime.Now.AddYears(5);
        private string TypeCompt;

        public Compt(Client c,MAD v)
        {
            this.NumComp = ++Compt.cpt;
            this.titulaire=c;
            this.sold = v;
            this.TypeCompt = "Normal";
        }
        public virtual bool crediter(MAD somme)
        {
            if (somme > 0)
            {
                sold += somme;
                Console.WriteLine("New solde de crediteur:"+ sold.afficherMAD());        
                Array.Resize(ref opts, opts.Length + 1);
                opts[opts.Length - 1] = new Operation("crediter", somme);
                return true;
            }
            else
            {
                Console.WriteLine("la somme est negative");
            }
            return false;
        }
        public virtual bool debiter(MAD somme)
        {

            if (somme > 0)
            {
                if (somme < plafond)
                {
                    if (sold > somme)
                    {
                        sold -= somme;
                        Console.WriteLine("New solde de debiteur:"+ sold.afficherMAD());
                        Array.Resize(ref opts, opts.Length + 1);
                        opts[opts.Length - 1] = new Operation("debiter", somme);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("solde insufision");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("la somme est superior a le platform");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("la somme est negative");
                return false;
            }
        }
        public virtual bool verser(Compt c,MAD somme)
        {
            if (this.debiter(somme) == true)
            {
                if (c.crediter(somme) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public MAD Xsome(MAD v)
        {
            return sold * v;
        }
        public MAD susome(MAD v)
        {
            MAD res = this.sold - v;
            return res;
        }
        public bool ajouter(MAD V)
        {
            this.sold += V;
            return true;
        }
        public void ajoutop(string l,MAD s)
        {
            Array.Resize(ref opts, opts.Length + 1);
            opts[opts.Length - 1] = new Operation(l, s);
            Console.WriteLine("New solde:" + this.sold.afficherMAD());
        }
        public void changetype(string T)
        {
            this.TypeCompt = T;
        }
        public bool testtypeEpargne()
        {
            return this.TypeCompt == "Epargne";
        }
        public virtual void AjoutInteret()
        {}
        public virtual void consulter()
        {
            titulaire.affiche();
            Console.WriteLine("Date de d'ouverture  :" + dateO.ToString());
            Console.WriteLine("Date de d'expiration :" + dateE.ToString());
            Console.WriteLine("Num Compte           :"+this.NumComp);
            Console.WriteLine("plafond              :" + plafond.afficherMAD());
            Console.WriteLine("sold                 :" + sold.afficherMAD());
            Console.WriteLine("type de compte       :"+this.TypeCompt);
            Console.WriteLine("Les operations       :");
            foreach (Operation i in opts)
            {
                i.afficherOP();
            }
        }

    }
}
