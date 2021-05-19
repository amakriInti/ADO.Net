using Evals.Exo4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evals.Exo4
{
    class Program
    {
        static void Main(string[] args)
        {
            var outil = new Outil();
            var s = Console.ReadLine();
            var resultat = outil.Majuscule(s);
            Console.WriteLine(resultat);
            Console.ReadLine();
        }
    }
}
