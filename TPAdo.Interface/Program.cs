using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAdo.Interface
{
    public enum EntiteEnum
    {
        Employe = 1, Chambre = 2, Intervention = 3, InterventionDetail = 4, Message = 5, InterventionAjouter = 6,
        None = 0
    }
    enum TypeCommande { Insert}
    class Program
    {
        //static void Main(string[] args)
        //{
        //    // 0. Mode connecté.
        //    var data = new DataModeDeconnecte();
        //    // 1. Nouvelle gouvernante affectée à l'hôtel
        //    data.ModeDeconnecte(TypeCommande.Insert, $"INSERT Utilisateur () values()");

        //    // 2. Nouveau réceptionniste de l'hôtel

        //    // 3. Nouvel Hôtel

        //    // 4. 2 nouvelles chambres 101 102 dans l'hôtel à l'étage 1

        //    // 5. 2 femmes de chambre A et B affectées à l'hôtel

        //    // 6. 1 intervention : A fait la 101 - B fait la 102 

        //    // 7. 

        //    Console.ReadLine();
        //}
        //class DataModeDeconnecte
        //{
        //    internal void ModeDeconnecte(TypeCommande tCommande, string requete)
        //    {
        //        var cnx = new SqlConnection();
        //        var cmd = new SqlCommand();
        //        // ...
        //        switch (tCommande)
        //        {
        //            case TypeCommande.Insert: cmd.ExecuteNonQuery(); break;
        //        }
        //    }
        //}

        static void Main(string[] args)
        {
            // 0. Mode connecté.
            var repo = new Repository();

            // 1. Nouvelle gouvernante affectée à l'hôtel
            var lopez = repo.NouvelleGouvernante("Lopez");

            // 2. Nouveau réceptionniste de l'hôtel
            var henri = repo.NouveauReception("Henri");

            // 3. Nouvel Hôtel
            repo.NouvelHotel("Ibis Style", lopez, henri);

            // 4. 2 nouvelles chambres 101 102 dans l'hôtel à l'étage 1

            // 5. 2 femmes de chambre A et B affectées à l'hôtel

            // 6. 1 intervention : A fait la 101 - B fait la 102 

            // 7. 

            Console.ReadLine();
        }
    }
    class Repository
    {
        private SqlConnection Cnx = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        public Repository()
        {
            Cnx.ConnectionString = "";
            Cnx.Open();

            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text;
        }

        internal Guid NouvelleGouvernante(string nom)
        {
            var id = Guid.NewGuid();
            Cmd.CommandText = "Insert...";
            Cmd.ExecuteNonQuery();
            return id;
        }
    }
}
