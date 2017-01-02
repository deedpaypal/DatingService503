using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingService2.Model.Entities
{
    class UserPrivateInf
    {
        public int Id { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public string Phone { get; set; }

        public UserPrivateInf(decimal height, decimal weight, string phone)
        {
            this.Height = height;
            this.Weight = weight;
            this.Phone = phone;
        }

    }
}
