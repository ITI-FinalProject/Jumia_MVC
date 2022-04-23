using System.ComponentModel.DataAnnotations;

namespace FinalProject.MVC.Data.ViewModel
{
    public class RoleFormViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
