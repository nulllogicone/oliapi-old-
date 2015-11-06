namespace OliApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("oli.PostIt")]
    public partial class PostIt : IEqualityComparer<PostIt>
    {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
        "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PostIt()
    {
        //TopLab = new HashSet<TopLab>();
    }

    [Key]
    public Guid PostItGuid { get; set; }

    [StringLength(255)]
    public string Titel { get; set; }

    [Column("PostIt")]
    [Required]
    [StringLength(3000)]
    public string PostIt1 { get; set; }

    public DateTime Datum { get; set; }

    //[Column(TypeName = "money")]
    public double KooK { get; set; }

    public int? PostItZust { get; set; }

    [StringLength(255)]
    public string URL { get; set; }

    [StringLength(255)]
    public string Datei { get; set; }

    public int Hits { get; set; }

    [Required]
    [StringLength(3)]
    public string Typ { get; set; }

    //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    //public virtual ICollection<TopLab> TopLab { get; set; }

        public bool Equals(PostIt x, PostIt y)
        {
            return x.PostItGuid == y.PostItGuid;
        }

        public int GetHashCode(PostIt obj)
        {
            throw new NotImplementedException();
        }
    }
}
