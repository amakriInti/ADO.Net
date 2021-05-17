using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Exo3CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SuperLeagueContext();

            var psg = new Equipe(context) { Nom = "Paris Saint Germain", FondTransfert = 3000000000 };
            var rcs = new Equipe(context) { Nom = "Racing Club de Strasbourg", FondTransfert = 30000000 };
            var mBape = new Joueur(context) { Nom = "MBape", Equipe = psg.Id };
            var mBapeBis = new Joueur(context) { Nom = "MBape", Equipe = psg.Id };
            var tmBape = new Transfert(context) { DateTransfert = DateTime.Now, Joueur = mBape.Id, EquipeVendeur = psg.Id, EquipeAcheteur = rcs.Id, Montant = 3000 };

            context.Equipes.Add(psg);
            context.Equipes.Add(rcs);
            context.Joueurs.Add(mBape);
            context.SaveChanges();

            if (context.Joueurs.FirstOrDefault(j => j.Nom == mBapeBis.Nom) == null)
                context.Joueurs.Add(mBapeBis);

            context.Transferts.Add(tmBape);

            context.SaveChanges();

            var b = tmBape.Execute();
            if (b == ErreurTransfertEnum.None) context.SaveChanges();
        }
    }
    public class SuperLeagueContext : DbContext
    {
        public SuperLeagueContext() : base("name=SuperLeagueConfig") { }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Transfert> Transferts { get; set; }
    }
    public class Entite
    {
        public Guid Id { get; set; }

        public Entite() { }
        public Entite(SuperLeagueContext context)
        {
            Id = Guid.NewGuid();
            Context = context;
        }
        [NotMapped]
        protected SuperLeagueContext Context = null;

    }
    public class Equipe : Entite
    {
        public Equipe() : base()
        {

        }
        public Equipe(SuperLeagueContext context) : base(context)
        {
        }

        public string Nom { get; set; }
        public decimal FondTransfert { get; set; }
    }
    public class Joueur : Entite
    {
        public Joueur() : base()
        {

        }

        public Joueur(SuperLeagueContext context) : base(context)
        {
        }

        [Required]
        public string Nom { get; set; }
        public Guid Equipe { get; set; }
    }
    public class Transfert : Entite
    {
        public Transfert() : base()
        {

        }

        public Transfert(SuperLeagueContext context) : base(context)
        {
        }

        public Guid EquipeVendeur { get; set; }
        public Guid EquipeAcheteur { get; set; }
        public Guid Joueur { get; set; }
        public DateTime DateTransfert { get; set; }
        public decimal Montant { get; set; }
        internal ErreurTransfertEnum Execute()
        {
            var joueur = Context.Joueurs.FirstOrDefault(j => j.Id == Joueur);
            if (joueur == null) return ErreurTransfertEnum.PasJoueur;

            var equipeVendeur = Context.Equipes.FirstOrDefault(e => e.Id == EquipeVendeur);
            if (equipeVendeur == null) return ErreurTransfertEnum.PasEquipeVendeur;
            var equipeAcheteur = Context.Equipes.FirstOrDefault(e => e.Id == EquipeAcheteur);
            if (equipeAcheteur == null) return ErreurTransfertEnum.PasEquipeAcheteur;
            if (Montant > equipeAcheteur.FondTransfert) return ErreurTransfertEnum.PasSous;

            joueur.Equipe = equipeAcheteur.Id;
            equipeAcheteur.FondTransfert -= Montant;
            equipeVendeur.FondTransfert += Montant;
            return ErreurTransfertEnum.None;
        }
    }
    enum ErreurTransfertEnum { None, PasJoueur, PasEquipeVendeur, PasEquipeAcheteur, PasSous }
}
