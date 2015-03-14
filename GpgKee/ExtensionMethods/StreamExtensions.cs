using System;
using System.IO;

namespace GpgKee.ExtensionMethods
{
    internal static class StreamExtensions
    {
        public static void CopyTo(this Stream source, Stream destination)
        {
            if (destination == null)
                throw new ArgumentNullException("destination");
            if (!source.CanRead && !source.CanWrite)
                throw new ObjectDisposedException(null, "ObjectDisposed_StreamClosed");
            if (!destination.CanRead && !destination.CanWrite)
                throw new ObjectDisposedException("destination", "ObjectDisposed_StreamClosed");
            if (!source.CanRead)
                throw new NotSupportedException("NotSupported_UnreadableStream");
            if (!destination.CanWrite)
                throw new NotSupportedException("NotSupported_UnwritableStream");

            var buffer = new byte[4096];
            int read;
            while ((read = source.Read(buffer, 0, buffer.Length)) != 0)
                destination.Write(buffer, 0, read);
        }
    }
}
