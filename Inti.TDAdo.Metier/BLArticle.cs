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
    }
}
