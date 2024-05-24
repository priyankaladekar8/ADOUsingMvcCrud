using System.ComponentModel.DataAnnotations;

namespace ADOUsingMvcCrud.Models
{
    public class Employee
    {
        
        
            public int Id { get; set; }
            [Required]
            public string? Name { get; set; }
            [Required]
            public string? City { get; set; }
            [Required]
            public double Salary { get; set; }

        }
    }
