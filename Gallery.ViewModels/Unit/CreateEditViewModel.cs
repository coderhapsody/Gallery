using Gallery.Framework.Base;
using System.ComponentModel.DataAnnotations;

namespace Gallery.ViewModels.Unit
{
    public class CreateEditViewModel : BaseViewModel
    {
        [Required]
        public string Group { get; set; }

        [Required]
        public string UnitName { get; set; }
    }
}
