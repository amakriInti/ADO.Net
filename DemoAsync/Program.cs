using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAsync
{
    //delegate int GoDelegate(string s);
    class Program
    {
        static void Main(string[] args)
        {
            // Partie 1
            var c1 = new Compteur("A", 1, 3, 1, ConsoleColor.Cyan);
            var c2 = new Compteur("B", 1, 5, 3, ConsoleColor.Red);
            var d1 = new Func<string, int>(c1.Go);
            var d2 = new Func<string, int>(c2.Go);

            d1.BeginInvoke("testA", new AsyncCallback(c1.Fin), "Super");
            d2.Invoke("testB");
            Console.WriteLine("B a fini");

            // Partie 2

            Console.ReadLine();
        }
    }
    class Compteur
    {
        string Nom;
        int Depart;
        int Arrivee;
        int Duree;
        ConsoleColor Couleur;
        public Compteur(string nom, int depart, int arrivee, int duree, ConsoleColor couleur)
        {
            Nom = nom;
            Depart = depart;
            Arrivee = arrivee;
            Duree = duree;
            Couleur = couleur;
        }
        public int Go(string message)
        {
            for (int i = Depart; i <= Arrivee; i++)
            {
                Console.ForegroundColor = Couleur;
                Console.WriteLine("{0}: {1} {2}", Nom, i, message);
                Thread.Sleep(Duree * 1000);
            }
            return 0;
        }
        public void Fin(IAsyncResult r)
        {
            var message = (string) r.AsyncState;
            Console.WriteLine("Fin de {0} : {1}", Nom, message);
        }
    }
}
