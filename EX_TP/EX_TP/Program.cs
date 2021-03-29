using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Compt[] Compts = new Compt[0];
            Client[] clients = new Client[0];
            Int32 choix = 0, cptCo = 0,cptCl =0;
            Int32 nbrCl = 0, nbrCo = 0, Numc = 0;
            while (choix != 8)
            {
                Console.WriteLine("-------------Menu-------------");
                Console.WriteLine("| 1) Ajouter un client       |");
                Console.WriteLine("| 2) Cree un Compte bancaire |");
                Console.WriteLine("| 3) Credite                 |");
                Console.WriteLine("| 4) Debite                  |");
                Console.WriteLine("| 5) Verser                  |");
                Console.WriteLine("| 6) Ajout Interet           |");
                Console.WriteLine("| 7) Consulter               |");
                Console.WriteLine("| 8) Quitter                 |");
                Console.WriteLine("------------------------------");
                do
                {
                    Console.Write("Votre choix:");
                    choix = Convert.ToInt32(Console.ReadLine());
                    if ((choix > 2 && choix < 7) && cptCo == 0)
                    {
                        Console.WriteLine("Erreur Aucun Compte trouver!!!!!!");
                        Console.WriteLine("Veuille cree un Compte");
                        Console.WriteLine("----------------------------");
                    }
                    if (choix == 2 && cptCl == 0)
                    {
                        Console.WriteLine("Erreur Aucun Client trouver!!!!!!");
                        Console.WriteLine("Veuille ajouter un client");
                        Console.WriteLine("----------------------------");
                    }
                } while (((choix > 2 && choix < 7) && cptCo == 0) || (choix == 2 && cptCl == 0));
                Console.Clear();
                switch (choix)
                {
                    case 1:
                        Console.WriteLine("-----------Ajoutation des clients-----------");
                        do
                        {
                            Console.Write("Entrez le nombre du client qui tu veux ajouter:");
                            Numc= Convert.ToInt32(Console.ReadLine()); 
                            if(Numc < 0)
                            {
                                Console.WriteLine("Erreur le nombre est negative!!!!!!");
                                Console.WriteLine("Veuille entre un nombre");
                                Console.WriteLine("----------------------------");
                            }
                        } while (Numc < 0);
                        nbrCl += Numc;
                        Console.WriteLine("----------------------------------------");
                        Console.Clear();
                        while(cptCl<nbrCl)
                        {
                            Console.WriteLine("----Les information de client " + (cptCl + 1) + "----");
                            Console.Write("Nom      :");
                            string N = Console.ReadLine();
                            Console.Write("Prenom   :");
                            string P = Console.ReadLine();
                            Console.Write("Addresse :");
                            string A = Console.ReadLine();
                            Array.Resize(ref clients, clients.Length + 1);
                            clients[cptCl] = new Client(N, P, A);
                            cptCl++;
                            Console.WriteLine("------------------------------------");
                            Console.Clear();
                        } 
                        break;
                    case 2:
                        Console.WriteLine("-----------Creation des comptes-----------");
                        do {
                            Console.Write("Entrez le nombre du compte qui tu veux cree:");
                            Numc = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("----------------------------------------");
                            if (Numc < 0)
                            {
                                Console.WriteLine("Erreur le nombre est negative!!!!!!");
                                Console.WriteLine("Veuille entre un nombre");
                                Console.WriteLine("----------------------------");
                            }
                        } while (Numc < 0);
                        nbrCo += Numc;
                        Console.WriteLine("----------------------------------------");
                        Console.Clear();
                        while (cptCo < nbrCo)
                        {
                            Console.WriteLine("-----------Compte N°"+(cptCo+1)+"-----------");
                            string typeCompte;
                            do
                            {
                                Console.Write("Entrez le type de compte (Courant/Epargne):");
                                typeCompte = Console.ReadLine();
                            } while (typeCompte != "Courant" && typeCompte != "Epargne");
                            int Ct=0;
                            do
                            {
                                Console.WriteLine("----liaison de compte avec Client----");
                                Console.Write("Nom de client    :");
                                string N = Console.ReadLine();
                                Console.Write("Prenom de client :");
                                string P = Console.ReadLine();
                                Console.WriteLine("-------------------------------------");
                                while (Ct < cptCl + 1)
                                {
                                    if (clients[Ct].comparaison(N, P))
                                    {
                                        break;
                                    }
                                    Ct++;
                                }
                                if (Ct == cptCl)
                                {
                                    Console.WriteLine("Erreur Aucun Client trouver avec ce Nom!!!!!!");
                                    Console.WriteLine("Veuille entre un autre Client");
                                    Console.WriteLine("----------------------------");
                                }
                            } while (Ct == cptCl);
                            Console.Write("solde:");
                            double s = Convert.ToDouble(Console.ReadLine());

                            if (typeCompte== "Courant")
                            {
                                Console.Write("decouvet :");
                                double decouvet= Convert.ToDouble(Console.ReadLine());
                                Array.Resize(ref Compts, Compts.Length + 1);
                                Compts[cptCo] = new CompteCourant(clients[Ct], new MAD(s), new MAD(decouvet));

                            }
                            else
                            {
                                Console.Write("TauxInteret :");
                                double TauxInteret = Convert.ToDouble(Console.ReadLine());
                                Array.Resize(ref Compts, Compts.Length + 1);
                                Compts[cptCo] = new CompteEpargne(clients[Ct], new MAD(s), TauxInteret);   
                            }
                            cptCo++;
                            Console.Clear();
                        }
                        break;
                    case 3:
                        Console.WriteLine("-----------Crediter-----------");
                        Numc = 1;
                        if (cptCo != 1)
                        {
                            do
                            {
                                Console.Write("Entre le N° compte qui tu veux le crediter:");
                                Numc = Convert.ToInt32(Console.ReadLine());
                                if (Compts[Numc - 1] == null)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur se compte n'existe pas!!!!!!");
                                    Console.WriteLine("Veuille entrez un autre compt");
                                    Console.WriteLine("----------------------------------");
                                }
                            } while (Compts[Numc - 1] == null);
                        }
                        if (Compts[Numc - 1] != null)
                        {
                            Console.Write("Somme:");
                            MAD somme = new MAD(Convert.ToDouble(Console.ReadLine()));
                            Compts[Numc - 1].crediter(somme);
                            Console.Clear();
                        }
                        break;
                    case 4:
                        Console.WriteLine("-----------Debiter-----------");
                        Numc = 1;
                        if (cptCo != 1)
                        {
                            do
                            {
                                Console.Write("Entre le compte qui tu veux le debiter:");
                                Numc = Convert.ToInt32(Console.ReadLine());
                                if (Compts[Numc - 1] == null)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur se compte est vide!!!!!!");
                                    Console.WriteLine("Veuille entrez un autre compt");
                                    Console.WriteLine("----------------------------------");
                                }
                            } while (Compts[Numc - 1] == null);
                        }
                        if (Compts[Numc - 1] != null)
                        {
                            Console.Write("Somme:");
                            MAD somme = new MAD(Convert.ToDouble(Console.ReadLine()));
                            Compts[Numc - 1].debiter(somme);
                            Console.Clear();
                        }
                        break;
                    case 5:
                        Console.WriteLine("-----------Verser-----------");
                        int Numc1;
                        if (cptCo >= 2) 
                        {
                            do
                            {
                                Console.Write("Entre le compte qui vas envoyer:");
                                Numc = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Entre le compte qui vas resever:");
                                Numc1 = Convert.ToInt32(Console.ReadLine());
                                if (Compts[Numc - 1] == null || Compts[Numc1 - 1] == null)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur un ou plusieur  comptes sont vide!!!!!!");
                                    Console.WriteLine("Veuille entrez des autres compts");
                                    Console.WriteLine("----------------------------------");
                                }
                                if(Numc == Numc1)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur tu ne peux pas verser a le meme compte!!!!!!");
                                    Console.WriteLine("Veuille entrez des autres compts");
                                    Console.WriteLine("----------------------------------");
                                }
                            } while (Compts[Numc - 1] == null || Compts[Numc1 - 1] == null || Numc == Numc1);
                            if (Compts[Numc - 1] != null || Compts[Numc1 - 1] != null || Numc != Numc1)
                            {
                                Console.Write("Somme:");
                                MAD somme = new MAD(Convert.ToDouble(Console.ReadLine()));
                                Compts[Numc - 1].verser(Compts[Numc1 - 1], somme);
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Erreur nombre totale de Comptes est infusion!!!!!!");
                            Console.WriteLine("Veuille entrez des autres comptes");
                            Console.WriteLine("----------------------------------");
                        }
                        break;
                    case 6:
                        Console.WriteLine("-----------Ajouter Interet-----------");
                        Numc = 0;
                        do
                        {
                            Console.Write("Entre le N° de Compte:");
                            Numc = Convert.ToInt32(Console.ReadLine());
                            if (Numc < cptCo && Compts[Numc - 1].testtypeEpargne() != true)
                            {
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine("Erreur se compte n'est pas de type Epargne!!!!!!");
                                Console.WriteLine("Veuille entrez un autre compte");
                                Console.WriteLine("----------------------------------");
                            }
                            if (Numc > cptCo)
                            {
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine("Se compte n'exist pas!!!!!!");
                                Console.WriteLine("Veuille entrez un autre compte");
                                Console.WriteLine("----------------------------------");
                            }
                        } while (Numc > cptCo || Compts[Numc - 1].testtypeEpargne() != true);
                        if(Compts[Numc -1].testtypeEpargne())
                        {
                            Compts[Numc -1].AjoutInteret();
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        Console.WriteLine("-----------Consulter-----------");

                        Int32 nbrCa = 1;
                        if (cptCo != 1)
                        {
                            do
                            {
                                Console.Write("Entrez le nombre des comptes qui tu veux afficher:");
                                nbrCa = Convert.ToInt32(Console.ReadLine());
                                if (nbrCa > cptCo)
                                {
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("Erreur ce nombre est superior a le nombre total des compts !!!!!!");
                                    Console.WriteLine("Veuille entrez un autre nombre");
                                    Console.WriteLine("----------------------------------");
                                }
                            } while (nbrCa > cptCo);
                        }
                        Console.Clear();
                        if (nbrCa == cptCo)
                        {
                            for (int i = 0; i < nbrCa; i++)
                            {
                                Console.WriteLine("-------------Compte " + (i + 1) + "------------");
                                Compts[i].consulter();
                                Console.WriteLine("--------------------------------");
                            }
                        }
                        else
                        {
                            int y = 0;
                            do
                            {
                                Console.Write("Entrez le num de compte qui tu veux afficher :");
                                Numc = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("----------Compt " + (y + 1) + "---------");
                                Compts[Numc - 1].consulter();
                                Console.WriteLine("--------------------------");
                                y++;
                            } while (y < nbrCa);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
                Console.ReadKey();
        }
    }
}