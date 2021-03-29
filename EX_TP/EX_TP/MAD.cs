using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class MAD
    {
        private double valeur;
        public MAD(double V)
        {
            this.valeur = V;
        }
        
        public static MAD operator +(MAD s1, MAD s2)
        {
            return new MAD(s1.valeur + s2.valeur);
        }
        public static MAD operator -(MAD s1, MAD s2)
        {
            return new MAD(s1.valeur - s2.valeur);
        }
        public static bool operator >(MAD s1, MAD s2)
        {
            return (s1.valeur > s2.valeur);
        }
        public static bool operator <(MAD s1, MAD s2)
        {
            return (s1.valeur < s2.valeur);
        }
        public static bool operator >(MAD s1, double s)
        {
            if (s1.valeur > s)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(MAD s1, double s)
        {
            if (s1.valeur < s)
            {
                return true;
            }
            return false;
        }
        public static MAD operator *(MAD s1, MAD s2)
        {
            return new MAD(s1.valeur * s2.valeur);
        }

        public string afficherMAD()
        {
            return this.valeur + " MAD";
        }


    }
}