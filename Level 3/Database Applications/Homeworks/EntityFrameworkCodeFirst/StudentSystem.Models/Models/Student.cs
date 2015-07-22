using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StudentSystem.Models.Models
{
    public class Student
    {

        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> Courseses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
