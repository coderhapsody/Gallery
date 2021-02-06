using Gallery.Framework.Base;
using System.ComponentModel.DataAnnotations;

namespace Gallery.ViewModels.Taxonomy
{
    public class CreateEditViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }

        public bool Active { get; set; }

        public long? ParentTaxonomyId { get; set; }
    }
}
