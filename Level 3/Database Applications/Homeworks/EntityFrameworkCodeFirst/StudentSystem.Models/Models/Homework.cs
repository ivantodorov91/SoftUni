using System;
using System.ComponentModel.DataAnnotations;
using StudentSystem.Models.Types;

namespace StudentSystem.Models.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public HomeworkContentType HomeworkContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }
    }
}
