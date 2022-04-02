using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegisteration
{
    public class PersonPersonality
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int PersonalityId { get; set; }
        public virtual Personality Personality { get; set; }
    }
}
