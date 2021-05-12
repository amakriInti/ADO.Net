using Inti.TDAdo.Donnees;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inti.TDAdo.Metier
{
    public static class BLArticle
    {
        private static ArrayList LesArticles = new ArrayList();
        private static ArrayList LesStocks = new ArrayList();
        public static void Init()
        {
            LesArticles = Repository.GetArticles();
            LesStocks = Repository.GetStocks();
        }
        public static ArrayList GetArticles()
        {
            return LesArticles;
        }
        public static ArrayList GetStocks()
        {
            return LesStocks;
        }

        public static bool InsertArticle(string nom, decimal prix)
        {
            return Repository.InsertArticle(nom, prix);
        }

        public static bool InsertStock(Guid id, int qte)
        {
            return Repository.InsertStock(id, qte);
        }

        public static int GetStockTotal()
        {
            int total = 0;
            for(int i=0; i < LesStocks.Count; i += 3)
            {
                total += (int)LesStocks[i + 2];
            }
            return total;
        }
    }
}
