namespace DatingService2.Model.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Photo")]
    public partial class Photo
    {
        [ForeignKey("Person")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string PersonPhoto { get; set; }

        public virtual Person Person { get; set; }
    }
}

