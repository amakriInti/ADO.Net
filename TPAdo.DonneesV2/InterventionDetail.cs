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
    
    public partial class InterventionDetail
    {
        public System.Guid Id { get; set; }
        public System.Guid EmployeAffecte { get; set; }
        public System.Guid ChambreAffectee { get; set; }
        public string Commentaire { get; set; }
        public System.Guid Intervention { get; set; }
        public System.Guid Etat { get; set; }
    
        public virtual Chambre Chambre { get; set; }
        public virtual Employe Employe { get; set; }
        public virtual Etat Etat1 { get; set; }
        public virtual Intervention Intervention1 { get; set; }
    }
}
