using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPAdo.Contrat;

namespace TpAdo.Donnees
{
    public enum EntiteEnum
    {
        Employe = 1, Chambre = 2, Intervention = 3, InterventionDetail = 4, Message = 5, InterventionAjouter = 6,
        None = 0
    }


    public class Dal_ADO : IDal_ADO
    {
        private SqlConnection Cnx = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        public Dal_ADO()
        {
            Cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MakfiBD;Integrated Security=True";
            try
            {
                Cnx.Open();
            }
            catch (Exception)
            {

            }
            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text;
        }

        public Guid NouvelUtilisateur(string nom, byte statut)
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
        public Guid NouvelHotel(string nom, Guid gouv, Guid rec)
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
        public Guid NouvelleChambre(string nom, Guid hotel)
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
        public Guid NouvelEtage(string nom, Guid hotel, List<Guid> chambres)
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
        public Guid NouvelEmploye(string prenom, string nom, Guid hotel)
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

        public Guid NouvelleIntervention(Guid hotel, List<Guid> listEmp, List<Guid> listCh)
        {
            var idInter = Guid.NewGuid();
            var etatInter = FindEtat(EntiteEnum.Intervention, "Non terminée");
            var etatDetailInter = FindEtat(EntiteEnum.InterventionDetail, "En cours");
            var requete1 = $"insert into Intervention (Id, Date1, Model, Hotel, Etat) values('{idInter}', '{DateTime.Now}', 0, '{hotel}', '{etatInter}')";
            var requete2 = "insert into InterventionDetail (EmployeAffecte, ChambreAffectee, Intervention, Etat) values";
            for (int i = 0; i < listEmp.Count; i++)
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
