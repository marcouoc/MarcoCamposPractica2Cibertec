namespace Practica2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Playlist")]
    public partial class Playlist
    {
         public Playlist()
        {
            Track = new HashSet<Track>();
        }
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

         public virtual ICollection<Track> Track { get; set; }
    }
}
