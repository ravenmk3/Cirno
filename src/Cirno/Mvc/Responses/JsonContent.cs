using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Cirno.Common;
using Newtonsoft.Json;

namespace Cirno.Mvc.Responses
{
    public class JsonContent : ILazyContent
    {
        public JsonContent(object data) : this(data, Encoding.UTF8)
        {
        }

        public JsonContent(object data, Encoding encoding)
        {
            this.Data = data;
            this.Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        public object Data { get; }

        public Encoding Encoding { get; }

        private byte[] Serialize()
        {
            var json = JsonConvert.SerializeObject(this.Data);
            return this.Encoding.GetBytes(json);
        }

        public void WriteTo(Stream stream)
        {
            var buf = this.Serialize();
            stream.Write(buf, 0, buf.Length);
        }

        public Task WriteToAsync(Stream stream)
        {
            var buf = this.Serialize();
            return stream.WriteAsync(buf, 0, buf.Length);
        }
    }
}