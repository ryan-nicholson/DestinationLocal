using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Models
{
    public class HotelRatingCreate
    {
        [Required]
        public int HotelId { get; set; }
        public string Name { get; set; }

        [Required]
        [Range(1, 5)]
        public int Grade { get; set; }

        public string Comment { get; set; }

        public DateTime StayDate { get; set; }
    }
}
