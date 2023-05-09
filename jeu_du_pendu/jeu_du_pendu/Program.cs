using System;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using AsciiArt;
using System.Runtime.CompilerServices;

namespace jeu_du_pendu
{
    //internal class outils
    class Program
    {

        static void AfficherMot(string mot, List<char>lettres) 
        {
            //int numberCharMot = mot.Length;

            string displayMot = "";
            for (int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if (lettres.Contains(lettre))
                {
                    displayMot +=lettre+" ";
                }
                else
                {
                    displayMot += " _ ";

                }

            }
            Console.WriteLine(displayMot);
        }

        static char DemanderUneLettre(string message = "Rendrez une lettre : ")
        {
            //Rendrez une lettre
            //Erreur: Vous devez rentrer une seule lettre
            // return -> majuscule(ToUpper);
            while (true)
            {
               
                Console.Write(message);
                string Lettre = Console.ReadLine();
                Lettre = Lettre.ToUpper();
                if(Lettre.Length ==1) 
                {
                    char LettreUser = Lettre[0];
                    return LettreUser;
                }
                else
                {
                     Console.WriteLine("Erreur: Vous devez rentrer une lettre"); 
                }  
            }
        }
        static void DevinerMot(string mot) 
        {
            // - - - -
            // E- - E - -
            //AfficherMot()
            //boucler (true)
            // afficherMot()
            // Demanderunelettre
            // -> "cette lettre est dans le mot" -> list<char> add()
            // -> "Cette lettre n'est pas dans le mot"
            var essaiLettre= new List<char>();
            var lettreIncorrect= new List<char>();
            const int NB_VIES = 6;
            int vieRestantes = NB_VIES;
            //int bonneResponse = 0;
            while (vieRestantes > 0)
            {
                Console.WriteLine(Ascii.PENDU[NB_VIES - vieRestantes]);
                Console.WriteLine();

                AfficherMot(mot, essaiLettre);
                Console.WriteLine();

                char CharUser=DemanderUneLettre();
                Console.Clear();

                if (mot.Contains(CharUser))
                {
                    Console.WriteLine("cette lettre est dans le mot");
                    essaiLettre.Add(CharUser);
                    //bonneResponse++;
                    if (ToutesLettresDevinees(mot, essaiLettre))
                    {
                        AfficherMot(mot, essaiLettre);
                        Console.WriteLine();
                        Console.WriteLine("Bravo vous avez gagné");
                        Console.WriteLine(Ascii.PENDU[NB_VIES - vieRestantes]);
                        break;
                    }
                    //if (bonneResponse == mot.Length-1)
                    //{
                    //    Console.WriteLine("Bravo vous avez gagné");
                    //}
                }
                else
                {
                    if (!lettreIncorrect.Contains(CharUser))
                    {
                        vieRestantes--;
                        lettreIncorrect.Add(CharUser);
                        Console.WriteLine("Il vous reste " + vieRestantes + " vie");
                    }
                    else
                    {
                        Console.WriteLine("Vous avez dèjà mis cette lettre");
                    }
                }

                if (lettreIncorrect.Count > 0)
                {
                    Console.WriteLine("Cette lettre n'est pas dans le mot: " + String.Join(",", lettreIncorrect));
                }

                if (vieRestantes == 0)
                {
                    Console.WriteLine("Dommage vous avez perdus le mot a trouvé etait : " + mot);
                    Console.WriteLine(Ascii.PENDU[NB_VIES - vieRestantes]);
                    break;
                }
                Console.WriteLine();
            }
            //List<char> lettres = new List<char>();
           // lettres += char lettreUser;
            //AfficherMot(mot, new List<char> { 'E', 'L','Z'});
            //demanderUneLettre
        }

        static string[] ChargerLesMots(string nomsFichier)
        {
            try
            {
                return File.ReadAllLines(nomsFichier);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur du fichier : "+ex.Message);
            }
            return null;
        }

        static bool ToutesLettresDevinees(string mot,List<char> lettres) 
        {
            foreach(var lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }
            if(mot.Length == 0)
            {
                return true;
            }
            return false;
        }
        static bool DemanderDeRejoueur()
        {
            //Console.Write("Voulez-vous rejouer (o/n) : ");
            string retryPlaye = DemanderUneLettre("Voulez-vous rejouer (o/n) : ").ToString();
            if (retryPlaye == "O")
            {
                return true;
            }
            else if (retryPlaye == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Erreur : Vous devez répondre avec o ou n");
                return DemanderDeRejoueur();
            }
        }
        static void Main(string[] args)
        {
            var mots = ChargerLesMots("mots.txt");
            if ((mots==null) || (mots.Length==0))
            {
                Console.WriteLine("La liste de mots est vide");
            }
            else
            {
                //version pour la partie retry
                while(true)
                {
                //end sevtion de version partie retry
                    Random random = new Random();
                    int numberMot = random.Next(0, mots.Length);
                    string mot = mots[numberMot].Trim().ToUpper();
                    //AfficherMot(mot, new List<char> { });
                    //char lettreUser=DemanderUneLettre();
                    DevinerMot(mot);
                    if (!DemanderDeRejoueur())
                    {
                        Console.Clear();
                        break;
                    }
                    Console.Clear();
                }
              
            }

            //Voulez-vous rejouer (O/N)
            //Console.Write("Voulez-vous rejouer (O/N)");
            //string retryPlaye= Console.ReadLine().Trim().ToUpper();
           /*Old version
            * if (retryPlaye == "O")
            {
                Console.Clear();
                Main(args);
            }
            else
            {
                Console.Clear();

            }     */
           
        }
    }
}