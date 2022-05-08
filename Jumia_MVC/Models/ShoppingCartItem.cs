using System.ComponentModel.DataAnnotations;

namespace Jumia_MVC.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]



        public ApplicationUser User { get; set; }
    }
}
