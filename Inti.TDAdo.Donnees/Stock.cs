//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inti.TDAdo.Donnees
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public System.Guid Id { get; set; }
        public System.Guid Article { get; set; }
        public int Qte { get; set; }
    
        public virtual Article Article1 { get; set; }
    }
}