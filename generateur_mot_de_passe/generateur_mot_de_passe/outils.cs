using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS
{
    //internal class outils
    static class outils
    {
        public static int DemanderNombrePositifNonNul(string question)
        {
            // >0
            // int.MaxValue
            /*int longueurMotDePasse = DemanderNombre(question);
            if (longueurMotDePasse < 0 )
            {
                Console.WriteLine("Erreur: Merci de mettre une valeur supérieur à 0");
                return DemanderNombrePositifNonNul(question);
            }
            else 
            {
                return longueurMotDePasse; 
            }*/
            return DemanderNombreEntre(question, 1, int.MaxValue);

        }
        public static int DemanderNombreEntre(string question, int min, int max, string messageErreurPersonnal = null)
        {
            // fonction recursive
            int longueurMotDePasse = DemanderNombre(question);
            if (longueurMotDePasse < min || longueurMotDePasse > max)
            {
                if(messageErreurPersonnal == null)
                {
                    Console.WriteLine("Erreur: Merci de mettre une valeur entre " + min + " et " + max);
                    return DemanderNombreEntre(question, min, max);
                }
                else
                {
                    Console.WriteLine(messageErreurPersonnal);
                    return DemanderNombreEntre(question, min, max);
                }
            }
            else
            {
                return longueurMotDePasse;
            }

            //fonction non recursive
            /*while (true)
            {
                // nombre = DemanderNombre(questyion)
                int longueurMotDePasse = DemanderNombre(question);
                if (longueurMotDePasse < min || longueurMotDePasse > max)
                {
                    Console.WriteLine("Erreur: Merci de mettre une valeur entre " + min +" et "+ max);
                }
                else { return longueurMotDePasse; }
                // si le nombre est bien entre min et max-> Erreur/boucler
            }*/

        }
        static int DemanderNombre(string question)
        {
            //boucler tant qu'on a pas recu une réponse valide (qui contient que des chiffres
            while (true)
            {
                //poser la question 
                Console.WriteLine(question);
                //récuperer la réponse
                string lPassword = Console.ReadLine();
                //gérer l'errreur de conversion
                try
                {
                    //convertir
                    int lPasswordInt = int.Parse(lPassword);
                    return lPasswordInt;
                }
                catch { Console.WriteLine("Merci de mettre une valeur décimal"); }
            }
        }
    }
}
