namespace OliApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("oli.TopLab")]
    public partial class TopLab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TopLab()
        {
            TopLab11 = new HashSet<TopLab>();
        }

        [Key]
        public Guid TopLabGuid { get; set; }

        public Guid StammGuid { get; set; }

        public Guid PostItGuid { get; set; }

        [StringLength(255)]
        public string Titel { get; set; }

        [Column("TopLab")]
        [Required]
        [StringLength(3000)]
        public string TopLab1 { get; set; }

        [StringLength(255)]
        public string URL { get; set; }

        [Column(TypeName = "money")]
        public decimal Lohn { get; set; }

        public DateTime Datum { get; set; }

        [StringLength(255)]
        public string Datei { get; set; }

        public Guid? TopTopLabGuid { get; set; }

        [Required]
        [StringLength(3)]
        public string Typ { get; set; }

        public virtual PostIt PostIt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopLab> TopLab11 { get; set; }

        public virtual TopLab TopLab2 { get; set; }
    }
}
