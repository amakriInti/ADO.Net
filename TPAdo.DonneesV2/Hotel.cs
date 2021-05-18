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
    
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            this.Chambres = new HashSet<Chambre>();
            this.GroupeChambres = new HashSet<GroupeChambre>();
            this.HotelEmployes = new HashSet<HotelEmploye>();
            this.Interventions = new HashSet<Intervention>();
        }
    
        public System.Guid Id { get; set; }
        public string Nom { get; set; }
        public Nullable<System.Guid> Reception { get; set; }
        public Nullable<System.Guid> Gouvernante { get; set; }
        public string Commentaire { get; set; }
        public string IdWeb { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chambre> Chambres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupeChambre> GroupeChambres { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public virtual Utilisateur Utilisateur1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelEmploye> HotelEmployes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
