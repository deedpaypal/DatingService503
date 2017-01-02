using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingService2.Model.Entities
{
    class PRequirement
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public int  AgeFrom { get; set; }
        public int AgeAbove { get; set; }
        public string City { get; set; }
        public string Education { get; set; }

        public PRequirement(string sex, int ageFrom, int ageAbove, string city, string education)
        {
            this.Sex = sex;
            this.AgeFrom = ageFrom;
            this.AgeAbove = ageAbove;
            this.City = city;
            this.Education = education;
        }
    }
}
