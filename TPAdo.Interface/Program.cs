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
    enum TypeCommande { Insert }
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
            var hotel1 = repo.NouvelHotel("Ibis Style", lopez, henri);

            // 4. 2 nouvelles chambres 101 102 dans l'hôtel à l'étage 1
            var ch1 = repo.NouvelleChambre("101", hotel1);
            var ch2 = repo.NouvelleChambre("102", hotel1);

            var etage1 = repo.NouvelEtage("Etage 1", hotel1, new List<Guid> { ch1, ch2 });

            // 5. 2 femmes de chambre A et B affectées à l'hôtel
            var emp1 = repo.NouvelEmploye("Philippe", "Lavilliers", hotel1);
            var emp2 = repo.NouvelEmploye("Georgina", "Dufoix", hotel1);

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

        internal Guid NouvelUtilisateur(string nom, int statut)
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
            Cmd.CommandText = $"Insert into Hotel (Id, Nom, Gouvernante, Reception) values('{id}', '{nom}', '{gouv}', '{rec}')";
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
        internal Guid NouvelleChambre(string nom, Guid hotel)
        {
            var id = Guid.NewGuid();
            var etat = FindEtat(EntiteEnum.Chambre, "Disponible");
            Cmd.CommandText = $"Insert into Chambre (Id, Nom, Etat, Hotel) values('{id}', '{nom}', '{etat}', '{hotel}')";
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
        internal Guid NouvelEtage(string nom, Guid hotel, List<Guid> chambres)
        {
            var idEtage = Guid.NewGuid();
            var requete1 = $"insert into GroupeChambre (Id, Nom, Hotel) values('{idEtage}', '{nom}', '{hotel}')";
            var requete2 = "insert into ChambreGroupeChambre (Chambre, GroupeChambre) values" + string.Join(",", chambres.Select(x => $"('{x}', '{idEtage}')"));
            try
            {
                Cmd.CommandText = $"{requete1};{requete2}";
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return default;
            }

            return idEtage;
        }

        private Guid FindEtat(EntiteEnum entite, string libelle)
        {
            Cmd.CommandText = $"select Id from Etat where Entite={(int)entite} and Libelle='{libelle}'";
            try
            {
                return (Guid)Cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return default;
            }
        }
        internal Guid NouvelEmploye(string prenom, string nom, Guid hotel)
        {
            var idEtage = Guid.NewGuid();
            var requete1 = $"insert into GroupeChambre (Id, Nom, Hotel) values('{idEtage}', '{nom}', '{hotel}')";
            var requete2 = "insert into ChambreGroupeChambre (Chambre, GroupeChambre) values" + string.Join(",", chambres.Select(x => $"('{x}', '{idEtage}')"));
            try
            {
                Cmd.CommandText = $"{requete1};{requete2}";
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return default;
            }

            return idEtage;
        }

    }
}
