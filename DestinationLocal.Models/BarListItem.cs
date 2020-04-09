using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Models
{
    public class BarListItem
    {
        public int BarId { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public bool ServesFood { get; set; }
    }
}
