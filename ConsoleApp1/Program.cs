using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AdventureWorksContext();
            var resultat = context.Products;

            // Affichage
            foreach (var p in resultat)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.Color);
            }
            Console.Read();

        }
    }
}
