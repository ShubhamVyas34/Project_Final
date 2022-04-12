using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Final.Models
{
    public class Hotels
    {
        [Key]
        public int hotelId { get; set; }
        [ForeignKey("traveller")]
        public int travellerId { get; set; }
        public String hotelName { get; set; }
        public int checkInDate { get; set; }
        public int checkOutDate { get; set; }
        public int noOfRooms { get; set; }

        
        public virtual Traveller traveller { get; set; }
    }
}
