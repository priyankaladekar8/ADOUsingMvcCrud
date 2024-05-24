using System.ComponentModel.DataAnnotations;

namespace ADOCrudMVCProduct.Models
{
    public class Product
    {
    
            public int Id { get; set; }
            [Required]
            public string? Name { get; set; }
            [Required]

            public double Price { get; set; }

        }
    }


