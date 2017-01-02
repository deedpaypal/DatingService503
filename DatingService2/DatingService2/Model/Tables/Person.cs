namespace DatingService2.Model.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(35)]
        public string FirstName { get; set; }

        [StringLength(35)]
        public string LastName { get; set; }

        [StringLength(7)]
        public string Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public virtual Education Education { get; set; }

        public virtual Requirement Requirement { get; set; }

        public virtual User User { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual PrivateInf PrivateInf { get; set; }

        public virtual City City { get; set; }



    }
}
