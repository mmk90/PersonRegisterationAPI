using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegisteration
{
    public class Personality
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
