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
        static void Main(string[] args)
        {
            // 0. Mode connecté.
            var repo = new Repository();

            // 1. Nouvelle gouvernante affectée à l'hôtel
            var lopez = repo.NouvelUtilisateur("Lopez", 1);
            if (lopez == default) { Console.WriteLine("Insertion gouvernante impossible"); return; }

            // 2. Nouveau réceptionniste de l'hôtel
            var henri = repo.NouvelUtilisateur("Henri", 2);
            if (henri == default) { Console.WriteLine("Insertion réceptionniste impossible"); return; }

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

        internal Guid NouvelUtilisateur(string nom, string statut)
        {
            var id = Guid.NewGuid();
            Cmd.CommandText = $"Insert into Utilisateur (Id, Nom, CodePin, Statut) values('{id}', '{nom}', '1111', {statut})";
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return default;
            }
            return id;
        }
        internal Guid NouvelHotel(string nom, Guid gouv, Guid rec)
        {
            var id = Guid.NewGuid();
            Cmd.CommandText = $"Insert into Utilisateur (Id, Nom, CodePin, Statut) values('{id}', '{nom}', '1111', {statut})";
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return default;
            }
            return id;
        }
    }
}
