using Inti.TDAdo.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inti.TDAdo.Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Gestion des stocks");
                Console.WriteLine("------------------");
                Console.WriteLine("1. Voir les articles");
                Console.WriteLine("2. Voir le stock");
                Console.WriteLine("3. Ajouter un article");
                Console.WriteLine("4. Mettre un article en stock");
                Console.WriteLine("5. Total stock");
                Console.WriteLine("6. Quitter");
                Console.WriteLine("Faîtes un choix (1 à 6)");

                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (Saisir(1, 6))
                {
                    case 1: ArticleAffiche(); break;
                    case 2: StockAffiche(); break;
                    case 3: ArticleAjout(); break;
                    case 4: StockAjout(); break;
                    case 5: StockTotal(); break;
                    case 6: return;
                }
            }
        }
        private static int Saisir(int min, int max)
        {
            while (true)
            {
                var s = Console.ReadLine();
                if (int.TryParse(s, out int i) && i >= min && i <= max) return i;
            }

        }
        private static void ArticleAffiche()
        {
            var liste = BLArticle.GetArticles();
            for(int i=0; i < liste.Count; i += 3)
            {
                Console.WriteLine("{0} {1}\t{2}", liste[i], liste[i + 1], liste[i + 2]);
            }
        }

        private static void StockTotal()
        {
            throw new NotImplementedException();
        }

        private static void StockAjout()
        {
            throw new NotImplementedException();
        }

        private static void ArticleAjout()
        {
            throw new NotImplementedException();
        }

        private static void StockAffiche()
        {
            throw new NotImplementedException();
        }


    }
}
