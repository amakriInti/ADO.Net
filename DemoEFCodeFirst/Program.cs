using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCodeFirst
{
    // https://www.entityframeworktutorial.net/
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ExoCFContext();
            var articles = context.Articles.ToList();
            Console.WriteLine("C'est fait !");
            Console.ReadLine();
        }
    }
    class ExoCFContext : DbContext
    {
        public ExoCFContext() : base("name=ExoCFConfig") { }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

    }
    class Article
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
    }
    class Stock
    {
        public Guid Id { get; set; }
        public Guid Article { get; set; }
        public int Qte { get; set; }

    }
}
