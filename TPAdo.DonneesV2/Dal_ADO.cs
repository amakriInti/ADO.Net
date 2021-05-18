using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPAdo.Contrat;

namespace TPAdo.DonneesV2
{

    public class Dal_ADO : IDal_ADO
    {
        public Guid NouvelEmploye(string prenom, string nom, Guid hotel)
        {
            throw new NotImplementedException();
        }

        public Guid NouvelEtage(string nom, Guid hotel, List<Guid> chambres)
        {
            throw new NotImplementedException();
        }

        public Guid NouvelHotel(string nom, Guid gouv, Guid rec)
        {
            throw new NotImplementedException();
        }

        public Guid NouvelleChambre(string nom, Guid hotel)
        {
            throw new NotImplementedException();
        }

        public Guid NouvelleIntervention(Guid hotel, List<Guid> listEmp, List<Guid> listCh)
        {
            throw new NotImplementedException();
        }

        public Guid NouvelUtilisateur(string nom, int statut)
        {
            throw new NotImplementedException();
        }
    }
}
