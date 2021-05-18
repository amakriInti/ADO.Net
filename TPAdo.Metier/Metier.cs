using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPAdo.DonneesV2;

namespace TPAdo.Metier
{
    public class Metier_Tp
    {
        private Dal_ADO Dal = new Dal_ADO( );
        public Guid NouvelUtilisateur(string nom, int statut)
        {
            return Dal.NouvelUtilisateur(nom, (byte) statut);
        }

        public Guid NouvelHotel(string nom, Guid gouv, Guid rec)
        {
            return Dal.NouvelHotel(nom, gouv, rec);
        }

        public Guid NouvelleChambre(string nom, Guid hotel)
        {
            return Dal.NouvelleChambre(nom, hotel);
        }

        public Guid NouvelEtage(string nom, Guid hotel, List<Guid> chambres)
        {
            return Dal.NouvelEtage(nom, hotel, chambres);
        }

        public Guid NouvelEmploye(string prenom, string nom, Guid hotel)
        {
            return Dal.NouvelEmploye(prenom, nom, hotel);
        }

        public Guid NouvelleIntervention(Guid hotel, List<Guid> listEmp, List<Guid> listCh)
        {
            return Dal.NouvelleIntervention(hotel, listEmp, listCh);
        }
    }
}
