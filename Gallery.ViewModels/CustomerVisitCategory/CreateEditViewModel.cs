using Gallery.Framework.Base;
using System.ComponentModel.DataAnnotations;

namespace Gallery.ViewModels.CustomerVisitCategory
{
    public class CreateEditViewModel : BaseViewModel
    {
        [Required]
        public string Description { get; set; }
    }
}
