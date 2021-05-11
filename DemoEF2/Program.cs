using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF2
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AdventureWorksContext();
            //var velos = context
            //    .Products
            //    .Where(p => p.ProductSubcategory.ProductCategory.Name == "Bikes")
            //    .ToList();

            var velos = 
                from p in context.Products 
                where p.ProductSubcategory.ProductCategory.Name == "Bikes" 
                select p;
            foreach(var velo in velos)
            {
                Console.WriteLine(velo);
            }
            Console.Read();
        }
    }
}
