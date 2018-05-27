using System;
using System.IO;
using System.Threading.Tasks;

namespace Cirno.Common
{
    public class LazyContent : ILazyContent
    {
        private readonly Action<Stream> action;

        public LazyContent(Action<Stream> action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public void WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            this.action.Invoke(stream);
        }

        public Task WriteToAsync(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Task.Run(() => this.action.Invoke(stream));
        }
    }
}