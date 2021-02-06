﻿using System.Collections.Generic;

namespace Gallery.Framework.Base
{
    public class ListViewModel<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
    }
}
