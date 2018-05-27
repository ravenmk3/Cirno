using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Cirno.Common;

namespace Cirno.Mvc.Responses
{
    public class TextContent : ILazyContent
    {
        public TextContent(string text) : this(text, Encoding.UTF8)
        {
        }

        public TextContent(string text, Encoding encoding)
        {
            this.Text = text ?? String.Empty;
            this.Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        public string Text { get; }

        public Encoding Encoding { get; }

        public void WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            var buf = this.Encoding.GetBytes(this.Text);
            stream.Write(buf, 0, buf.Length);
        }

        public Task WriteToAsync(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            var buf = this.Encoding.GetBytes(this.Text);
            return stream.WriteAsync(buf, 0, buf.Length);
        }
    }
}