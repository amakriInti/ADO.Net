using System;

namespace Exo1_Ameliore
{
    class Program
    {
        static void Main(string[] args)
        {
            IDal dal = null;
            if (Console.ReadLine().ToUpper().StartsWith("F"))
                dal = new FakeDal(@"Data Source=.\SQLEXPRESS;Initial Catalog=Exo_Article;Integrated Security=True");
            else
                dal = new Dal(@"Data Source=.\SQLEXPRESS;Initial Catalog=Exo_Article;Integrated Security=True");

            // EXEC Article_Insert 'Clavier', 15
            var idArticle1 = dal.AjoutArticle("Clavier", 15);
            if (idArticle1 != default) Console.WriteLine("Article Clavier inséré");

            // EXEC Article_Insert 'Souris', 10
            var idArticle2 = dal.AjoutArticle("Souris", 10);
            if (idArticle2 != default) Console.WriteLine("Article Souris inséré");

            // EXEC Stock_Insert '...............', 200 
            if (dal.AjoutStock(idArticle1, 200)) Console.WriteLine("Stock 200 Claviers inséré");

            // Exec Article_Delete '...........'
            if (dal.SupprimeArticle(idArticle1)) Console.WriteLine("Article Clavier supprimé");

            Console.Read();
        }

    }
}
