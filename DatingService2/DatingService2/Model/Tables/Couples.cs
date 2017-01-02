using System.ComponentModel.DataAnnotations.Schema;

namespace DatingService2.Model.Tables
{
    class Couples
    {
        [ForeignKey("Person")]
        public int MaleId { get; set; }
        public int FemaleId { get; set; }
        public virtual Person Person { get; set; }
        public Couples()
        {
        }


    }
}
