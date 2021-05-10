using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo1_Ameliore
{
    interface IDal
    {
        Guid AjoutArticle(string nom, int prix);
        bool AjoutStock(Guid article, int qte);
        bool SupprimeArticle(Guid id);
    }
    class Dal : IDal
    {
        public bool Connecte = false;
        private SqlCommand Cmd = null;

        public Dal(string connectionString)
        {
            // SqlConnection
            var cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            try
            {
                cnx.Open();
                Connecte = true;
            }
            catch (Exception)
            {

            }
            Cmd = new SqlCommand();
            Cmd.Connection = cnx;
            Cmd.CommandType = CommandType.StoredProcedure;

        }

        public Guid AjoutArticle(string nom, int prix)
        {
            var id = Guid.NewGuid();

            Cmd.CommandText = "Article_Insert";
            Cmd.Parameters.Clear();
            Cmd.Parameters.Add(new SqlParameter("Id", id));
            Cmd.Parameters.Add(new SqlParameter("nom", nom));
            Cmd.Parameters.Add(new SqlParameter("prix", prix));
            var retour = Cmd.ExecuteNonQuery();
            if (retour == 1) return id;
            return default;
        }
        public bool AjoutStock(Guid article, int qte)
        {
            Cmd.CommandText = "Stock_Insert";
            Cmd.Parameters.Clear();
            Cmd.Parameters.Add(new SqlParameter("article", article));
            Cmd.Parameters.Add(new SqlParameter("qte", qte));
            return Cmd.ExecuteNonQuery() == 1;
        }

        public bool SupprimeArticle(Guid id)
        {
            Cmd.CommandText = "Article_Delete";
            Cmd.Parameters.Clear();
            Cmd.Parameters.Add(new SqlParameter("id", id));
            return Cmd.ExecuteNonQuery() == 1;
        }
    }
    class FakeDal : IDal
    {
        private List<Article> Articles = new List<Article>();
        private List<StockItem> Stock = new List<StockItem>();
        public FakeDal(string connectionString)
        {
        }
        public Guid AjoutArticle(string nom, int prix)
        {
            var id = Guid.NewGuid();
            Articles.Add(new Article { Id = id, Nom = nom, Prix = prix });
            return id;
        }

        public bool AjoutStock(Guid article, int qte)
        {
            var id = Guid.NewGuid();
            Stock.Add(new StockItem { Id = id, Article = article, Qte = qte });
            return true;
        }

        public bool SupprimeArticle(Guid id)
        {
            var articleASupprimer = Articles.Where(a => a.Id == id).FirstOrDefault();
            if (articleASupprimer == null) return false;

            var articleEnStock = Stock.Where(s => s.Article == id).FirstOrDefault();
            if (articleEnStock != null) return false;

            return Articles.Remove(articleASupprimer);
        }
    }
    class Article
    {
        public Guid Id;
        public string Nom;
        public decimal Prix;
    }
    class StockItem
    {
        public Guid Id;
        public Guid Article;
        public int Qte;
    }
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
