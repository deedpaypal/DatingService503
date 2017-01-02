namespace DatingService2.Model.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Education")]
    public partial class Education
    {
        [ForeignKey("Person")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(30)]
        public string PersonEducation { get; set; }

        public virtual Person Person { get; set; }
    }
}

