using Gallery.Framework.Base;
using System.ComponentModel.DataAnnotations;

namespace Gallery.ViewModels.EmployeeVisitCategory
{
    public class CreateEditViewModel : BaseViewModel
    {
        [Required]
        public string Description { get; set; }
    }
}
