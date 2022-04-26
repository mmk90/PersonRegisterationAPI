using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegisteration
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        [NotMapped]
        public string personalities { get; set; }

        [NotMapped]
        public List<int> personalitiesIds { get; set; } = new List<int>();
        public List<PersonPersonality> PersonPersonalities { get; set; }
    }
}
