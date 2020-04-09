﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationLocal.Models
{
    public class DestinationRatingCreate
    {
        [Required]
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Required]
        [Range(1, 5)]
        public int Grade { get; set; }

        public string Comment { get; set; }

        public DateTime StayDate { get; set; }
    }
}
