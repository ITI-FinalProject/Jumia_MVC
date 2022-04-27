using System.ComponentModel.DataAnnotations;

namespace Jumia_MVC.Models
{
    public class FavoriteItem
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }

        public string FavoriteId { get; set; }


    }
}
