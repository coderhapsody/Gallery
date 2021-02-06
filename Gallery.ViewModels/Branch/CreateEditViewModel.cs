using Gallery.Framework.Base;
using System.ComponentModel.DataAnnotations;

namespace Gallery.ViewModels.Branch
{
    public class CreateEditViewModel : BaseViewModel
    {
        [Required]
        public string BranchCode { get; set; } 

        [Required]
        public string Description { get; set; } 
        public string Address1 { get; set; }
        public string Address2 { get; set; } 
        public string PostalCode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public bool Active { get; set; }
    }
}
