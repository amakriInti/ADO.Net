using System;using System.Collections.Generic;using System.Data;using System.Data.SqlClient;using System.Linq;using System.Text;using System.Threading.Tasks;namespace TPAdo.Interface{
    public enum TypeRequete { Select, Insert, Delete, Update }
    public enum EntiteEnum
    {
        Employe = 1, Chambre = 2, Intervention = 3, InterventionDetail = 4, Message = 5, InterventionAjouter = 6,
        None = 0
    }    class Program    {        static void Main(string[] args)        {
            //Aucune interaction avec l'utilisateur on fait tout en dure (table utilisateur)

            //0. Mode Connécté

            //1. Nouvelle gouvernante affecté a l'Hotel (table utilisateur) status == 1
            //ModeConnecte(TypeRequete.Insert, $"Insert into Utilisateur (Id, Nom, Identifiant, CodePin, Statut)  Values('{IdGouvernante}', 'Sandra', 1 ,'1111',1)");
            //var gouvernante = new Utilisateur() { Id = Guid.NewGuid(), Nom = "Sandra", Identifiant = 1, CodePin = "1111", Statut = 1 };
            //2. Nouveau receptionniste 

            //var receptionniste = new Utilisateur() { Id = Guid.NewGuid(), Nom = "Andre", Identifiant = 2, CodePin = "1111", Statut = 2 };

            var dal = new Dal_ADO();            var andre = Guid.NewGuid();            if (dal.ModeConnecte(
                TypeRequete.Insert,
                $"Insert Utilisateur (Id, Nom, Identifiant, CodePin ,Statut)  Values('{andre}', 'André', 2 , '1111', 2)"))
            {
                var sandra = Guid.NewGuid();
                dal.ModeConnecte(
                    TypeRequete.Insert,
                    $"Insert Utilisateur (Id, Nom, Identifiant, CodePin ,Statut)  Values('{sandra}', 'Sandra', 1 , '1111', 1)");

                ////3. Nouvel Hotêl

                var hotel1 = Guid.NewGuid();
                dal.ModeConnecte(TypeRequete.Insert, $"Insert Hotel (Id, Nom, Reception, Gouvernante) Values('{hotel1}', 'Novotel', '{andre}' , '{sandra}'");

                ////4. Ajout de deux nouvelle chambre 101 102 qui seront à l'étage 1
                var chambre1 = Guid.NewGuid();
                var chambre2 = Guid.NewGuid();
                var etatChambre = dal.FindEtat(EntiteEnum.Chambre, "Disponible");
                dal.ModeConnecte(TypeRequete.Insert, $"Insert Chambre (Id, Nom, Etat, Hotel) Values('{chambre1}', '101', '{etatChambre}' , '{hotel1}'");
                dal.ModeConnecte(TypeRequete.Insert, $"Insert Chambre (Id, Nom, Etat, Hotel) Values('{chambre2}', '102', '{etatChambre}' , '{hotel1}'");

                //var IdChambre2 = Guid.NewGuid();
                //ModeConnecte(TypeRequete.Insert, $"Insert Chambre (Id, Nom, Etat, Commentaire, Hotel)  Values('{IdChambre2}', 'Chambre 102', '04d2e6b4-0e57-4eda-ad60-256d3f59f714' ,'Chambre au premier étage', '{IdHotel}')"); // Libelle Disponible(2)
                //var IdGroupeChambre1 = Guid.NewGuid();
                //ModeConnecte(TypeRequete.Insert, $"Insert GroupeChambre (Id, Nom, Commentaire, Hotel)  Values('{IdGroupeChambre1}', 'Premier Etage', null , '{IdHotel}')");

                //ModeConnecte(TypeRequete.Insert, $"Insert ChambreGroupeChambre (Chambre, GroupeChambre)  Values('{IdChambre1}', '{IdGroupeChambre1}')");
                //ModeConnecte(TypeRequete.Insert, $"Insert ChambreGroupeChambre (Chambre, GroupeChambre)  Values('{IdChambre2}', '{IdGroupeChambre1}')");
                //var IdEmploye1 = Guid.NewGuid();
                //ModeConnecte(TypeRequete.Insert, $"Insert Employe (Id, Nom, Prenom, Etat, Commentaire, Vitesse)  Values('{IdEmploye1}', 'Etoile', 'Patrick' ,'3b6dcc06-1c7c-4213-9535-973beeb6d91f', null, null)"); // Libelle Disponible(1)

                //var IdEmploye2 = Guid.NewGuid();
                //ModeConnecte(TypeRequete.Insert, $"Insert Employe (Id, Nom, Prenom, Etat, Commentaire, Vitesse)  Values('{IdEmploye2}', 'Eponge', 'Bob' ,'3b6dcc06-1c7c-4213-9535-973beeb6d91f', null, null)"); // Libelle Disponible (1)

                //ModeConnecte(TypeRequete.Insert, $"Insert HotelEmploye (Hotel, Employe)  Values('{IdHotel}','{IdEmploye1}' )"); // Libelle Disponible (1)
                //ModeConnecte(TypeRequete.Insert, $"Insert HotelEmploye (Hotel, Employe)  Values('{IdHotel}','{IdEmploye2}' )"); // Libelle Disponible (1)
            }
            Console.ReadLine();
        }    }
    class Dal_ADO
    {
        private SqlConnection Cnx = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        public Dal_ADO()
        {
            Cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MakfiBD;Integrated Security=True";            Cnx.Open();

            Cmd.Connection = Cnx; //liaison entre cmd et cnx
            Cmd.CommandType = CommandType.Text; //text pour dire requete SQL
        }
        public bool ModeConnecte(TypeRequete tRequete, string sql)        {
            Cmd.CommandText = sql;            switch (tRequete)            {                case TypeRequete.Select: return false;                case TypeRequete.Update:                case TypeRequete.Insert:                case TypeRequete.Delete:                    try                    {                        Cmd.ExecuteNonQuery();
                        return true;                    }                    catch (Exception)                    {                        return false;
                    }                default: throw new Exception("Program.ModeConnecte");             }        }        public Guid FindEtat(EntiteEnum entite, string libelle)        {            Cmd.CommandText = $"SELECT Id FROM Etat WHERE Entite = {(int)entite} and Libelle = '{libelle}' ";            try            {                return (Guid)Cmd.ExecuteScalar();            }            catch (Exception e)            {                Console.Write(e);                return default;            }        }
    }

    //internal class Hotel
    //{
    //    public Hotel()
    //    {
    //    }

    //    public Guid Id { get; set; }
    //    public string Nom { get; set; }
    //    public Guid Reception { get; set; }
    //    public Guid Gouvernante { get; set; }
    //}

    //internal class Utilisateur
    //{
    //    public Utilisateur()
    //    {
    //    }

    //    public Guid Id { get; set; }
    //    public string Nom { get; set; }
    //    public int Identifiant { get; set; }
    //    public string CodePin { get; set; }
    //    public int Statut { get; set; }
    //}
}
