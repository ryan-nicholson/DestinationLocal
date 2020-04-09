using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Data
{
    public abstract class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Grade { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string Comment { get; set; }
    }

    public class DestinationRating : Rating
    {
        [ForeignKey(nameof(Destination))]
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }

        public DateTime StayDate { get; set; }
        public string Name { get; set; }
    }

    public class BarRating : Rating
    {
        [ForeignKey(nameof(Bar))]
        public int BarId { get; set; }
        public virtual Bar Bar { get; set; }
        public DateTime StayDate { get; set; }
    }

    public class HotelRating : Rating
    {
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public DateTime StayDate { get; set; }
    }
}
