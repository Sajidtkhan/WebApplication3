using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Subject
    {
        [Required(ErrorMessage = "Teacher Name is required.")]
        public int TeacherId  { get; set; }

        [Required(ErrorMessage = "Subject Name is required.")]
        [StringLength(50, ErrorMessage = "Subject Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Class is required.")]
        [StringLength(10, ErrorMessage = "Class cannot be longer than 10 characters.")]
        public string Class { get; set; }

        public string Language { get; set; }

        public virtual Teacher Teacher { get; set; }

    }

}