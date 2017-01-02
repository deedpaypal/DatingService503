namespace DatingService2.Model.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {

        public int id { get; set; }

        [StringLength(30)]
        public string username { get; set; }

        [StringLength(30)]
        public string userPassword { get; set; }

        public virtual Person Person { get; set; }

       

       
    }
}
