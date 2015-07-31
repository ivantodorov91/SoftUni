using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountains_Code_First
{
    public class Mountain
    {

        public Mountain()
        {
            this.Countries = new HashSet<Country>();
            this.Peaks = new HashSet<Peak>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<Peak> Peaks { get; set; }
    }
}
