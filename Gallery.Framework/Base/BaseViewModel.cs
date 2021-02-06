using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Framework.Base
{
    [Serializable]
    public abstract class BaseViewModel : BaseConcurrencyViewModel
    {
        public DateTime CreatedWhen { get; set; }
        public DateTime ChangedWhen { get; set; }
        public string CreatedWho { get; set; }
        public string ChangedWho { get; set; }
    }
}
