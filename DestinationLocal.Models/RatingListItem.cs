using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Models
{
    public class RatingListItem
    {
        public int RatingId { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        public bool IsUserOwned { get; set; }
    }
}
