using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Models
{
    public class DestinationRatingListItem : RatingListItem
    {
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public DateTime StayDate { get; set; }
    }
}
