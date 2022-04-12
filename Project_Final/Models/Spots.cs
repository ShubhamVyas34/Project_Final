using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Final.Models
{
    public class Spots
    {
        [Key]
        public int spotId { get; set; }

        [ForeignKey("traveller")]
        public int travellerId { get; set; }
        public String spotName { get; set; }
        public String spotLocation { get; set; }
        public String spotDescription { get; set; }

        public virtual Traveller traveller { get; set; }
    }
}
