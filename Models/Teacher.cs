using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a valid number.")]

        public int Age { get; set; }

        [Required(ErrorMessage = "Sex is required.")]
        [StringLength(10, ErrorMessage = "Sex cannot be longer than 10 characters.")]
        public string Sex { get; set; }
    }
}