using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Data
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1,5, ErrorMessage = "Please choose a nuber between 1 and 5")]
        [Display(Name = "Hotel Rating")]
        public int Rating { get; set; }
        [Required]
        [MaxLength(2000, ErrorMessage = "Your comment is too long, please summarize to 2000 characters.")]
        [Display(Name = "Hotel Comment")]
        public string Comment { get; set; }
        public double AverageRating
        {
            get
            {
                if (Ratings != null && Ratings.Count != 0)
                    return (double)Ratings.Sum(rating => rating.Grade) / Ratings.Count;

                return 0;
            }
        }
        [ForeignKey(nameof(Destination))]
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }

        public virtual ICollection<HotelRating> Ratings { get; set; }
    }
}
