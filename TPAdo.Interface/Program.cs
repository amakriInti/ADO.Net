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
            var dal = new Dal();

            // 1. Nouvelle gouvernante affectée à l'hôtel
            var lopez = dal.NouvelUtilisateur("Lopez", 1);
            if (lopez == default) { Console.WriteLine("Insertion gouvernante impossible"); return; }

            // 2. Nouveau réceptionniste de l'hôtel
            var henri = dal.NouvelUtilisateur("Henri", 2);
            if (henri == default) { Console.WriteLine("Insertion réceptionniste impossible"); return; }

            // 3. Nouvel Hôtel
            var hotel1 = dal.NouvelHotel("Ibis Style", lopez, henri);

            // 4. 2 nouvelles chambres 101 102 dans l'hôtel à l'étage 1
            var ch1 = dal.NouvelleChambre("101", hotel1);
            var ch2 = dal.NouvelleChambre("102", hotel1);

            var etage1 = dal.NouvelEtage("Etage 1", hotel1, new List<Guid> { ch1, ch2 });

            // 5. 2 femmes de chambre A et B affectées à l'hôtel
            var emp1 = dal.NouvelEmploye("Philippe", "Lavilliers", hotel1);
            var emp2 = dal.NouvelEmploye("Georgina", "Dufoix", hotel1);

            // 6. 1 intervention : A fait la 101 - B fait la 102 
            var inter = dal.NouvelleIntervention(hotel1, new List<Guid> { emp1, emp2}, new List<Guid> { ch1, ch2 });

            Console.ReadLine();
        }
    }
    class Dal
    {
        private SqlConnection Cnx = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        public Dal()
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
            var idEmploye = Guid.NewGuid();
            var etat = FindEtat(EntiteEnum.Employe, "Disponible");

            var requete1 = $"insert into Employe (Id, Nom, Prenom, Etat) values('{idEmploye}', '{nom}', '{prenom}', '{etat}')";
            var requete2 = $"insert into HotelEmploye (Employe, Hotel) values ('{idEmploye}', '{hotel}')";
            try
            {
                Cmd.CommandText = $"{requete1};{requete2}";
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return default;
            }

            return idEmploye;
        }

        internal object NouvelleIntervention(Guid hotel, List<Guid> listEmp, List<Guid> listCh)
        {
            var idInter = Guid.NewGuid();
            var etatInter = FindEtat(EntiteEnum.Intervention, "Non terminée");
            var etatDetailInter = FindEtat(EntiteEnum.InterventionDetail, "En cours");
            var requete1 = $"insert into Intervention (Id, Date1, Model, Hotel, Etat) values('{idInter}', {DateTime.Now}, 0, '{hotel}', '{etatInter}')";
            var requete2 = "insert into InterventionDetail (EmployeAffecte, ChambreAffectee, Intervention, Etat) values";
            for(int i=0; i < listEmp.Count; i++)
            {
                var idInterDetail = Guid.NewGuid();
                requete2 += $"('{listEmp[i]}', '{listCh[i]}', '{idInter}', '{etatDetailInter}'),";
            }
            requete2 = requete2.Substring(0, requete2.Length - 1);
            try
            {
                Cmd.CommandText = $"{requete1};{requete2}";
                Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return default;
            }

            return idInter;

        }
    }
}
