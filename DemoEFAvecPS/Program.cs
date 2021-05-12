using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFAvecPS
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ExoArticleContext();
            var articles = context.Article_Read();
            context.Article_Insert(Guid.NewGuid(), "Cable RS232", 3);
            context.SaveChanges();
        }
    }
}
