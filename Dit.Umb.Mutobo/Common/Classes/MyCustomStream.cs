using System.IO;
using System.Text;
using System.Web;

namespace Dit.Umb.Mutobo.Common.Classes
{
    public class MyCustomStream : Stream
    {
        private readonly Stream filter;


        public MyCustomStream(Stream filter)
        {
            this.filter = filter;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var allScripts = new StringBuilder();
            string wholeHtmlDocument = Encoding.UTF8.GetString(buffer, offset, count);

            wholeHtmlDocument = HttpUtility.HtmlDecode(wholeHtmlDocument);
            buffer = Encoding.UTF8.GetBytes(wholeHtmlDocument);
            this.filter.Write(buffer, 0, buffer.Length);
        }

        public override void Flush()
        {
            this.filter.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.filter.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            this.filter.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.filter.Read(buffer, offset, count);
        }

        public override bool CanRead
        {
            get { return this.filter.CanRead; }
        }

        public override bool CanSeek
        {
            get { return this.filter.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return this.filter.CanWrite; }
        }

        public override long Length
        {
            get { return this.filter.Length; }
        }

        public override long Position
        {
            get { return this.filter.Position; }
            set { this.filter.Position = value; }
        }
    }
}
