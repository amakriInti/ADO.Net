using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evals.Exo1
{
    class Program
    {
        private static string Requete = @"SELECT Production.ProductCategory.Name nom, COUNT(Production.Product.ProductID) n
                                    FROM Production.Product INNER JOIN
                                             Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID INNER JOIN
                                             Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID
                                    GROUP BY Production.ProductCategory.Name
                                    ORDER BY Production.ProductCategory.Name";
        static void Main(string[] args)
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2016;Integrated Security=True";
            cnx.Open();

            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Requete;

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine("{0} : {1}", rd["nom"], rd["n"]);
            }
            rd.Close();

            Console.ReadLine();
        }
    }
}
