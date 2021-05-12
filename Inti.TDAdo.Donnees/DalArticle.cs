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
        private static  ExoArticleContext Context = new ExoArticleContext();
        public static ArrayList GetArticles()
        {
            ArrayList liste = new ArrayList();
            foreach(var item in Context.Articles)
            {
                liste.Add(item.Id);
                liste.Add(item.Nom);
                liste.Add(item.Prix);
            }
            return liste;
        }
    }
}
