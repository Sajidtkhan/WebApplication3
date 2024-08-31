using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a valid number.")]
        public int Age { get; set; }

        public string Image { get; set; }

        public string Class { get; set; }

        [Required(ErrorMessage = "Roll Number is required.")]
        [StringLength(50, ErrorMessage = "Roll Number cannot be longer than 50 characters.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Roll must be a valid number.")]
        public string RollNumber { get; set; }
    }
}