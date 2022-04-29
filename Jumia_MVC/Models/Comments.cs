using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumia_MVC.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        [Range(0, 5, ErrorMessage = "Rate must be between 0:5")]
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
