namespace Practica2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MediaType")]
    public partial class MediaType
    {
         public MediaType()
        {
            Track = new HashSet<Track>();
        }
        [Key]
        public int MediaTypeId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

         public virtual ICollection<Track> Track { get; set; }
    }
}
