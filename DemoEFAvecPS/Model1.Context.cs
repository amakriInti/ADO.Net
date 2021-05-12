﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoEFAvecPS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ExoArticleContext : DbContext
    {
        public ExoArticleContext()
            : base("name=ExoArticleContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
    
        public virtual int Article_Delete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Article_Delete", idParameter);
        }
    
        public virtual int Article_Insert(Nullable<System.Guid> id, string nom, Nullable<decimal> prix)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var nomParameter = nom != null ?
                new ObjectParameter("nom", nom) :
                new ObjectParameter("nom", typeof(string));
    
            var prixParameter = prix.HasValue ?
                new ObjectParameter("prix", prix) :
                new ObjectParameter("prix", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Article_Insert", idParameter, nomParameter, prixParameter);
        }
    
        public virtual int Stock_Delete(Nullable<System.Guid> id, Nullable<System.Guid> article)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var articleParameter = article.HasValue ?
                new ObjectParameter("article", article) :
                new ObjectParameter("article", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Stock_Delete", idParameter, articleParameter);
        }
    
        public virtual int Stock_Insert(Nullable<System.Guid> article, Nullable<int> qte)
        {
            var articleParameter = article.HasValue ?
                new ObjectParameter("article", article) :
                new ObjectParameter("article", typeof(System.Guid));
    
            var qteParameter = qte.HasValue ?
                new ObjectParameter("qte", qte) :
                new ObjectParameter("qte", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Stock_Insert", articleParameter, qteParameter);
        }
    
        public virtual ObjectResult<Article_Read_Result> Article_Read()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Article_Read_Result>("Article_Read");
        }
    }
}
