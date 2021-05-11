using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF
{
    class Program
    {
        static void Main(string[] args)
        {
            // On s'adressee à EF
            var context = new AdventureWorksContext();
            var resultat = context.People.Where(p => p.FirstName == "Ken");

            // Affichage
            foreach(var p in resultat)
            {
                Console.WriteLine("{0} - {1} - {2}", p.BusinessEntityID, p.LastName, p.FirstName);
            }
            Console.Read();
        }
    }
}
