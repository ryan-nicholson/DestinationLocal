using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Models
{
    public class HotelCreate
    {
        [Required]

        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Please choose a nuber between 1 and 5")]
        public int Rating { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Comment { get; set; }
    }
}
