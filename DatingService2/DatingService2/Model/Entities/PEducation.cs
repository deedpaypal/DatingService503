using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingService2.Model.Entities
{
    class PEducation
    {
        public int Id { get; set; }
        public string PersonEducation { get; set; }

        public PEducation(int id, string personEducation)
        {
            this.Id = id;
            this.PersonEducation = personEducation;
        }
    }
}
