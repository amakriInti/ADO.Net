using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evals.Exo3
{
    class Program
    {
        private static string Requete = @"
        insert into EvalBD.dbo.Personne (Nom, Prenom)
            select LastName, FirstName from AdventureWorks2016.Person.Person;
        insert into EvalBD.dbo.Ville (Nom)
            select distinct city from AdventureWorks2016.Person.Address order by city";
        static void Main(string[] args)
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2016;Integrated Security=True";
            cnx.Open();

            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Requete;

            var n = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} enregistrements ajoutés.", n);
            Console.ReadLine();
        }
    }
}
