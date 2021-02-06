using Gallery.Framework.Base;
using System.ComponentModel.DataAnnotations;

namespace Gallery.ViewModels.Region
{
    public class CreateEditViewModel : BaseViewModel
    {
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "Region Name")]
        public string Name { get; set; }
    }
}
