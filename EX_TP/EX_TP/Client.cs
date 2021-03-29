using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class Client
    {
        private readonly string Nom, Prenom;
        private string addresse;
        public Client (string n,string p,string a)
        {
            this.Nom = n;
            this.Prenom = p;
            this.addresse = a;
        }
        public void affiche()
        {
            Console.WriteLine("Nom                  : " + this.Nom);
            Console.WriteLine("Prenom               : " + this.Prenom);
            Console.WriteLine("addresse             : " + this.addresse);
        }
        public bool comparaison(string N,string P)
        {
            return this.Nom == N && this.Prenom == P;
        }
    }
}
