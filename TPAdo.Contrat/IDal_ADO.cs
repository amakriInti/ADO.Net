using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAdo.Contrat
{
    public interface IDal_ADO
    {
        Guid NouvelEmploye(string prenom, string nom, Guid hotel);
        Guid NouvelEtage(string nom, Guid hotel, List<Guid> chambres);
        Guid NouvelHotel(string nom, Guid gouv, Guid rec);
        Guid NouvelleChambre(string nom, Guid hotel);
        Guid NouvelleIntervention(Guid hotel, List<Guid> listEmp, List<Guid> listCh);
        Guid NouvelUtilisateur(string nom, byte statut);
    }
}
