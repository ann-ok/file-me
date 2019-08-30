using System.IO;

namespace FileMe.Helpers
{
    public static class StreamHelper
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            using (stream)
            {
                using (var memStream = new MemoryStream())
                {
                    stream.CopyTo(memStream);
                    return memStream.ToArray();
                }
            }
        }
    }
}