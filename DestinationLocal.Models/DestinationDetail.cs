﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Models
{
    public class DestinationDetail
    {
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public List<BarListItem> Bars { get; set; } = new List<BarListItem>();
        public List<HotelListItem> Hotels { get; set; } = new List<HotelListItem>();
        public List<DestinationRatingListItem> Ratings { get; set; } = new List<DestinationRatingListItem>();

    }
}
