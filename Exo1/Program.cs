using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo1
{
    class Program
    {
        static void Main(string[] args)
        {
            // SqlConnection
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Exo_Article;Integrated Security=True";
            cnx.Open();

            // EXEC Article_Insert 'Clavier', 15
            var idArticle1 = Guid.NewGuid();
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Article_Insert";
            cmd.Parameters.Add(new SqlParameter("Id", idArticle1));
            cmd.Parameters.Add(new SqlParameter("nom", "Clavier"));
            cmd.Parameters.Add(new SqlParameter("prix", 15));
            var retour = cmd.ExecuteNonQuery();
            if (retour == 1) Console.WriteLine("Article Clavier inséré");

            // EXEC Article_Insert 'Souris', 10
            var idArticle2 = Guid.NewGuid();
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("Id", idArticle2));
            cmd.Parameters.Add(new SqlParameter("nom", "Souris"));
            cmd.Parameters.Add(new SqlParameter("prix", 10));
            retour = cmd.ExecuteNonQuery();
            if (retour == 1) Console.WriteLine("Article Souris inséré");
             
            // EXEC Stock_Insert '89146476-06E9-4D39-9628-D30CC9136B11', 200 
            cmd.Parameters.Clear();
            cmd.CommandText = "Stock_Insert";
            cmd.Parameters.Add(new SqlParameter("article", idArticle1));
            cmd.Parameters.Add(new SqlParameter("qte", 200));
            retour = cmd.ExecuteNonQuery();
            if (retour == 1) Console.WriteLine("Stock Article quantité 200 inséré");

            // Exec Article_Delete '1DBBDF4B-5B59-4EA7-A69D-84F7F62E0B26'
            cmd.Parameters.Clear();
            cmd.CommandText = "Article_Delete";
            cmd.Parameters.Add(new SqlParameter("id", idArticle2));
            retour = cmd.ExecuteNonQuery();
            if (retour == 1) Console.WriteLine("Article Clavier supprimé");

            Console.Read();
        }
    }
}
