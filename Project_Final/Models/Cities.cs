using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Final.Models
{
    
    public class Cities
    {
        
        [Key]
        public int cityId { get; set; }

        [ForeignKey("traveller")]
        public int travellerId { get; set; }
        public String cityName { get; set; }
        public int cityPopulation { get; set; }
        public String cityAttraction { get; set; }
        public String cityInfo { get; set; }
        public virtual Traveller traveller { get; set; }
    }

}
