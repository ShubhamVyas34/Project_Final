using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Final.Models
{
    public class Flights
    {
        [Key]
        public int flightId { get; set; }

        [ForeignKey("traveller")]
        public int travellerId { get; set; }
        public String arrivalCity { get; set; }
        public String depatureCity { get; set; }
        public int date { get; set; }
        public int passengers { get; set; }
        public virtual Traveller traveller { get; set; }

    }
}
