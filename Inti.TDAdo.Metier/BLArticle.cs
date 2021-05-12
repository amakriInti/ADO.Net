using Inti.TDAdo.Donnees;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inti.TDAdo.Metier
{
    public class BLArticle
    {
        public static ArrayList GetArticles()
        {
            return Repository.GetArticles();
        }
        public static ArrayList GetStocks()
        {
            return Repository.GetStocks();
        }

        public static bool InsertArticle(string nom, decimal prix)
        {
            return Repository.InsertArticle(nom, prix);
        }

        public static bool InsertStock(Guid id, int qte)
        {
            return Repository.InsertStock(id, qte);
        }
    }
}
