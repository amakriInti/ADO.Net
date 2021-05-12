using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo2_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ExoArticleContext();

            //foreach (var stockItem in context.Stocks)
            //{
            //    var article = stockItem.Article1.Nom;
            //    var prix = stockItem.Article1.Prix;
            //    var qte = stockItem.Qte;
            //    Console.WriteLine("{0} {1} {2}", article, prix, qte);
            //}

            //var resultat = context.Stocks
            //    .Select(si => new
            //    {
            //        Nom = si.Article1.Nom,
            //        Prix = si.Article1.Prix,
            //        Qte = si.Qte
            //    });
            //foreach (var item in resultat)
            //{
            //    Console.WriteLine("{0} {1} {2}", item.Nom, item.Prix, item.Qte);
            //}

            // Update : Prix du clavier passe de 15 à 45€
            //var clavier = context.Articles.Where(a=>a.Nom=="Clavier").FirstOrDefault();
            //if (clavier != null)
            //{
            //    clavier.Prix = 45;
            //    context.SaveChanges();
            //}


            // Insert : 100 souris en stock
            //var souris = context.Articles.Where(a => a.Nom == "Souris").FirstOrDefault();
            //if (souris != null)
            //{
            //    context.Stocks.Add(new Stock {Id=Guid.NewGuid(), Article = souris.Id, Qte = 100 });
            //    context.SaveChanges();
            //}

            // Delete souris en stock
            var stocksSouris = context.Stocks.Where(a => a.Article1.Nom == "Souris");
            if (stocksSouris.Count() > 0)
            {
                context.Stocks.RemoveRange(stocksSouris);
                context.SaveChanges();
            }


            Console.Read();
        }
    }
}
