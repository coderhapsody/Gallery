using System;

namespace Gallery.Framework
{
    public class GalleryException : Exception
    {
        public GalleryException() : this("Unknown error")
        {
        }
        public GalleryException(string message) : base(message)
        {
        }
    }
}
