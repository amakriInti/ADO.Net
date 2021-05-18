using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TPAdo.Metier;

namespace TPAdo.Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0. Mode connecté.
            var metier = new Metier_Tp();

            // 1. Nouvelle gouvernante affectée à l'hôtel
            var lopez = metier.NouvelUtilisateur("Lopez", 1);
            if (lopez == default) { Console.WriteLine("Insertion gouvernante impossible"); return; }

            // 2. Nouveau réceptionniste de l'hôtel
            var henri = metier.NouvelUtilisateur("Henri", 2);
            if (henri == default) { Console.WriteLine("Insertion réceptionniste impossible"); return; }

            // 3. Nouvel Hôtel
            var hotel1 = metier.NouvelHotel("Ibis Style", lopez, henri);

            // 4. 2 nouvelles chambres 101 102 dans l'hôtel à l'étage 1
            var ch1 = metier.NouvelleChambre("101", hotel1);
            var ch2 = metier.NouvelleChambre("102", hotel1);

            var etage1 = metier.NouvelEtage("Etage 1", hotel1, new List<Guid> { ch1, ch2 });

            // 5. 2 femmes de chambre A et B affectées à l'hôtel
            var emp1 = metier.NouvelEmploye("Philippe", "Lavilliers", hotel1);
            var emp2 = metier.NouvelEmploye("Georgina", "Dufoix", hotel1);

            // 6. 1 intervention : A fait la 101 - B fait la 102 
            var inter = metier.NouvelleIntervention(hotel1, new List<Guid> { emp1, emp2}, new List<Guid> { ch1, ch2 });

            Console.ReadLine();
        }
    }
}
