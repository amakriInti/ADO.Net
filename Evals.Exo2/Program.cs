using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evals.Exo2
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AdvContext();
            var liste = context.People
                .Where(p => p.BusinessEntity.BusinessEntityAddresses.Count() > 0)
                .Select(p => new
                {
                    Ville = p.BusinessEntity.BusinessEntityAddresses.FirstOrDefault().Address.City,
                    Nom = p.LastName,
                    Prenom = p.FirstName
                })
                .OrderBy(p => p.Ville)
                .ToList();

            string ville = "";
            foreach (var personne in liste)
            {
                if (personne.Ville != ville)
                {
                    ville = personne.Ville;
                    Console.WriteLine(ville);
                }
                Console.WriteLine("\t{0} - {1}",
                    personne.Nom,
                    personne.Prenom);
            }
            Console.ReadLine();
        }
    }
}
