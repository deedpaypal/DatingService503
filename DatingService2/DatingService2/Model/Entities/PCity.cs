using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingService2.Model.Entities
{
    class PCity
    {
        public int Id { get; set; }
        public string PersonCity { get; set; }

        public PCity(int id, string personCity)
        {
            this.Id = id;
            this.PersonCity = personCity;
        }
    }
}
