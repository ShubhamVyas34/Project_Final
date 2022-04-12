using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Final.Models
{
    public class Traveller
    {
        [Key]
        public int travellerId { get; set; }

        public String name { get; set; }
        public int age { get; set; }
        public int contact { get; set; }
        public String email { get; set; }
        public String gender { get; set; }

    }
}
