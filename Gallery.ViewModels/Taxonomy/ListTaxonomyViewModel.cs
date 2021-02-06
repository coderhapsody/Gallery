using Gallery.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.ViewModels.Taxonomy
{
    public class ListTaxonomyViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string Parent { get; set; }
        public bool Active { get; set; }
    }
}
