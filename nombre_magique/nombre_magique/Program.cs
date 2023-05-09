using System;
using System.Numerics;

namespace nombre_magique
{
    class Program
    {
        static int DemanderNombre(int nombre_Min, int nombre_Max)
        {
            int numberUserInt = nombre_Min-1;

            //reboucler tant que nombre n'est pas valide
            while ((numberUserInt < nombre_Min) || (numberUserInt > nombre_Max))
            {
                //afficher : rentrez un nombre
                Console.Write("Rentrez un nombre entre "+ nombre_Min + " a "+ nombre_Max + " : ");
                // demander un nombre a l'user 
                string numberUser = Console.ReadLine();
                // tester si ce nombre est valide -> Erreur: ce nombre n'est pas valide
                //considérer que 0 est invalide
                try
                {
                    numberUserInt = int.Parse(numberUser);
                    if ((numberUserInt < nombre_Min) || (numberUserInt > nombre_Max))
                    {
                        Console.WriteLine("Erreur: le nombre doit etre entre "+ nombre_Min+ " et "+ nombre_Max+" !");
                    }
                }
                catch
                {
                    Console.WriteLine
                        ("Erreur: ce nombre n'est pas valide");
                }
            }
            //retourner la valeur (int)
            return numberUserInt;
        }

        static void CheckNombreMagique(int numberUser , int nombre_Magique, int nombre_Min, int nombre_Max)
        {
            int life_Of_User = 5;
            //comparer le nombre a nombre_magique
            // 1 - le nombre magique est plus petit
            // 2 - le nombre magique est plus grand
            // 3 - Bravo, vous avez trouvé le nombre magique
            while(life_Of_User >0)
            {
                Console.WriteLine("Il vous reste " + life_Of_User + " vie");
                numberUser = DemanderNombre(nombre_Min, nombre_Max);
                if (numberUser < nombre_Magique)
                {
                   Console.WriteLine("Le nombre magique est plus grand");
                }
                else if (numberUser > nombre_Magique)
                {
                   Console.WriteLine("le nombre magique est plus petit");
                }
                else
                {
                    Console.WriteLine("Bravo, vous avez trouvé le nombre magique");
                    break;
                }
                life_Of_User--;
            }
           if(life_Of_User == 0) 
            {
                Console.WriteLine("Dommage, vous avez perdus le nombre magique etait "+ nombre_Magique);
            }
        }

        static void Main(string[] args)
        {
            // Apprer la fonction DemanderNombre() une seule fois. 
            // 1 - Passer les valeurs min et max en parametres: int min, int max
            // 2 - rentrer un nombre entre 1 et 10 <- dépend de min et de max
            // 3 - Tester si nombreUtilisateur est bien entre min et max
            const int nombre_Max = 20;
            const int nombre_Min = 0;
            Random rand = new Random();
            
            int nombre_Magique = rand.Next(nombre_Min, nombre_Max + 1);
            int numberUser= nombre_Min-1;
        
            CheckNombreMagique(numberUser, nombre_Magique, nombre_Min, nombre_Max);
        }
    }
}