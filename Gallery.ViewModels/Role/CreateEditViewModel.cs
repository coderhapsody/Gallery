using Gallery.Framework.Base;
using System.ComponentModel.DataAnnotations;

namespace Gallery.ViewModels.Role
{
    public class CreateEditViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
