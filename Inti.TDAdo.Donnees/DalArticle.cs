using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inti.TDAdo.Donnees
{
    public static class Repository
    {
        private static ExoArticleContext Context = new ExoArticleContext();
        public static ArrayList GetArticles()
        {
            ArrayList liste = new ArrayList();
            foreach (var item in Context.Articles)
            {
                liste.Add(item.Id);
                liste.Add(item.Nom);
                liste.Add(item.Prix);
            }
            return liste;
        }

        public static bool InsertArticle(string nom, decimal prix)
        {
            var newItem = new Article { Id = Guid.NewGuid(), Nom = nom, Prix = prix };
            Context.Articles.Add(newItem);
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                Context.Articles.Remove(newItem);
                return false;
            }
        }

        public static bool InsertStock(Guid idArticle, int qte)
        {
            var newItem = new Stock { Id = Guid.NewGuid(), Article = idArticle, Qte = qte };
            Context.Stocks.Add(newItem);
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                Context.Stocks.Remove(newItem);
                return false;
            }
        }
        public static ArrayList GetStocks()
        {
            ArrayList liste = new ArrayList();
            foreach (var item in Context.Stocks)
            {
                liste.Add(item.Id);
                liste.Add(item.Article1.Nom);
                liste.Add(item.Qte);
            }
            return liste;
        }
    }
}
