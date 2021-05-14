using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo3CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SuperLeagueContext();

            var psg = new Equipe { Id = Guid.NewGuid(), Nom = "Paris Saint Germain", FondTransfert = 3000000000 };
            var rcs = new Equipe { Id = Guid.NewGuid(), Nom = "Racing Club de Strasbourg", FondTransfert = 30000000 };
            var mBape = new Joueur { Id = Guid.NewGuid(), Nom = "MBape", Equipe = psg.Id };
            var t1 = new Transfert { Id = Guid.NewGuid(), DateTransfert = DateTime.Now, Joueur = mBape.Id, EquipeVendeur = psg.Id, EquipeAcheteur = rcs.Id, Montant = 3000 };
            bool b = t1.Execute(context);
        }
    }
    class SuperLeagueContext : DbContext
    {
        public SuperLeagueContext() : base("name=SuperLeagueConfig") { }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Transfert> Transferts { get; set; }
    }

    public class Equipe
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public decimal FondTransfert { get; set; }
    }
    public class Joueur
    {
        public Guid Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public Guid Equipe { get; set; }
    }
    public class Transfert
    {
        public Guid Id { get; set; }
        public Guid EquipeVendeur { get; set; }
        public Guid EquipeAcheteur { get; set; }
        public Guid Joueur { get; set; }
        public DateTime DateTransfert { get; set; }
        public decimal Montant { get; set; }
        internal bool Execute(SuperLeagueContext context)
        {
            var joueur = context.Joueurs.FirstOrDefault(j => j.Id == Joueur);
            if (joueur == null) return false;

            var equipeVendeur = context.Equipes.FirstOrDefault(e => e.Id == EquipeVendeur);
            if (equipeVendeur == null) return false;
            var equipeAcheteur = context.Equipes.FirstOrDefault(e => e.Id == EquipeAcheteur);
            if (equipeAcheteur == null) return false;
            if (Montant > equipeAcheteur.FondTransfert) return false;

            joueur.Equipe = equipeAcheteur.Id;
            equipeAcheteur.FondTransfert -= Montant;
            equipeVendeur.FondTransfert += Montant;
            return true;
        }
    }
}
