using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.DataAccess
{
    public partial class GalleryDbContext
    {
        private static void GalleryDbContextStaticPartial()
        {
        }

        public void DisableProxyCreation() => Configuration.ProxyCreationEnabled = false;
    }
}
