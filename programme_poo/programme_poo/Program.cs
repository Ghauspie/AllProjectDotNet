using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace programme_poo
{
    // 1 - Créer une classe enfant (Etudiant)
    // 2 - Constructeur: nom et age; infoEtudes = null
    // 3 - main -> Créer un enfant "Sophie", 7 *-> afficher

    // 4- ClasseEcole "CP"
    // 5 - Afficher Enfant en classe de CP
    // 6 - Afficher ProfesseurPrincipal
    class Enfant :Etudiant
    {
        
        string classeEcole;
        //dictionnary note
        Dictionary<string,float> notes;
        public Enfant(string nom , int age, string classeEcole, Dictionary<string, float> notes= null) : base(nom, age, null) 
        { 
            this.classeEcole = classeEcole;
            this.notes = notes;
        }

        public override void Afficher()
        {
            //methode une
            /*base.Afficher();
            Console.WriteLine("Enfant en classe de " + classeEcole);*/
            //methode deux 
            AfficherNomEtAge();
            Console.WriteLine(" Enfant en classe de " + classeEcole);
            if((notes!= null) && (notes.Count>0))
            {
                Console.WriteLine(" Notes moyennes :");
                foreach (var note in notes)
                {
                    Console.WriteLine("             " + note.Key + " : " + note.Value + "/10");
                }
            }
          //          "Notes moyennes"
            // foreach  "   maths : 5/10"
            AfficherProfesseurPrincipal();
        }
    }

    // Maths :5 /10
    // Geo :8.5/10
    // clef:string/valuer : float
    // Dictionary<string, float{{"maths",5f}
    class Etudiant : Personne
    {

        string infoEtudes;
        public Personne professeurPrincipal;
        public Etudiant(string nom, int age,string infoEtudes,  string emploi = null) : base(nom, age) //Personne professeurPrincipal = null
        { 
            this.infoEtudes = infoEtudes;
            //this.professeurPrincipal = professeurPrincipal;
        }

        //pour surcharger une fonction
        public override void Afficher()
        {

            /* Console.WriteLine(" nom: " + nom);
             Console.WriteLine(" Age: " + age + " ans");
             Console.WriteLine(" Etudiant en : " + infoEtudes);*/
            AfficherNomEtAge();
            if (infoEtudes != null)
            {
                Console.WriteLine(" Etudiant en  " + infoEtudes);
            }
                AfficherProfesseurPrincipal();
        }

        protected void AfficherProfesseurPrincipal()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine(" Sont professeur principal est : ");
                professeurPrincipal.Afficher();
            }
            else
            {
                Console.WriteLine("Il n'a pas de professeur ");

            }
           
        }

    }
    class Personne
    {
        static int nombreDePersonnes = 0;
        //private string nom;
        //Methode propriété pour nom
        // pour initialiser la valeur uniquement lors de la creation de l'objet "init" et sans le set
        //public string nom { get ; set; }
        protected string nom;
        // exemple pour mettre des valeur directement depuis la creartion de la var
        //int _age;
        /*public int age {
            get {
                return _age;
            }
            set {
                if (value >= 0) {
                    {
                        _age = value;
                    }
                }
            } 
        }*/
        protected int age;
        protected string emploi;
        int numeroPersonne;


        //accesseurs
        /*public string GetNom()
        {
            return nom;
        }*/

        /*public Personne()
        {
            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;
        }*/

        /*public Personne(string nom, int age) : this(nom, age, "(non spécifié)")
        {


        }*/
        //:this() sert a appeller le constructor sans parametre
        public Personne(string nom, int age,string emploi = null) //: this()
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;
            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;
        }


        public virtual void Afficher()
        {
            /*Console.WriteLine("Personne: " + numeroPersonne);
            Console.WriteLine(" nom: " + nom);
            Console.WriteLine(" Age: " + age + " ans");*/
            AfficherNomEtAge();

            if (emploi == null)
            {
                
                Console.WriteLine(" Emploi: non spécifié ");
            }
            else
            {
                Console.WriteLine(" Emploi: " + emploi);
            }
        }

        public static void AfficherNombreDePersonnes()
        {
            Console.WriteLine("Nombre total de personnes:" + Personne.nombreDePersonnes);
          
        }

        // AfficherNomEtAge
        protected void AfficherNomEtAge()
        {
            Console.WriteLine("Personne: " + numeroPersonne);
            Console.WriteLine(" nom: " + nom);
            Console.WriteLine(" Age: " + age + " ans");
        }
    }
    class Program
    {
        /*static void AfficherInfosPersonne(string nom,int age, string emploi)
        {
            Console.WriteLine("nom: "+ nom);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Emploi: " + emploi);
        }*/

        static void Main(string[] args) 
        {
            //nom,age,emploi
            /* var noms = new List<string>() { "Paul", "Jacques","Timothé"};
             var ages = new List<int>() { 30, 35, 1 };
             var emplois = new List<string>() { "Développeur", "Professeur", "Sans emploi" };

             for (int i = 0; i < noms.Count; i++)
             {
                 AfficherInfosPersonne(noms[i], ages[i], emplois[i]);
             }*/
            //Personne personne1 = new Personne("Paul",35,"Développeur");
            //personne1.Afficher();
            //personne1.nom="lol";
            //personne1.Afficher();

            // Personne personne2 = new Personne("Timothé",1,"Enfant");
            // personne2.Afficher();

            // exemple d'initialisation pour un constructor vide
            // var personne1= new Personne { nom ="Paul" };
            var personnes = new List<Personne> {
                new Personne("Guillaume", 35, "Développeur"),
                //new Personne { nom ="Paul", age = 35, emploi ="Développeur" },
                new Personne("Paul",35,"Professeur" ),
                new Personne("Timothé", 1, "Enfant"),
                new Etudiant("David", 20,"Informatique"),
                new Enfant("Juliette", 8, "CP")
            };
            //var professeur = new Personne("Paul", 35, "Professeur");
            //var personnes = new List<Personne> { new Personne("Paul", 35, "Développeur"), new Personne("Paula", 35) };
            //personnes =personnes.OrderBy(p => p.nom).ToList();
            foreach (var person in personnes)
            {
                person.Afficher();
            };
             Personne.AfficherNombreDePersonnes();
            var professeurPrincipal = new Personne("Paul", 38, "Professeur");
            //var etudiant=new Etudiant() { nom ="michel", age=18,emploi="RSA"};
            /*var etudiant = new Etudiant("michel", 18, "Ecole d'ingenieur"); // Ecole d'ingenieur
            etudiant.professeurPrincipal = new Personne("Paul", 38, "Professeur");*/
            //ajouter le professeur dans l'etape d'initialisation de l'etudiant voici la methode
            var etudiant = new Etudiant("michel", 18, "Ecole d'ingenieur")
            {
                //professeurPrincipal = new Personne("Paul", 38, "Professeur")
                professeurPrincipal= professeurPrincipal
            };
            etudiant.Afficher();

            var enfant = new Enfant("Sophie", 7, "CP", new Dictionary < string, float>{ 
                { "maths", 5f }, { "Geo", 8.5f }, {"Dictée",3.3f}
            }) 
            { professeurPrincipal = new Personne("Pierre", 24, "Professeur des ecoles") };
            enfant.Afficher();
            //Console.WriteLine("Nombre total de personnes:" + Personne.nombreDePersonnes);AfficherNombreDePersonnes
        }
    }
}