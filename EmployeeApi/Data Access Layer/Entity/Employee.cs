using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } =null!;
        [Required]
        public string LastName { get; set; } =null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } =null!;
        [Required]
        public string Position { get; set; } =null!;
    }
}
