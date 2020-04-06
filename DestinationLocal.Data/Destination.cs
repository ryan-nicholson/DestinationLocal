using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Data
{
    public class Destination
    {
        public Destination() { }
        public Destination(string name, string city, string state, string country)
        {
            Name = name;
            City = city;
            State = state;
            Country = country;
        }

        [Key]
        public int DestinationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public string Country { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
        public virtual ICollection<Bar> Bars { get; set; } = new List<Bar>();

    }
}
