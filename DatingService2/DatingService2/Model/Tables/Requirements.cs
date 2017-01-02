namespace DatingService2.Model.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Requirement
    {
        [ForeignKey("Person")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(7)]
        public string PartnerSex { get; set; }

        public int? AgeFrom { get; set; }

        public int? AgeAbove { get; set; }

        [StringLength(20)]
        public string PartnerCity { get; set; }

        [StringLength(30)]
        public string PartnerEducation { get; set; }

        public virtual Person Person { get; set; }
    }
}
