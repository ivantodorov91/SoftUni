using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentSystem.Models.Types;

namespace StudentSystem.Models.Models
{
    public class Resource
    {
        private ICollection<License> licenses;
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TypeOfResource TypeOfResource { get; set; }

        public string URL { get; set; }

        public virtual ICollection<License> Licenses
        {
            get { return this.licenses; }
            set { this.Licenses = value; }
        }

    }
}
