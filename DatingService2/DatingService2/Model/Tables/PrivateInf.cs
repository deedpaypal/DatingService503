namespace DatingService2.Model.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrivateInf")]
    public partial class PrivateInf 
    {
        [ForeignKey("Person")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        public virtual Person Person { get; set; }
    }
}
