using System;

namespace jeu_de_math
{
    class Program
    {
        enum e_Operateur
        {
            ADDITION=1,
            SOUSTRACTION=2,
            MULTIPLICATION=3
        }
        static bool PoserQuestion(int nombre_Min, int nombre_Max)
        {
            Random rand = new Random();
            int a = rand.Next(nombre_Min, nombre_Max + 1);
            //string aString= a.ToString();
            int b = rand.Next(nombre_Min, nombre_Max + 1);
            //string bString = b.ToString();
            //bool responseValide = false;
            // pour forcer le changement de type mettre devant le resultat (e_Operateur) dans notre exemple
            e_Operateur o = (e_Operateur)rand.Next(1, 4);
            Console.WriteLine(o);
            while (true)
            {
                int resultatAttendu;

                switch (o)
                {
                    case e_Operateur.ADDITION:
                        Console.Write(a + " + " + b + " = ");
                        resultatAttendu = a+b;
                        break;
                    case e_Operateur.SOUSTRACTION:
                        Console.Write(a + " - " + b + " = ");
                        resultatAttendu = a - b;
                        break;
                    case e_Operateur.MULTIPLICATION:
                        Console.Write(a + " * " + b + " = ");
                        resultatAttendu = a * b;
                        break;
                    default:
                        Console.WriteLine("Erreur:opérateur inconnu");
                        return false;
                }
                
                /*if (o == e_Operateur.ADDITION)
                {
                    Console.Write(a + " + " + b + " = ");
                    resultatAttendu = a + b;
                }
                else if (o == e_Operateur.SOUSTRACTION)
                {
                    Console.Write(a + " - " + b + " = ");
                    resultatAttendu = a - b;
                }
                else if (o == e_Operateur.MULTIPLICATION) 
                {
                    Console.Write(a + " * " + b + " = ");
                    resultatAttendu = a * b;
                }
                else 
                {
                    Console.WriteLine("Erreur:opérateur inconnu");
                    return false;
                }
                */

                string response = Console.ReadLine();
                try
                {
                    int responseInt = int.Parse(response);
                    if (resultatAttendu == responseInt)
                    {
                        return true;
                    }
                        return false;
                    //responseValide = true;
                    //or break
                    //break;
                }
                catch
                {
                    Console.WriteLine("Erreur: vous devez rentrer un nombre");
                }
            }
            
        }
        static void Main(string[] args)
        {
            const int nombre_Min = 1;
            const int nombre_Max = 10;
            const int nb_Question = 4;
            int points = 0;
            for (int i = 0; i < nb_Question; i++)
            {
                // Question n°1 /3 
                Console.WriteLine("Vous etez a la question n°"+(i+1)+" sur "+nb_Question);
                bool resultatReponse = PoserQuestion(nombre_Min, nombre_Max);
                if (resultatReponse)
                {
                    Console.WriteLine("Correct");
                    points++;
                }
                else
                {
                    Console.WriteLine("Faux");
                }
            }
            Console.WriteLine("Vous avez un score de " + points + "/" + nb_Question);
            int moyenne = nb_Question / 2;
            if (points== nb_Question)
            {
                Console.WriteLine("Excellent");
            }
            else if (points == 0)
            {
                Console.WriteLine("Révisez vos maths");
            }
            else if(points > moyenne) 
            {
                Console.WriteLine("Pas mal");
             }
            else
            {
                Console.WriteLine("Peut mieux faire");
            }
        }
    }
}