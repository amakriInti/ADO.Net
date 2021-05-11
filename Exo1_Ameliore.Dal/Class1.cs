using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo1_Ameliore.Data
{
    public interface IDal
    {
        Guid AjoutArticle(string nom, int prix);
        bool AjoutStock(Guid article, int qte);
        bool SupprimeArticle(Guid id);
    }
    public class Dal : IDal
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
    public class FakeDal : IDal
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
    public class Article
    {
        public Guid Id;
        public string Nom;
        public decimal Prix;
    }
    public class StockItem
    {
        public Guid Id;
        public Guid Article;
        public int Qte;
    }
}
