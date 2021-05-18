using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPAdo.Contrat;

namespace TPAdo.DonneesV2
{
    public enum EntiteEnum
    {
        Employe = 1, Chambre = 2, Intervention = 3, InterventionDetail = 4, Message = 5, InterventionAjouter = 6,
        None = 0
    }

    public class Dal_ADO : IDal_ADO
    {
        private MakfiContext Contexte = new MakfiContext();
        public Guid NouvelEmploye(string prenom, string nom, Guid hotel)
        {
            var id = Guid.NewGuid();
            var etat = FindEtat(EntiteEnum.Employe, "Disponible");
            var employe = new Employe { Id = id, Nom = nom, Prenom = prenom, Etat = etat };
            Contexte.Employes.Add(employe);

            var he = new HotelEmploye { Employe = id, Hotel = hotel };
            Contexte.HotelEmployes.Add(he);

            Contexte.SaveChanges();

            return id;
        }

        private Guid FindEtat(EntiteEnum employe, string libelle)
        {
            var etat = Contexte.Etats.FirstOrDefault(e => e.Entite == (byte)employe && e.Libelle == libelle);
            if (etat == null) return default;
            return etat.Id;
        }

        public Guid NouvelEtage(string nom, Guid hotel, List<Guid> chambres)
        {
            var id = Guid.NewGuid();
            var etage = new GroupeChambre { Id = id, Nom = nom, Hotel = hotel };
            Contexte.GroupeChambres.Add(etage);

            foreach (var chambre in chambres)
            {
                var ch = new ChambreGroupeChambre { Chambre = chambre, GroupeChambre = id };
                Contexte.ChambreGroupeChambres.Add(ch);
            }

            Contexte.SaveChanges();
            return id;
        }

        public Guid NouvelHotel(string nom, Guid gouv, Guid rec)
        {
            var id = Guid.NewGuid();
            var hotel = new Hotel { Id = id, Nom = nom, Gouvernante = gouv, Reception = rec };
            Contexte.Hotels.Add(hotel);

            Contexte.SaveChanges();

            return id;
        }

        public Guid NouvelleChambre(string nom, Guid hotel)
        {
            var id = Guid.NewGuid();
            var etat = FindEtat(EntiteEnum.Chambre, "Disponible");
            var chambre = new Chambre { Id = id, Nom = nom, Etat = etat, Hotel = hotel };
            Contexte.Chambres.Add(chambre);

            Contexte.SaveChanges();

            return id;
        }

        public Guid NouvelleIntervention(Guid hotel, List<Guid> listEmp, List<Guid> listCh)
        {
            var id = Guid.NewGuid();
            var etatInter = FindEtat(EntiteEnum.Intervention, "Disponible");
            var etatInterD = FindEtat(EntiteEnum.InterventionDetail, "En cours");
            var intervention = new Intervention { Id = id, Date1 = DateTime.Now, Model = false, Hotel = hotel, Etat = etatInter };
            Contexte.Interventions.Add(intervention);

            for (int i = 0; i < listEmp.Count; i++)
            {
                var interD = new InterventionDetail { ChambreAffectee = listCh[i], EmployeAffecte=listEmp[i], Intervention=id, Etat=etatInterD };
                Contexte.InterventionDetails.Add(interD);
            }
            Contexte.SaveChanges();
            return id;
        }

        public Guid NouvelUtilisateur(string nom, byte statut)
        {
            var id = Guid.NewGuid();
            var utilisateur = new Utilisateur { Id = id, Nom = nom, CodePin = "1111", Statut = statut };
            Contexte.Utilisateurs.Add(utilisateur);

            Contexte.SaveChanges();

            return id;
        }
    }
}
