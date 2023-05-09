using System;
using FormationCS;

namespace generateur_mot_de_passe
{
    class Program
    {
      enum e_Operateur
        {
            ALPHABETMIN=1,
            ALPHABETMAJ=2,
            ALPHABETSTRINT=3,
            ALPHABETALL =4
        }
        static void Main(string[] args)
        {
            const int nb_MOTS_DE_PASS = 10;
            int min = 1;
            int max=20;
            // 1 - Demander la longueur du mot de passe (DemanderNombre) int longueur_mot_de_passe =...
            //int longueurMotDePasse = DemanderNombre("Longueur du mot de passe :");
            int longueurPassword = outils.DemanderNombrePositifNonNul("Longueur du mot de passe :");
            e_Operateur selectTypePassword = (e_Operateur)outils.DemanderNombreEntre("Vous voulez un mot de passe avec : " +
                "\n 1 - Uniquement des caracteres en minuscule " +
                "\n 2 - Minuscultes et majuscules " +
                "\n 3 - caractères et des chiffres" +
                "\n 4- La total: salade tomate oignon "+ 
                "\n Votre choix :",1,4);

            string alphabetmin = "abcdefgijklmnopqrstuvwxyz";
            string alphabetUp = alphabetmin.ToUpper();
            string chiffres = "123456789";
            string caracteresSpeciaux = "!$?+-";
            string alphabet="";
            switch (selectTypePassword)
            {
                case e_Operateur.ALPHABETMIN:
                     alphabet = alphabetmin;
                    break;
                case e_Operateur.ALPHABETMAJ:
                     alphabet = alphabetmin + alphabetUp;
                    break;
                case e_Operateur.ALPHABETSTRINT:
                     alphabet = alphabetmin + alphabetUp + chiffres;
                    break;
                case e_Operateur.ALPHABETALL:
                     alphabet = alphabetmin + alphabetUp + chiffres + caracteresSpeciaux;
                    break;
                default:
                    break;
            }
          
            int longueurAlphabet = alphabet.Length;
            
            string motDePasse = "";
            //Console.WriteLine(alphabet);
            Random rand= new Random();
            //boucler sur longueurMotDePasse
            for (int I = 0; I < nb_MOTS_DE_PASS; I++)
            {
                motDePasse = "";
                for (int i = 0; i < longueurPassword; i++)
                {
                    int index = rand.Next(0, longueurAlphabet);
                    //Console.WriteLine(alphabet[index]);

                    motDePasse += alphabet[index];
                }
                Console.WriteLine("Mot de passe créer est : " + motDePasse);              
            }
        }
    }
}