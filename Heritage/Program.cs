using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage
{
    class Program 
    {
        static void Main(string[] args)
        {
            Vehicule v = null;
            if (Console.ReadLine() == "V")
            {
                v = new Voiture();
            }
            else
            {
                v = new Moto();
            }
            v.Rouler();

            Console.WriteLine(v);
            Console.Read();
        }
    }
    abstract class Vehicule
    {
        public abstract void Rouler();
    }

    interface IVehicule
    {
        void Rouler();
    }
    class Voiture : Vehicule
    {
        public override void Rouler() { Console.WriteLine("La voiture roule"); }
        //public override string ToString()
        //{
        //    return "exemple de Voiture";
        //}
    }
    class Moto : Vehicule
    {
        public override void Rouler()
        {
            Console.WriteLine("La moto roule");
        }
    }
    class Suv : Voiture
    {

        public override void Rouler()
        {
            Console.WriteLine("Le SUV roule");
            base.Rouler();
        }
    }
    class SuvDeLuxe : Suv
    {

        public new void Rouler()
        {
            Console.WriteLine("Le SUV roule");
            base.Rouler();
        }
    }
}
