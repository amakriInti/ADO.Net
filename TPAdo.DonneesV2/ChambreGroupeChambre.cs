//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPAdo.DonneesV2
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChambreGroupeChambre
    {
        public System.Guid Id { get; set; }
        public System.Guid Chambre { get; set; }
        public Nullable<System.Guid> GroupeChambre { get; set; }
    
        public virtual Chambre Chambre1 { get; set; }
        public virtual GroupeChambre GroupeChambre1 { get; set; }
    }
}
