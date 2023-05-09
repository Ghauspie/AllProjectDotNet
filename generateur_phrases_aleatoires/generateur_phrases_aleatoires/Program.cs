using System;

namespace generateur_phrases_aleatoirs
{
    class Program
    {
        static string ObtenirElementAleatoire(string[] t)
        {
            Random rnd = new Random();
            int numberSelect=rnd.Next(t.Length);
            //Console.WriteLine(numberSelect);
            //Console.WriteLine(t[numberSelect]);
            return t[numberSelect];

        }
        static void Main(string[] args)
        {
            // sujet verbe complement
            var sujets = new string[] { 
                "un lapin", 
                "timothé", 
                "Un chien", 
                "un dragon", 
                "un chevalier", 
                "olaf" 
            };

            var verbes = new string[] { 
                "combat",
                "mange",
                "écrasse",
                "détruit",
                "joue avec",
                "attrape",
                "regarder",
                "avale",
                "se bat avec",
                "s'accroche à" 
            };

            var complements = new string[] {
                "un arbre",
                "un livre",
                "la lune",
                "un dragon",
                "le soleil",
                "un serpent",
                "une carte",
                "une girafe",
                "le ciel",
                "une piscine",
                "un gateau",
                "une souris",
                "un crapaud" 
            };

            // nb_phrases
            int nb_Phrases = 100;
            List<string> ListPhrases = new List<string>();
            int nb_Doublon = 0;
            //or other soluce
            //while(ListPhrases.Count < nb_Phrases
            for (int i = 0; i < nb_Phrases; i++)
            {
                string sujetSelect = ObtenirElementAleatoire(sujets);
                string verbeSelect = ObtenirElementAleatoire(verbes);
                string complementsSelect = ObtenirElementAleatoire(complements);
                string phrase = sujetSelect + " " + verbeSelect + " " + complementsSelect;
                phrase=phrase.Replace("à le", "au ");
                if(ListPhrases.Contains(phrase))
                {
                   nb_Doublon++;
                   nb_Phrases++;
                }
                else
                {
                    ListPhrases.Add(phrase);
                    Console.WriteLine(i + ": " + phrase);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Il y a " + nb_Doublon + " doublon qu'ils ont était évité ");
            Console.WriteLine("Nombre de phrases uniques : " + ListPhrases.Count);

        }
    }
}