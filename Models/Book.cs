using System.ComponentModel.DataAnnotations;

namespace ADOCRUDMVCBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Author { get; set; }

    }
}
