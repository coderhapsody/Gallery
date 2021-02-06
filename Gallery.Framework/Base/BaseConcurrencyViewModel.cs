using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Framework.Base
{
    public abstract class BaseConcurrencyViewModel
    {
        public long Id { get; set; }
        public byte[] RowVersion { get; set; } = new byte[] { };
    }
}
