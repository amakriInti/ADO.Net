using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_1
{
    class Personne
    {
        //private static void Main(string[] args) { }

    }
    enum TypeRequete { Select, Insert, Update, Delete, Scalar }
    class Program
    {
        private static DataSet Ds = new DataSet();
        private static SqlDataAdapter Da = new SqlDataAdapter();

        private static void Main(string[] args)
        {
            //ModeConnecte(TypeRequete.Select, "Select BusinessEntityID, FirstName, LastName from Person.Person");
            //var n = ModeConnecte(TypeRequete.Scalar, "Select Count(*) from Person.Person");

            ModeDeconnecte("Select BusinessEntityID, FirstName, LastName from Person.Person");

            MajBD(1, "Corentin");

            Console.Read();
        }

        private static void MajBD(int id, string nouveauPrenom)
        {
            foreach (DataRow row in Ds.Tables[0].Rows)
            {
                if ((int)row["BusinessEntityID"] == id)
                {
                    row["FirstName"] = nouveauPrenom;
                }
            }
            Da.Update(Ds);
        }

        private static object ModeConnecte(TypeRequete tRequete, string sql)
        {
            // SqlConnection
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2016;Integrated Security=True";
            cnx.Open();

            // SqlCommand
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            switch (tRequete)
            {
                case TypeRequete.Select:
                    SqlDataReader rd = cmd.ExecuteReader();
                    // Affichage
                    while (rd.Read())
                    {
                        Console.WriteLine("{0} - {1} - {2}", rd["BusinessEntityID"], rd["FirstName"], rd["LastName"]);
                    }
                    rd.Close(); // IMPORTANT !
                    break;
                case TypeRequete.Insert:
                case TypeRequete.Update:
                case TypeRequete.Delete:
                    cmd.ExecuteNonQuery();
                    break;
                case TypeRequete.Scalar:
                    return cmd.ExecuteScalar();
                default: throw new Exception("Program.ModeConnecte.42");
            }

            return null;

        }

        private static void ModeDeconnecte(string sql)
        {
            // SqlConnection
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2016;Integrated Security=True";
            cnx.Open();

            // SqlCommand
            var cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            // SqlDataAdapter
            Da.SelectCommand = cmd;
            Da.Fill(Ds);

            // SqlCommandBuilder
            var cb = new SqlCommandBuilder(Da);

            // Affichage

            foreach (DataRow row in Ds.Tables[0].Rows)
            {
                Console.WriteLine("{0} - {1} - {2}", row["BusinessEntityID"], row["FirstName"], row["LastName"]);
            }
        }
    }
}
